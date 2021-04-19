using System.Collections.Generic;
using burgershack.Interfaces;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationsController : ControllerBase
    {
        private readonly VacationsService _vacationsService;

        public VacationsController(VacationsService vacationsService)
        {
            _vacationsService = vacationsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vacation>> GetAllVacations()
        {
            try
            {
                return Ok(_vacationsService.getAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}