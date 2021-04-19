using System;
using System.Collections.Generic;
using System.Data;
using vacay.Models;
using Dapper;

namespace vacay.Repositories
{
    public class CruisesRepository
    {

        public readonly IDbConnection _db;

        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Cruise> Get()
        {
            string sql = "SELECT * FROM cruises;";
            return _db.Query<Cruise>(sql);
        }

        internal Cruise Get(int Id)
        {
            string sql = "SELECT * FROM cruises WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, new { Id });
        }

        internal Cruise Create(Cruise newCruise)
        {
            string sql = @"
      INSERT INTO cruises
      (ports)
      VALUES
      (@Ports);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal Cruise Edit(Cruise cruiseToEdit)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE cruises
      SET
          ports = @Ports,
      WHERE id = @Id;
      SELECT * FROM cruises WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, cruiseToEdit);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cruises WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}