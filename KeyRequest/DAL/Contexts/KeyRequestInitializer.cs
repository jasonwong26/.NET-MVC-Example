using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace KeyRequest.DAL
{
    public class KeyRequestInitializer : DropCreateDatabaseIfModelChanges<KeyRequestContext>
    {
        protected override void Seed(KeyRequestContext context)
        {
            var rooms = new List<Room> {
                new Room { Description = "Conference Room A", Location = "113A", Available = true },
                new Room { Description = "Conference Room B", Location = "117B", Available = true },
                new Room { Description = "Conference Room C", Location = "183C", Available = true },
                new Room { Description = "Office A", Location = "77", Available = true },
                new Room { Description = "Office B", Location = "46", Available = true },
                new Room { Description = "Office C", Location = "92", Available = true },
                new Room { Description = "Janitor's Closet", Location = "101", Available = false }
            };

            rooms.ForEach(r => context.Rooms.AddOrUpdate(c => c.Location, r));
            context.SaveChanges();

            var keys = new List<Key> {
                new Key { Tag = "Cabinet", RoomID = rooms.Single(r => r.Location == "113A").RoomID },
                new Key { Tag = "Door", RoomID = rooms.Single(r => r.Location == "113A").RoomID },
                new Key { Tag = "Cabinet A", RoomID = rooms.Single(r => r.Location == "117B").RoomID },
                new Key { Tag = "Cabinet B", RoomID = rooms.Single(r => r.Location == "117B").RoomID },
                new Key { Tag = "Door", RoomID = rooms.Single(r => r.Location == "117B").RoomID },
                new Key { Tag = "Door", RoomID = rooms.Single(r => r.Location == "183C").RoomID },
                new Key { Tag = "Door", RoomID = rooms.Single(r => r.Location == "77").RoomID },
                new Key { Tag = "Desk", RoomID = rooms.Single(r => r.Location == "77").RoomID },
                new Key { Tag = "Door", RoomID = rooms.Single(r => r.Location == "46").RoomID },
                new Key { Tag = "Desk", RoomID = rooms.Single(r => r.Location == "46").RoomID },
                new Key { Tag = "Door", RoomID = rooms.Single(r => r.Location == "92").RoomID },
                new Key { Tag = "Desk", RoomID = rooms.Single(r => r.Location == "92").RoomID },
                new Key { Tag = "Cabinet", RoomID = rooms.Single(r => r.Location == "92").RoomID },
                new Key { Tag = "Skeleton Key", RoomID = rooms.Single(r => r.Location == "101").RoomID }
            };

            keys.ForEach(k => context.Keys.AddOrUpdate(c => new { c.Tag, c.RoomID }, k));
            context.SaveChanges();

            var requests = new List<Request> {
                new Request { EmployeeNo = "32N211", FirstName = "John", LastName = "Doe", RequestDate = DateTime.Parse("03/15/2014") },
                new Request { EmployeeNo = "5461DD", FirstName = "John", LastName = "Doe", RequestDate = DateTime.Parse("07/09/2014") },
                new Request { EmployeeNo = "971SDF", FirstName = "Jane", LastName = "Doe", RequestDate = DateTime.Parse("11/16/2013") }
            };

            requests.ForEach(r => context.Requests.AddOrUpdate(c => new { c.EmployeeNo, c.RequestDate }, r));
            context.SaveChanges();

            var requestSets = new List<RequestSet> {
                new RequestSet { RequestID = requests.Single(s => s.EmployeeNo == "32N211" && s.RequestDate == DateTime.Parse("03/15/2014")).RequestID, 
                                 RoomID = rooms.Single(s => s.Location == "113A").RoomID, 
                                 Sets = 1 },
                new RequestSet { RequestID = requests.Single(s => s.EmployeeNo == "32N211" && s.RequestDate == DateTime.Parse("03/15/2014")).RequestID, 
                                 RoomID = rooms.Single(s => s.Location == "77").RoomID, 
                                 Sets = 2 },
                new RequestSet { RequestID = requests.Single(s => s.EmployeeNo == "5461DD" && s.RequestDate == DateTime.Parse("07/09/2014")).RequestID, 
                                 RoomID = rooms.Single(s => s.Location == "117B").RoomID, 
                                 Sets = 1 },
                new RequestSet { RequestID = requests.Single(s => s.EmployeeNo == "5461DD" && s.RequestDate == DateTime.Parse("07/09/2014")).RequestID, 
                                 RoomID = rooms.Single(s => s.Location == "46").RoomID, 
                                 Sets = 2 },
                new RequestSet { RequestID = requests.Single(s => s.EmployeeNo == "971SDF" && s.RequestDate == DateTime.Parse("11/16/2013")).RequestID, 
                                 RoomID = rooms.Single(s => s.Location == "183C").RoomID, 
                                 Sets = 1 },
                new RequestSet { RequestID = requests.Single(s => s.EmployeeNo == "971SDF" && s.RequestDate == DateTime.Parse("11/16/2013")).RequestID, 
                                 RoomID = rooms.Single(s => s.Location == "92").RoomID, 
                                 Sets = 3 }
            };

            requestSets.ForEach(r => context.RequestSets.AddOrUpdate(c => new { c.RequestID, c.RoomID }, r));
            context.SaveChanges();
        }

    }
}