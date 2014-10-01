using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.Models;

namespace KeyRequest.DAL
{
    public interface IKeyRepository : IDisposable
    {
        IEnumerable<Key> GetAll();
        IQueryable<Key> Get();
        Key GetByID(int keyID);
        void Insert(Key key);
        void Update(Key key);
        void Delete(Key key);
        void SaveForRoom(int roomID, IEnumerable<Key> keys);
    }
}