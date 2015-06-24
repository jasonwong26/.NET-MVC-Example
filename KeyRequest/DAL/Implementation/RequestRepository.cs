using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;
using System.Data.Entity;

namespace KeyRequest.DAL.Implementation
{
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public RequestRepository(KeyRequestContext context)
        {
            this.context = context;
        }

        public IEnumerable<Request> GetAll()
        {
            return context.Requests.ToList();
        }

        public IQueryable<Request> Get()
        {
            return context.Requests;
        }

        public Request GetByID(int requestID)
        {
            return context.Requests.Find(requestID);
        }

        public void Insert(Request request)
        {
            context.Requests.Add(request);
        }

        public void Update(Request request)
        {
            context.Entry(request).State = EntityState.Modified;
        }

        public void Delete(int requestID)
        {
            Request request = GetByID(requestID);
            context.Requests.Remove(request);
        }
    }
}