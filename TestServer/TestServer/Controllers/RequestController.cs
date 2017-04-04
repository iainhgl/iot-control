using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestServer.Controllers
{
    [Route("api/v1.0/request")]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _repository;
        private readonly IRequestStatusRepository _statusRepository;

        public RequestController(IRequestRepository repository,
            IRequestStatusRepository statusRepository)
        {
            _repository = repository;
            _statusRepository = statusRepository;
        }

        //[HttpGet]
        //[Route("")]
        //public IEnumerable<long> Get()
        //{
        //    return _repository.GetAll();
        //}

        [HttpGet]
        [Route("")]
        public IEnumerable<long> GetForDestination([FromQuery]string destinationId)
        {
            return _repository.GetAllForDestination(destinationId);
        }

        [HttpGet("{id}", Name = "GetRequest")]
        public IActionResult GetById(long id)
        {
            var request = _repository.Find(id);
            if (request == null)
            {
                return NotFound();
            }
            return new ObjectResult(request);
        }

        //[HttpGet("", Name = "GetRequestById")]
        //public IActionResult GetByRequestId([FromQuery]string requestId)
        //{
        //    var request = _repository.FindByRequestId(requestId);
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(request);
        //}

        [HttpPost("")]
        public IActionResult CreateRequest([FromBody]Request request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            _repository.Add(request);
            RequestStatus status = new RequestStatus()
            {
                Id = request.Id,
                Status = RequestStatusTypes.InTransit,
                SourceId = "SERVER_ID",
                Timestamp = DateTime.UtcNow,
            };
            _statusRepository.Add(status);

            return CreatedAtRoute("GetRequest", new { id = request.Key }, request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(long id)
        {
            var request = _repository.Find(id);
            if (request == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpDelete("")]
        public IActionResult DeleteByRequestId([FromQuery]string requestId)
        {
            var request = _repository.FindByRequestId(requestId);
            if (request == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
