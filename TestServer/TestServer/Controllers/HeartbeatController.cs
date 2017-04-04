using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestServer.Controllers
{
    [Route("api/v1.0/heartbeat")]
    public class HeartbeatController : Controller
    {
        private readonly IHeartbeatRepository _repository;

        public HeartbeatController(IHeartbeatRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IEnumerable<Heartbeat> Get()
        {
            // Create the new heartbeat before returning it along with all other currently stored
            // heartbeats from downstream
            Heartbeat heartbeat = new Heartbeat()
            {
                SourceId = "SERVER_ID",
                Timestamp = DateTime.UtcNow
            };

            List<Heartbeat> heartbeats = _repository.GetAll().ToList();
            heartbeats.Add(heartbeat);
            _repository.Clear();
            return heartbeats;
        }

        [HttpGet("{id}", Name = "GetHeartbeat")]
        public IActionResult Get(long id)
        {
            var heartbeat = _repository.Find(id);
            if (heartbeat == null)
            {
                return NotFound();
            }
            return new ObjectResult(heartbeat);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]Heartbeat heartbeat)
        {
            if (heartbeat == null)
            {
                return BadRequest();
            }

            _repository.Add(heartbeat);
            return CreatedAtRoute("GetHeartbeat", new { id = heartbeat.Key }, heartbeat);
        }
    }
}
