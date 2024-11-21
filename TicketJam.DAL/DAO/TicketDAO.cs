using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;
using Dapper;

namespace TicketJam.DAL.DAO
{
    public class TicketDAO : IDAO<Ticket>
    {
        private string _connectionString;
        private string _GET_BY_ID = "SELECT Id, Description, TicketId, Price, TicketCategory, TimeCreated, Section_ID_FK, Event_ID_FK from Ticket WHERE id = @id";

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
                throw new Exception ($"There was an issue finding ticket using ID: {id}, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }

        }

        public IEnumerable<Ticket> Read()
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket entity)
        {
            throw new NotImplementedException();
        }

    }
}
