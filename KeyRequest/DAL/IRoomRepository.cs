using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;

namespace KeyRequest.DAL
{
    public interface IRoomRepository : IDisposable
    {
        IEnumerable<Room> GetAll();
        IQueryable<Room> Get();
        Room GetByID(int roomID);
        void Insert(Room room);
        void Update(Room room);
        void Delete(int roomID);
    }
}