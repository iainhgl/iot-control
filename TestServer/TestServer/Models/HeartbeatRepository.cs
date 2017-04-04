using System;
using System.Collections.Generic;
using System.Linq;

namespace TestServer.Models
{
    public class HeartbeatRepository : IHeartbeatRepository
    {
        private readonly TestServerContext _context;

        public HeartbeatRepository(TestServerContext context)
        {
            _context = context;
        }

        public void Add(Heartbeat heartbeat)
        {
            _context.Heartbeats.Add(heartbeat);
            _context.SaveChanges();
        }

        public void Clear()
        {
            // This will be slow but this is test server and will have small amounts of data...
            _context.Heartbeats.RemoveRange(_context.Heartbeats);
            _context.SaveChanges();
        }

        public Heartbeat Find(long key)
        {
            return _context.Heartbeats.FirstOrDefault(h => h.Key == key);
        }

        public IEnumerable<Heartbeat> GetAll()
        {
            return _context.Heartbeats.ToList();
        }
    }
}
