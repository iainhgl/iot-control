using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestServer.Controllers
{
    [Route("api/v1.0/request/status")]
    public class RequestStatusController : Controller
    {
        private readonly IRequestStatusRepository _repository;

        public RequestStatusController(IRequestStatusRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<RequestStatus> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}", Name = "GetRequestStatus")]
        public IActionResult Get(long key)
        {
            RequestStatus status = _repository.Find(key);
            if (status == null)
            {
                return NotFound();
            }

            return new ObjectResult(status);
        }
    }
}
