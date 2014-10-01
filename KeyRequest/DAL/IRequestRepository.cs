using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;
using System.Data.Entity;

namespace KeyRequest.DAL
{
    public interface IRequestRepository : IDisposable
    {
        IEnumerable<Request> GetAll();
        IQueryable<Request> Get();
        Request GetByID(int requestID);
        void Insert(Request request);
        void Update(Request request);
        void Delete(int requestID);
    }
}