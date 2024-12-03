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
    public class VenueDAO : IDAO<Venue>
    {
        private string _connectionString;

        //TODO: * skal rettes så vi ikke henter ALT op fra databasen. Det bliver en senere opgave.
        private string GETALLVENUES_SQL = "SELECT DISTINCT Venue.*, Address.* FROM Address JOIN Venue on Address.id = Venue.Address_ID_FK";
        private string GETVENUEBYID_SQL = "SELECT DISTINCT Venue.*, Address.* FROM Address JOIN Venue on Address.id = Venue.Address_ID_FK WHERE Venue.id = @Id";
        // private string GETALLVENUESWITHOUTADDRESS_SQL = "SELECT * FROM VENUE";

        public VenueDAO(string connectionStringns)
        {
            this._connectionString = connectionStringns;
        }
        public Venue Create(Venue entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves Venue using its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Returns a Venue with correct ID
        /// <exception cref="Exception"></exception>
        /// Throws exception if issue finding specific venue or connecting to database
        public Venue GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                return connection.QuerySingle<Venue>(GETVENUEBYID_SQL, new { Id = id });
            }
            catch (SqlException e)
            {
                throw new Exception ($"There was an issue getting venue by ID: {id}, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Finds all venues
        /// </summary>
        /// <returns></returns>
        /// Returns IEnumerable of venues
        /// <exception cref="Exception"></exception>
        /// Throws exception if not able to find all venues or connect to database
        public IEnumerable<Venue> Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                return connection.Query<Venue>(GETALLVENUES_SQL);
            }
            catch (SqlException e)
            {
                throw new Exception($"There was an issue finding all venues, error message was {e.Message}", e);
            }
            finally
            {
                connection.Close();
            }
        }

        //Is not used currently, might be used later
        //public IEnumerable<Venue> ReadWithoutAddress()
        //{
        //    using IDbConnection connection = new SqlConnection(_connectionString);
        //    try
        //    {
        //        return connection.Query<Venue>(GETALLVENUESWITHOUTADDRESS_SQL);
        //    }
        //    catch (SqlException e)
        //    {
        //        throw new Exception($"There was an issue finding all venues, error message was {e.Message}", e);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        public Venue Update(Venue entity)
        {
            throw new NotImplementedException();
        }


    }
}
