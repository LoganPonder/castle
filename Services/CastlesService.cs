using System;
using System.Collections.Generic;
using castle.Models;
using castle.Repositories;

namespace castle.Services
{
    public class CastlesService
    {
        private readonly CastlesRepository _repo;

        public CastlesService(CastlesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> GetAllCastles()
            {
                return _repo.GetAllCastles();
            }

        internal Castle GetCastleById(int id)
        {
            Castle castle = _repo.GetCastleById(id);
            if(castle == null) {
                throw new Exception("Invalid ID");
            }
            return castle;
        }

        internal Castle CreateCastle(Castle newCastle)
        {
            Castle castle = _repo.CreateCastle(newCastle);
            return castle;
        }

        internal Castle EditCastle(Castle edit)
        {
            Castle original = GetCastleById(edit.Id);
            original.Name = edit.Name.Length > 0 ? edit.Name : original.Name;
            original.Location = edit.Location.Length > 0 ? edit.Location : original.Location;
            original.YearBuilt = edit.YearBuilt > 0 ? edit.YearBuilt : original.YearBuilt;
            if(_repo.EditCastle(original))
            {
                return original;
            }
            throw new Exception("Error/Try Again.");
        }

        internal void DeleteCastle(int id)
        {
            GetCastleById(id);
            _repo.DeleteCastle(id);
        }
    }
}