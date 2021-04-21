using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MeasurementController : Controller
    {
        private readonly IMeasurementService _service;

        public MeasurementController(IMeasurementService service)
        {
            _service = service;
        }

        // GET: api/<MeasurementController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> Get()
        {
            return Ok(await _service.GetMeasurementsAsync());
        }

        // GET api/<MeasurementController>/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Measurement>> Get(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok(await _service.GetMeasurementAsync(Guid.Parse(id)));
        }

        // POST api/<MeasurementController>
        [HttpPost]
        public async Task<ActionResult<Measurement>> Post(Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                await _service.AddMeasurementAsync(measurement);
                return CreatedAtRoute(nameof(Get), new { id = measurement.ID }, measurement);
            }
            return BadRequest();
        }

        // PUT api/<MeasurementController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Measurement measurement)
        {
            Guid guidid = Guid.Parse(id);

            if (measurement == null || measurement.ID != guidid)
            {
                return BadRequest();
            }

            if (!_service.MeasurementExists(guidid))
            {
                return NotFound();
            }

            try
            {
                await _service.UpdateMeasurementAsync(measurement);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();     // HTTP Status 204
        }

        // DELETE api/<MeasurementController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            Guid guidid = Guid.Parse(id);

            if (!_service.MeasurementExists(guidid))
            {
                return NotFound();
            }

            await _service.DeleteMeasurementAsync(guidid);
            return NoContent();
        }
    }
}
