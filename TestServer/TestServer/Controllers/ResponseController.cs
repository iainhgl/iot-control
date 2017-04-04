using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestServer.Controllers
{
    [Route("api/v1.0/response")]
    public class ResponseController : Controller
    {
        private readonly IResponseRepository _repository;

        public ResponseController(IResponseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<long> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}", Name = "GetResponse")]
        public IActionResult Get(long id)
        {
            var response = _repository.Find(id);
            if (response == null)
            {
                return NotFound();
            }
            return new ObjectResult(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Response response)
        {
            if (response == null)
            {
                return BadRequest();
            }

            _repository.Add(response);

            // Try and find the associated request, and delete it if it exists
            return CreatedAtRoute("GetResponse", new { id = response.Key }, response);
        }
    }
}
