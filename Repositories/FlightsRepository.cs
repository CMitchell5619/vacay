using System;
using System.Collections.Generic;
using System.Data;
using vacay.Models;
using Dapper;

namespace vacay.Repositories
{
    public class FlightsRepository
    {

        public readonly IDbConnection _db;

        public FlightsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Flight> Get()
        {
            string sql = "SELECT * FROM flights;";
            return _db.Query<Flight>(sql);
        }

        internal Flight Get(int Id)
        {
            string sql = "SELECT * FROM flights WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Flight>(sql, new { Id });
        }

        internal Flight Create(Flight newFlight)
        {
            string sql = @"
      INSERT INTO flights
      (layovers)
      VALUES
      (@Layovers);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFlight);
            newFlight.Id = id;
            return newFlight;
        }

        internal Flight Edit(Flight flightToEdit)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE flights
      SET
          layovers = @Layovers,
      WHERE id = @Id;
      SELECT * FROM flights WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Flight>(sql, flightToEdit);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM flights WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}