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
    public class SectionDAO : IDAO<Section>
    {
        private string _connectionString;
        private string GETALLSECTIONS_SQL = "SELECT * FROM Section";
        private string GETSECTIONBYID_SQL = "SELECT * FROM Section WHERE Id = @Id";


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
            return connection.QuerySingle<Section>(GETSECTIONBYID_SQL, new { Id = id });
        }

        public IEnumerable<Section> Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            return connection.Query<Section>(GETALLSECTIONS_SQL);
        }

        public Section Update(Section entity)
        {
            throw new NotImplementedException();
        }

    }
}
