using System.Collections.Generic;

namespace TestServer.Models
{
    public interface IRequestRepository
    {
        void Add(Request request);
        IEnumerable<long> GetAll();
        IEnumerable<long> GetAllForDestination(string destinationId);
        Request Find(long key);
        Request FindByRequestId(string requestId);
        void Remove(long key);
        void RemoveByRequestId(string requestId);
        void Update(Request request);
    }
}
