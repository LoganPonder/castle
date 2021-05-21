using System;
using System.Collections.Generic;
using System.Data;
using castle.Models;
using Dapper;

namespace castle.Repositories
{
    public class CastlesRepository
    {
        private readonly IDbConnection _db;
        public CastlesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Castle> GetAllCastles()
        {
            string sql = "SELECT * FROM castles_logan";
            return _db.Query<Castle>(sql);
        }

        internal Castle GetCastleById(int id)
        {
            string sql = "SELECT * FROM castles_logan WHERE id = @id";
            return _db.QueryFirstOrDefault<Castle>(sql, new { id });
        }

        internal Castle CreateCastle(Castle newCastle)
        {
            string sql = @"
            INSERT INTO castles_logan
            (name, location, yearbuilt)
            VALUES
            (@Name, @Location, @YearBuilt);
            SELECT LAST_INSERT_ID()";
            
            newCastle.Id = _db.ExecuteScalar<int>(sql, newCastle);
            return newCastle;
        }
    // REVIEW why are some of the props camelcase/lowercase, mint-green text. EDIT IS NOT WORKING
        internal bool EditCastle(Castle original)
        {
            string sql = @"
            UPDATE castles_logan
            SET
                name = @Name,
                location = @Location,
                yearbuilt = @YearBuilt
            WHERE id=@Id
            ";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        // REVIEW why is the delete a bool? and what does the affectedrows == 1 mean/ new { id }?
        internal bool DeleteCastle(int id)
        {
            string sql = "DELETE FROM castles_logan WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}