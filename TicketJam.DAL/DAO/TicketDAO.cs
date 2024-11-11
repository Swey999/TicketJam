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
        private string connectionString;

        public TicketDAO(String connectionStringns)
        {
            this.connectionString = connectionStringns;
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

            string commandText = "SELECT * FROM Ticket WHERE Id = @Id";
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection.QuerySingle<Ticket>(commandText, new { Id = id });

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
