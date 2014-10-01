using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KeyRequest.Models;

namespace KeyRequest.DAL
{
    public class KeyRequestContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSet> RequestSets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Key> Keys { get; set; }
    }
}