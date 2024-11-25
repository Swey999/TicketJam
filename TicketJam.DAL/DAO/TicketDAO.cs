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

namespace TicketJam.DAL.DAO
{
    public class TicketDAO : IDAO<Ticket>, ITicketDAO
    {
        public string updateAccountSQL = "UPDATE Ticket SET WHERE id=@id";
        private string _connectionString;
        private string _GET_BY_ID = "SELECT Id, Description, TicketId, Price, TicketCategory, TimeCreated, Section_ID_FK, Event_ID_FK from Ticket WHERE id = @id";
        private string _updateTicketAmountSQL = "UPDATE Section SET TicketAmount = @TicketAmount FROM Section JOIN Ticket ON Ticket.Section_ID_FK = Section.Id WHERE Section.Id = @SectionId;";
        private string _GET_TICKET_FROM_ID_JOIN = @"SELECT Ticket.*, Section.*, Event.* FROM Ticket JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Event ON Event.Id = Ticket.Event_ID_FK WHERE Ticket.Id = @TicketId";
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

        public Ticket GetTicketWithSectionAndEvent(int ticketId)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                // Query to join Ticket with Section and Event

                // Execute query and map the result
                var ticket = connection.Query<Ticket, Section, Event, Ticket>(
                    _GET_TICKET_FROM_ID_JOIN,
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
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving ticket with ID: {ticketId}, error: {ex.Message}", ex);
            }
        }



        public Ticket GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                return connection.QuerySingle<Ticket>(_GET_BY_ID, new { Id = id });
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

        public Ticket Update(int quantity, int ticketId)
        {
            using DbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();


            Ticket ticket = GetTicketWithSectionAndEvent(ticketId);

            // SQL for updating TicketAmount in Section
            const string updateSectionSQL = @"
        UPDATE Section
        SET TicketAmount -= @Quantity
        WHERE Id = @SectionId;";

            // SQL for updating TotalAmount in Event
            const string updateEventSQL = @"
        UPDATE Event
        SET TotalAmount -= @Quantity
        WHERE Id = @EventId;";

            try
            {
                // Execute the first update on Section
                int sectionRowsAffected = connection.Execute(updateSectionSQL, new
                {
                    SectionId = ticket.Section.Id,
                    Quantity = quantity
                }, transaction);

                // Execute the second update on Event
                int eventRowsAffected = connection.Execute(updateEventSQL, new
                {
                    EventId = ticket.Event.Id,  // Assuming EventId is related to SectionId or you can pass it separately
                    Quantity = quantity
                }, transaction);

                // Commit the transaction if both updates were successful
                transaction.Commit();
                return ticket; // Return true if both were updated
            }
            catch (Exception ex)
            {
                // Rollback if something goes wrong
                transaction.Rollback();
                throw new Exception("Failed to update TicketAmount and TotalAmount.", ex);
            }
        }

        public Ticket Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
