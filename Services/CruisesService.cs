using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class CruisesService
    {
        private readonly CruisesRepository _repo;

        public CruisesService(CruisesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Cruise> Get()
        {
            return _repo.Get();
        }

        internal Cruise Get(int id)
        {
            Cruise cruise = _repo.Get(id);
            if (cruise == null)
            {
                throw new Exception("invalid id");
            }
            return cruise;
        }

        internal Cruise Create(Cruise newCruise)
        {
            return _repo.Create(newCruise);
        }
        internal Cruise Edit(Cruise editCruise)
        {
            Cruise original = Get(editCruise.Id);

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            original.Ports = editCruise.Ports != null ? editCruise.Ports : original.Ports;

            return _repo.Edit(original);
        }

        internal Cruise Delete(int id)
        {
            Cruise original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}