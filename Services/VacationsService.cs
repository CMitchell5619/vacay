using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class VacationsService
    {
        private readonly VacationsRepository _repo;

        public VacationsService(VacationsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Vacation> getAll()
        {
            var data = _repo.GetAll();
            return data;
        }
    }
}