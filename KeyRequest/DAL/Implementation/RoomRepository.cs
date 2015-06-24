using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KeyRequest.Models;

namespace KeyRequest.DAL.Implementation
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(KeyRequestContext context) 
        {
            this.context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public IQueryable<Room> Get()
        {
            return context.Rooms;
        }

        public Room GetByID(int roomID)
        {
            return context.Rooms.Find(roomID);
        }

        public void Insert(Room room)
        {
            context.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            context.Entry(room).State = EntityState.Modified;
        }

        public void Delete(int roomID)
        {
            Room room = GetByID(roomID);
            context.Rooms.Remove(room);
        }
    }
}