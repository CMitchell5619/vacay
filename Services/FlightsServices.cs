using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class FlightsService
    {
        private readonly FlightsRepository _repo;

        public FlightsService(FlightsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Flight> Get()
        {
            return _repo.Get();
        }

        internal Flight Get(int id)
        {
            Flight burger = _repo.Get(id);
            if (burger == null)
            {
                throw new Exception("invalid id");
            }
            return burger;
        }

        internal Flight Create(Flight newFlight)
        {
            return _repo.Create(newFlight);
        }
        internal Flight Edit(Flight editFlight)
        {
            Flight original = Get(editFlight.Id);

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            original.Layovers = editFlight.Layovers != null ? editFlight.Layovers : original.Layovers;

            return _repo.Edit(original);
        }

        internal Flight Delete(int id)
        {
            Flight original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}