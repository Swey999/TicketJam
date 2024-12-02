using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;
using Dapper;
using DataAccess.Authentication;
using System.Collections;

namespace TicketJam.DAL.DAO
{
    public class OrganizerDAO : IOrganizerDAO
    {
        private readonly string _connectionString;
        private readonly string _insertOrganizer_SQL = "Insert into Organizer (Password, Email, PhoneNo) values (@Password, @Email, @PhoneNo); SELECT CAST(SCOPE_IDENTITY() as int)";
        private readonly string _Login_SQL = "select Id, PhoneNo, Email, Password from Organizer where Email = @Email";

        public OrganizerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int CreateOrganizerAndReturnIdentity(Organizer organizer)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            organizer.Password = BCryptTool.HashPassword(organizer.Password);

            try
            {
                organizer.Id = connection.ExecuteScalar<int>(_insertOrganizer_SQL, organizer, transaction);
                //TODO: Hardcoded test data to ensure it does not save in database, could be optimized
                if (organizer.Email == "Testmailer@gmail.com")
                {
                    transaction.Rollback();
                } else
                {
                    transaction.Commit();
                }
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

        public Organizer Login(Organizer organizer)
        {

            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            //Set empty Organizer to return to ensure no leak on data
            Organizer ReturnOrganizer = new Organizer() { Id = 0, Password = "", Email = "", PhoneNo = ""};

            try
            {
                Organizer organizerFromDB = connection.QueryFirstOrDefault<Organizer>(_Login_SQL, new { Email = organizer.Email });
                //Check if result was null, if that's the case throw exception for handling
                if (organizerFromDB.Password == null)
                {
                    throw new Exception($"Not correct password for {organizer.Email}");
                    return ReturnOrganizer;
                }
                //Check if passwords match, will not be reached unless email could be found in database
                if (BCryptTool.ValidatePassword(organizer.Password, organizerFromDB.Password))
                {
                    ReturnOrganizer = organizerFromDB;
                    ReturnOrganizer.Password = "";
                }
            }
            catch (SqlException e)
            {
                throw new Exception($"Not correct password for {organizer.Email}", e);
            }
            return ReturnOrganizer;
        }
    }
}
