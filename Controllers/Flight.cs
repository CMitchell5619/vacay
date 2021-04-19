using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Services;
using Microsoft.AspNetCore.Mvc;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FLighteditFlightsController : ControllerBase
    {

        private readonly FlightsService _service;

        public FlightsController(FlightsService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Flight>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Flight> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Flight> Create([FromBody] Flight newFlight)
        {
            try
            {
                return Ok(_service.Create(newFlight));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Flight> Edit([FromBody] Flight editFlight, int id)
        {
            try
            {
                editFlight.Id = id;
                return Ok(_service.Edit(editFlight));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Flight> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}