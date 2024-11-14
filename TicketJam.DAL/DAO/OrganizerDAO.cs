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
    public class OrganizerDAO : IOrganizerDAO
    {
        private readonly string _connectionString;
        private readonly string _insertOrganizer_SQL = "Insert into Organizer (Password, Email, PhoneNo) values (@Password, @Email, @PhoneNo); SELECT CAST(SCOPE_IDENTITY() as int)";

        public OrganizerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int CreateOrganizerAndReturnIdentity(Organizer organizer)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                organizer.Id = connection.ExecuteScalar<int>(_insertOrganizer_SQL, organizer);
                return organizer.Id;
            }
            catch (SqlException e)
            {
                throw new Exception($"There was an issue connecting to database and inserting organizer, exception was {e.Message}", e);
            } finally
            {
                connection.Close();
            }

        }
    }
}
