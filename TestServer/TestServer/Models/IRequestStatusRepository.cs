using System.Collections.Generic;

namespace TestServer.Models
{
    public interface IRequestStatusRepository
    {
        void Add(RequestStatus heartbeat);
        IEnumerable<RequestStatus> GetAll();
        RequestStatus Find(long key);
    }
}
