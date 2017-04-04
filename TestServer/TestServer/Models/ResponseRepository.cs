using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly TestServerContext _context;

        public ResponseRepository(TestServerContext context)
        {
            _context = context;
        }

        public void Add(Response response)
        {
            _context.Responses.Add(response);
            _context.SaveChanges();
        }

        public Response Find(long key)
        {
            return _context.Responses.FirstOrDefault(r => r.Key == key);
        }

        public Response FindByRequestId(string responseId)
        {
            return _context.Responses.FirstOrDefault(r => r.Id == responseId);
        }

        public IEnumerable<long> GetAll()
        {
            return (from r in _context.Responses select r.Key).ToList();
        }

        public void Remove(long key)
        {
            var response = _context.Responses.First(r => r.Key == key);
            _context.Responses.Remove(response);
            _context.SaveChanges();
        }

        public void RemoveByRequestId(string responseId)
        {
            var response = _context.Responses.First(r => r.Id == responseId);
            _context.Responses.Remove(response);
            _context.SaveChanges();
        }

        public void Update(Response response)
        {
            _context.Responses.Update(response);
            _context.SaveChanges();
        }
    }
}
