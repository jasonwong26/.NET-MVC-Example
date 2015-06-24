using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KeyRequest.Models;

namespace KeyRequest.DAL
{
    public class KeyRequestContext : DbContext
    {
        public KeyRequestContext() : base("KeyRequestContext")
        {         
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSet> RequestSets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Key> Keys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}