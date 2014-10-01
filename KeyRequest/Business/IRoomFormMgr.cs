using System;
using System.Collections.Generic;
using KeyRequest.ViewModels;

namespace KeyRequest.Business
{
    public interface IRoomFormMgr : IDisposable
    {
        IEnumerable<RoomForm> GetAll();
        RoomForm Create(bool dataentry = false);
        RoomForm Get(int id, bool dataentry = false);

        void RefreshForDataEntry(RoomForm roomForm);

        void Save(RoomForm roomForm);        
        void Delete(RoomForm roomForm);
    }
}
