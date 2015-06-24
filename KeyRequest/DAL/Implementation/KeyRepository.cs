using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KeyRequest.Models;

namespace KeyRequest.DAL.Implementation
{
    public class KeyRepository : BaseRepository, IKeyRepository
    {
        public KeyRepository(KeyRequestContext context)
        {
            this.context = context;
        }

        public IEnumerable<Key> GetAll()
        {
            return context.Keys.ToList();
        }

        public IQueryable<Key> Get()
        {
            return context.Keys;
        }

        public Key GetByID(int keyID)
        {
            return context.Keys.Find(keyID);
        }

        public void Insert(Key key)
        {
            context.Keys.Add(key);
        }

        public void Update(Key key)
        {
            context.Entry(key).State = EntityState.Modified;
        }

        public void Delete(Key key)
        {
            context.Keys.Remove(key);
        }

        public void SaveForRoom(int roomID, IEnumerable<Key> keys)
        {
            List<Key> currentRecords = context.Keys.Where(k => k.RoomID == roomID).ToList();

            // Compare current and parameter lists and create lists for appropriate actions
            List<Key> toDelete = currentRecords.Except(keys).ToList();
            List<Key> toUpdate = currentRecords.Intersect(keys).ToList();
            List<Key> toInsert = keys.Except(currentRecords).ToList();

            foreach (Key k in toDelete)
            {
                Delete(k);
            }

            foreach (Key k in toUpdate)
            {
                Update(k);
            }

            foreach (Key k in toInsert)
            {
                Insert(k);
            }
        }
    }
}