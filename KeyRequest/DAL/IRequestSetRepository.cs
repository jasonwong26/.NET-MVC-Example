using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyRequest.Models;

namespace KeyRequest.DAL
{
    public interface IRequestSetRepository : IDisposable
    {
        IEnumerable<RequestSet> GetAll();
        IQueryable<RequestSet> Get();
        IEnumerable<RequestSet> GetByRequestID(int requestID);
        void Insert(RequestSet requestSet);
        void Update(RequestSet requestSet);
        void Delete(RequestSet requestSet);
        void SaveForRequest(int requestID, IEnumerable<RequestSet> requestSets);
    }
}
