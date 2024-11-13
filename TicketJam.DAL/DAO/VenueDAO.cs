﻿using System;
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
        private string GETALLVENUES_SQL = "SELECT * FROM Venue";
        private string GETVENUEBYID_SQL = "SELECT * FROM Venue WHERE Id = @Id";

        public VenueDAO(String connectionStringns)
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

        public Venue GetById(int id)
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QuerySingle<Venue>(GETVENUEBYID_SQL, new { Id = id });
        }

        public IEnumerable<Venue> Read()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            return connection.Query<Venue>(GETALLVENUES_SQL);
        }

        public Venue Update(Venue entity)
        {
            throw new NotImplementedException();
        }
    }
}
