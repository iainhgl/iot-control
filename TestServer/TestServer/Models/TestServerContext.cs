using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public class TestServerContext : DbContext
    {
        public TestServerContext(DbContextOptions<TestServerContext> options)
            : base (options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<RequestStatus> Statuses { get; set; }
        public DbSet<Heartbeat> Heartbeats { get; set; }
    }
}
