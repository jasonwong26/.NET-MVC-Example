using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Business.Implementation
{
    public class RoomFormMgr : BaseFormMgr, IRoomFormMgr
    {
        private const int MAXKEYS = 5;

        public RoomFormMgr(IUnitOfWork unitofwork)
        {
            this.uw = unitofwork;
        }

        public IEnumerable<RoomForm> GetAll()
        {
            List<RoomForm> forms = new List<RoomForm>();
            foreach (Room r in uw.RoomRepository.GetAll())
            {
                forms.Add(Mapper.Map<RoomForm, Room>(r));
            }

            return forms;
        }

        /// <summary>
        /// Constructs Empty ViewModel, including creation of placeholder KeyForm objects to populate web form
        /// </summary>
        public RoomForm Create(bool dataentry = false)
        {
            RoomForm result = new RoomForm();
            result.Available = true;
            result.Keys = new List<KeyForm>();

            if (dataentry)
            {
                RefreshForDataEntry(result);
            }

            return result;
        }

        /// <summary>
        /// Retrieves Mapped Model from Repository and constructs ViewModel.  Including creation of placeholder KeyForm objects to populate web form
        /// </summary>
        public RoomForm Get(int id, bool dataentry = false)
        {
            Room room = uw.RoomRepository.Get().Include(x => x.Keys).SingleOrDefault(x => x.RoomID == id);
            RoomForm result = Mapper.Map<RoomForm, Room>(room);

            if (dataentry)
            {
                RefreshForDataEntry(result);
            }

            return result;
        }

        public void RefreshForDataEntry(RoomForm roomForm)
        {
            AppendPlaceHolderKeys(roomForm);
            //PopulateSelectLists(roomForm);
        }

        public void Save(RoomForm roomForm)
        {
            CleanRoomForm(roomForm);
            Room room = Mapper.Map<Room, RoomForm>(roomForm);

            if (room.RoomID == 0)
            {
                uw.RoomRepository.Insert(room);
            }
            else
            {
                uw.RoomRepository.Update(room);
            }

            uw.KeyRepository.SaveForRoom(room.RoomID, room.Keys);
            uw.SaveChanges();
        }

        public void Delete(RoomForm roomForm)
        {
            CleanRoomForm(roomForm);
            Room room = Mapper.Map<Room, RoomForm>(roomForm);

            uw.RoomRepository.Delete(room.RoomID);
            uw.SaveChanges();
        }

        #region Helper Methods
        private void AppendPlaceHolderKeys(RoomForm roomform)
        {
            while (roomform.Keys.Count < MAXKEYS)
            {
                roomform.Keys.Add(new KeyForm
                {
                    RoomFormID = roomform.RoomFormID
                });
            }
        }

        //private void PopulateSelectLists(RoomForm roomform)
        //{
        //    foreach (KeyForm rs in roomform.Keys)
        //    {
        //        rs.RoomList = GetRoomSelectList(rs.RoomFormID.GetValueOrDefault(0));
        //    }
        //}

        //private SelectList GetRoomSelectList(int id)
        //{
        //    var rooms = uw.RoomRepository.Get().Where(r => r.Available);
        //    return new SelectList(rooms.ToList(), "RoomID", "Description", id);
        //}

        //TODO: Refactor to remove need for this function
        private RoomForm CleanRoomForm(RoomForm roomform)
        {
            List<KeyForm> keys = roomform.Keys;

            for (int i = keys.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrEmpty(keys[i].Tag))
                {
                    keys.Remove(keys[i]);
                }
            }

            roomform.Keys = keys;
            return roomform;
        }
        #endregion
    }
}