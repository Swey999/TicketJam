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
    public class SectionDAO : IDAO<Section>, ISectionDAO
    {
        private string _connectionString;
        private string GETALLSECTIONS_SQL = "SELECT Id, Description, TicketAmount, Venue_ID_FK FROM Section;";
        private string GETSECTIONBYID_SQL = "SELECT Id FROM Section WHERE Id=@Id";
        private string GETSECTIONBYVENUEID_SQL = "SELECT Id, Description, TicketAmount, Venue_ID_FK FROM Section WHERE Venue_ID_FK = @Venue_ID_FK";

        public SectionDAO(String connectionStringns)
        {
            this._connectionString = connectionStringns;
        }
        public Section Create(Section entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves section using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Returns Section if found
        /// <exception cref="Exception"></exception>
        /// Throws exception error finding section with ID or issue connecting to database
        public Section GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                return connection.QuerySingle<Section>(GETSECTIONBYID_SQL, new { Id = id });
            }
            catch (SqlException e)
            {
                throw new Exception ($"There was an issue getting section by ID: {id}, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Retrieves all sections
        /// </summary>
        /// <returns></returns>
        /// Returns all sections in an IEnumerable
        /// <exception cref="Exception"></exception>
        /// Throws exception if issue finding all sections or issue connecting to database
        public IEnumerable<Section> Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                return connection.Query<Section>(GETALLSECTIONS_SQL);
            }
            catch (SqlException e)
            {
                throw new Exception ($"There was an issue getting all sections, error message was {e.Message}", e);
            } finally 
            {
                connection.Close();
            }
        }

        public Section Update(Section entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all sections from a certain venue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Returns IEnumerable of all sections
        /// <exception cref="Exception"></exception>
        /// Throws exception if not able to find sections using ID or issue connecting to database

        public IEnumerable<Section> GetSectionsByVenue(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                return connection.Query<Section>(GETSECTIONBYVENUEID_SQL, new { Venue_ID_FK = id });
            }
            catch (SqlException e)
            {
                throw new Exception($"There was an issue finding all sections for Venue with ID: {id}, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

    }
}
