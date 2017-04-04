using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public class RequestRepository : IRequestRepository
    {
        private readonly TestServerContext _context;

        public RequestRepository(TestServerContext context)
        {
            _context = context;
        }

        public void Add(Request request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
        }

        public Request Find(long key)
        {
            return _context.Requests.FirstOrDefault(r =>r.Key == key);
        }

        public Request FindByRequestId(string requestId)
        {
            return _context.Requests.FirstOrDefault(r => r.Id == requestId);
        }

        public IEnumerable<long> GetAll()
        {
            return (from r in _context.Requests select r.Key).ToList();
        }

        public IEnumerable<long> GetAllForDestination(string destinationId)
        {
            return (from r in _context.Requests where r.Route.Id == destinationId select r.Key).ToList();
        }

        public void Remove(long key)
        {
            var request = _context.Requests.First(r => r.Key == key);
            _context.Requests.Remove(request);
            _context.SaveChanges();
        }

        public void RemoveByRequestId(string requestId)
        {
            var request = _context.Requests.First(r => r.Id == requestId);
            _context.Requests.Remove(request);
            _context.SaveChanges();
        }

        public void Update(Request request)
        {
            _context.Requests.Update(request);
            _context.SaveChanges();
        }
    }
}
