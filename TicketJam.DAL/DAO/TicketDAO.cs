using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;
using Dapper;
using System.Data.Common;
using System.Transactions;
using System.Threading.Channels;

namespace TicketJam.DAL.DAO
{
    public class TicketDAO : IDAO<Ticket>, ITicketDAO
    {
        private string _connectionString;
        private string _getTicketByIdSQL = "SELECT Id, Description, TicketId, Price, TicketCategory, MaxAmount, TimeCreated, Section_ID_FK, Event_ID_FK from Ticket WHERE id = @id";
        private string _updateTicketAmountSQL = "UPDATE Section SET TicketAmount = @TicketAmount FROM Section JOIN Ticket ON Ticket.Section_ID_FK = Section.Id WHERE Section.Id = @SectionId;";
        private string _getTicketByIdJoinSQL = @"SELECT Ticket.*, Section.*, Event.* FROM Ticket JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Event ON Event.Id = Ticket.Event_ID_FK WHERE Ticket.Id = @TicketId";
        private string _getTicketByTicketIdJoinSQL = @"SELECT Ticket.*, Section.*, Event.* FROM Ticket JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Event ON Event.Id = Ticket.Event_ID_FK WHERE TicketId = @TicketId";
        private string _InsertTicketSQL = "insert into Ticket (Description, TicketId, Price, TicketCategory, TimeCreated, Section_ID_FK, Event_ID_FK, MaxAmount) values (@Description, @TicketId, @Price, @TicketCategory, @TimeCreated, @SectionId, @EventId, @MaxAmount)";
        private string _updateSectionSQL = @"UPDATE Section SET TicketAmount -= @Quantity WHERE Id = @SectionId;";
        private string _updateEventSQL = @"UPDATE Event SET TotalAmount -= @Quantity WHERE Id = @EventId;";

        public TicketDAO(String connectionStringns)
        {
            this._connectionString = connectionStringns;
        }

        public Ticket Create(Ticket entity)
        {
            throw new NotImplementedException();
        }



        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a ticket with its sections and event
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        /// Returns ticket with its sections and event
        /// <exception cref="Exception"></exception>
        /// Throws exception if error with retrieving ticket with ticketId or issue connecting to database
        public Ticket GetTicketWithSectionAndEvent(int ticketId)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                // Query to join Ticket with Section and Event

                // Execute query and map the result
                var ticket = connection.Query<Ticket, Section, Event, Ticket>(
                    _getTicketByIdJoinSQL,
                    (t, s, e) =>
                    {
                        t.Section = s;
                        t.Event = e;
                        return t;
                    },
                    new { TicketId = ticketId })
                    .SingleOrDefault();

                return ticket;
            }
            catch (SqlException e)
            {
                throw new Exception($"Error retrieving ticket with ID: {ticketId}, error: {e.Message}", e);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public Ticket TicketWithSectionAndEvent(int ticketId)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                // Query to join Ticket with Section and Event

                // Execute query and map the result
                var ticket = connection.Query<Ticket, Section, Event, Ticket>(
                    _getTicketByTicketIdJoinSQL,
                    (t, s, e) =>
                    {
                        t.Section = s;
                        t.Event = e;
                        return t;
                    },
                    new { TicketId = ticketId })
                    .SingleOrDefault();

                return ticket;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error retrieving ticket with ID: {ticketId}, error: {ex.Message}", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Retrieves a ticket using its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Returns a ticket
        /// <exception cref="Exception"></exception>
        /// Throws exception if problem finding ticket with id or issues connecting with database
        public Ticket GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                return connection.QuerySingle<Ticket>(_getTicketByIdSQL, new { Id = id });
            }
            catch (SqlException e)
            {
                throw new Exception($"There was an issue finding ticket using ID: {id}, error message was {e.Message}", e);
            }
            finally
            {
                connection.Close();
            }

        }

        public IEnumerable<Ticket> Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates available tickets in database
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        /// Returns true if succesful and done, and false if not
        /// <exception cref="Exception"></exception>
        /// Throws exception if unable to find ticket
        /// Throws exception if problem contacting database
        public bool Update(int quantity, int ticketId, IDbConnection connection, IDbTransaction transaction)
        {
            try
            {
                Ticket ticket = GetTicketWithSectionAndEvent(ticketId);



                try
                {
                    if (ticket.Event.TotalAmount - quantity < 0 || ticket.Section.TicketAmount - quantity < 0)
                    {
                        return false;
                    }

                    int sectionRowsAffected = connection.Execute(_updateSectionSQL, new
                    {
                        SectionId = ticket.Section.Id,
                        Quantity = quantity
                    }, transaction);

                    int eventRowsAffected = connection.Execute(_updateEventSQL, new
                    {
                        EventId = ticket.Event.Id,
                        Quantity = quantity
                    }, transaction);

                    return true;

                }
                catch (SqlException e)
                {
                    throw new Exception($"Failed to update TicketAmount and TotalAmount. Error message was {e.Message}", e);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting ticket using ticketId {ticketId}, was unable to update section and event ticket amounts. Error message was {e.Message}", e);
            }
        }

        public Ticket Update(Ticket entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a ticket using events ID to connec them in database
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="ticket"></param>
        /// <exception cref="Exception"></exception>
        /// Throws exception if it fails
        public void InsertTicketWithEventId(int eventId, Ticket ticket)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            //TODO, make with less chance of duplicate, probably uuid ish
            Random random = new Random();
            ticket.TicketId = random.Next();
            connection.Open();
            try
            {
                //Cannot pass parameter ticket as parameter in Execute because it does not 1:1 match database, so we create empty object and assign the values
                //Hardcoded SectionId to be implemente later, same with maxamount
                ticket.Id = connection.Execute(_InsertTicketSQL, new
                {
                    Description = ticket.Description,
                    TicketId = ticket.TicketId,
                    Price = ticket.Price,
                    TicketCategory = ticket.TicketCategory,
                    TimeCreated = ticket.TimeCreated,
                    SectionId = 1,
                    EventId = eventId,
                    MaxAmount = 10
                });
            }
            catch (SqlException e)
            {
                throw new Exception($"There was an issue saving ticket, error message was {e.Message}", e);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
