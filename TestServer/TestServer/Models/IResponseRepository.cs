using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestServer.Models
{
    public interface IResponseRepository
    {
        void Add(Response response);
        IEnumerable<long> GetAll();
        Response Find(long key);
        Response FindByRequestId(string responseId);
        void Remove(long key);
        void RemoveByRequestId(string responseId);
        void Update(Response response);
    }
}
