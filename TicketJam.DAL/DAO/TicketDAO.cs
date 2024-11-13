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
        private string _GET_BY_ID = "SELECT * FROM Ticket WHERE Id = @Id";

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
            return connection.QuerySingle<Ticket>(_GET_BY_ID, new { Id = id });

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
