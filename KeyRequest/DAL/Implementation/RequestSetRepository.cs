using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;

namespace KeyRequest.DAL.Implementation
{
    public class RequestSetRepository : BaseRepository, IRequestSetRepository
    {
        public RequestSetRepository(KeyRequestContext context)
        {
            this.context = context;
        }

        public IEnumerable<RequestSet> GetAll()
        {
            return context.RequestSets.ToList();
        }

        public IQueryable<RequestSet> Get()
        {
            return context.RequestSets;
        }

        public IEnumerable<RequestSet> GetByRequestID(int requestID)
        {
            return context.RequestSets.Where(rs => rs.RequestID == requestID).ToList();
        }

        public void Insert(RequestSet requestSet)
        {
            context.RequestSets.Add(requestSet);
        }

        public void Update(RequestSet requestSet)
        {
            context.Entry(requestSet).State = System.Data.EntityState.Modified;
        }

        public void Delete(RequestSet requestSet)
        {
            context.RequestSets.Remove(requestSet);
        }

        public void SaveForRequest(int requestID, IEnumerable<RequestSet> requestSets)
        {
            List<RequestSet> currentRecords = context.RequestSets.Where(rs => rs.RequestID == requestID).ToList();
            
            // Compare current and parameter lists and create lists for appropriate actions
            List<RequestSet> toDelete = currentRecords.Except(requestSets).ToList();
            List<RequestSet> toUpdate = currentRecords.Intersect(requestSets).ToList();
            List<RequestSet> toInsert = requestSets.Except(currentRecords).ToList();

            foreach(RequestSet rs in toDelete)
            {
                Delete(rs);
            }
            
            foreach(RequestSet rs in toUpdate)
            {
                Update(rs);
            }
            
            foreach(RequestSet rs in toInsert)
            {
                Insert(rs);
            }
        }
    }
}