using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace KeyRequest.ViewModels
{
    public class RoomForm
    {
        public int RoomFormID { get; set; }

        [StringLength(50, ErrorMessage = "Description cannot be more than 50 characters.")]
        [RegularExpression(@"^[\w\s]+$")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "Location cannot be more than 50 characters.")]
        [RegularExpression(@"^[\w\s]+$")]
        public string Location { get; set; }

        public bool Available { get; set; }

        public List<KeyForm> Keys { get; set; }
    }

    //public class RoomFormMgr_OLD
    //{
    //    private const int MAXKEYS = 5;

    //    private IUnitOfWork uw;

    //    public RoomFormMgr_OLD(IUnitOfWork unitofwork) :
    //        this(unitofwork, null){}

    //    public RoomFormMgr_OLD(IUnitOfWork unitofwork, RoomForm roomform)
    //    {
    //        this.uw = unitofwork;
    //        this.RoomForm = roomform;
    //    }

    //    public RoomForm RoomForm { get; private set; }
    //    public int MaxRooms { get { return MAXKEYS; } }

    //    /// <summary>
    //    ///  Queries Repository and returns collection of ViewModel objects
    //    /// </summary>
    //    public IEnumerable<RoomForm> GetRoomList()
    //    {
    //        IEnumerable<Room> rooms = uw.RoomRepository.GetAll();
    //        List<RoomForm> forms = new List<RoomForm>();
    //        foreach (Room r in uw.RoomRepository.GetAll())
    //        {
    //            forms.Add(Mapper.Map<RoomForm, Room>(r));
    //        }

    //        return forms;
    //    }

    //    /// <summary>
    //    /// Constructs Empty ViewModel, including creation of placeholder KeyForm objects to populate web form
    //    /// </summary>
    //    public void CreateRoomForm(bool dataentry = false)
    //    {
    //        RoomForm = new RoomForm();
    //        RoomForm.Available = true;

    //        RoomForm.Keys = new List<KeyForm>();

    //        if (dataentry)
    //        {
    //            AppendPlaceHolderKeys(RoomForm);
    //            PopulateSelectLists();
    //        }
    //    }

    //    /// <summary>
    //    /// Retrieves Mapped Model from Repository and constructs ViewModel.  Including creation of placeholder KeyForm objects to populate web form
    //    /// </summary>
    //    /// <param name="id"></param>
    //    public void GetRequestForm(int id, bool dataentry = false)
    //    {
    //        Room room = uw.RoomRepository.Get().Include(x => x.Keys).SingleOrDefault(x => x.RoomID == id);
    //        RoomForm = Mapper.Map<RoomForm, Room>(room);

    //        if (dataentry)
    //        {
    //            AppendPlaceHolderKeys(RoomForm);
    //            PopulateSelectLists();
    //        }
    //    }

    //    public void SaveRoomForm()
    //    {
    //        CleanRoomForm(RoomForm);
    //        Room room = Mapper.Map<Room, RoomForm>(RoomForm);

    //        if (room.RoomID == 0)
    //        {
    //            uw.RoomRepository.Insert(room);
    //        }
    //        else
    //        {
    //            uw.RoomRepository.Update(room);
    //        }

    //        uw.KeyRepository.SaveForRoom(room.RoomID, room.Keys);
    //        uw.SaveChanges();
    //    }

    //    public void DeleteRoomForm()
    //    {
    //        CleanRoomForm(RoomForm);
    //        Room room = Mapper.Map<Room, RoomForm>(RoomForm);

    //        uw.RoomRepository.Delete(room.RoomID);
    //        uw.SaveChanges();
    //    }

    //    public void PopulateSelectLists()
    //    {
    //        foreach (KeyForm rs in RoomForm.Keys)
    //        {
    //            rs.RoomList = GetRoomSelectList(rs.RoomFormID.GetValueOrDefault(0));
    //        }
    //    }

    //    #region Helper Methods
    //    private void AppendPlaceHolderKeys(RoomForm roomform)
    //    {
    //        while (roomform.Keys.Count < MAXKEYS)
    //        {
    //            roomform.Keys.Add(new KeyForm
    //            {
    //                RoomFormID = roomform.RoomFormID
    //            });
    //        }
    //    }

    //    private SelectList GetRoomSelectList(int id)
    //    {
    //        var rooms = uw.RoomRepository.Get().Where(r => r.Available);
    //        return new SelectList(rooms.ToList(), "RoomID", "Description", id);
    //    }

    //    //TODO: Refactor to remove need for this function
    //    private void CleanRoomForm(RoomForm roomform)
    //    {
    //        List<KeyForm> keys = roomform.Keys.ToList();

    //        for (int i = keys.Count - 1; i >= 0; i--)
    //        {
    //            if (keys[i].RoomFormID.GetValueOrDefault(0) == 0)
    //            {
    //                keys.Remove(keys[i]);
    //            }
    //        }

    //        roomform.Keys = keys;
    //        RoomForm = roomform;
    //    }
    //    #endregion


    //}
}