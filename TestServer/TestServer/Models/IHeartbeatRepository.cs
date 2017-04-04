using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public interface IHeartbeatRepository
    {
        void Add(Heartbeat heartbeat);
        IEnumerable<Heartbeat> GetAll();
        Heartbeat Find(long key);
        void Clear();
    }
}
