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
        private string GETALLSECTIONS_SQL = "SELECT * FROM Section";
        private string GETSECTIONBYID_SQL = "SELECT * FROM Section WHERE Id = @Id";
        private string GETSECTIONBYVENUEID_SQL = "SELECT * FROM Section WHERE Venue_ID_FK = @Venue_ID_FK";

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

        public IEnumerable<Section> GetSectionsByVenue(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return connection.Query<Section>(GETSECTIONBYVENUEID_SQL, new { Venue_ID_FK = id });
        }

    }
}
