using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly TestServerContext _context;

        public RequestStatusRepository(TestServerContext context)
        {
            _context = context;
        }

        public void Add(RequestStatus status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();
        }

        public RequestStatus Find(long key)
        {
            return _context.Statuses.FirstOrDefault(s => s.Key == key);
        }

        public IEnumerable<RequestStatus> GetAll()
        {
            return _context.Statuses.ToList();
        }
    }
}
