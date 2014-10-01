using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;

namespace KeyRequest.ViewModels
{
    public class RequestForm
    {
        public int RequestFormID { get; set; }
        
        [Display(Name="Employee Number")]
        [StringLength(20, ErrorMessage = "Employee Number cannot be more than 20 characters.")]
        [RegularExpression(@"^\w+$")]
        public string EmployeeNo { get; set; }

        [Display(Name="Last Name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string FirstName { get; set; }

        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }

        public List<RequestSetForm> Sets{ get; set; }
    }

    //public class RequestFormMgr
    //{
    //    private const int MAXROOMS = 5;
        
    //    private IUnitOfWork uw;

    //    public RequestFormMgr(IUnitOfWork unitofwork) :
    //        this(unitofwork, null){}

    //    public RequestFormMgr(IUnitOfWork unitofwork, RequestForm requestform)
    //    {
    //        this.uw = unitofwork;
    //        this.RequestForm = requestform;
    //    }
        
    //    public RequestForm RequestForm { get; private set; }
    //    public int MaxRooms { get { return MAXROOMS; } }

    //    /// <summary>
    //    /// Constructs Empty ViewModel, including creation of placeholder KeySet objects to populate web form
    //    /// </summary>
    //    public void CreateRequestForm(bool dataentry = false)
    //    {
    //        RequestForm = new RequestForm();
    //        RequestForm.RequestDate = DateTime.Today;

    //        RequestForm.Sets = new List<RequestSetForm>();

    //        if (dataentry)
    //        {
    //            AppendPlaceHolderKeySets(RequestForm);
    //            PopulateSelectLists();
    //        }
    //    }

    //    /// <summary>
    //    /// Retrieves Mapped Model from Repository and constructs ViewModel.  Including creation of placeholder KeySet objects to populate web form
    //    /// </summary>
    //    /// <param name="id"></param>
    //    public void GetRequestForm(int id, bool dataentry=false)
    //    {
    //        Request request = uw.RequestRepository.Get().Include(x => x.KeySets).SingleOrDefault(x => x.RequestID == id);
    //        RequestForm = Mapper.Map<RequestForm, Request>(request);

    //        if (dataentry)
    //        {
    //            AppendPlaceHolderKeySets(RequestForm);
    //            PopulateSelectLists();
    //        }
    //    }

    //    public void SaveRequestForm()
    //    {
    //        CleanRequestForm(RequestForm);
    //        Request request = Mapper.Map<Request, RequestForm>(RequestForm);

    //        if (request.RequestID == 0) {
    //            uw.RequestRepository.Insert(request);
    //        }
    //        else {
    //            uw.RequestRepository.Update(request);
    //        }

    //        uw.RequestSetRepository.SaveForRequest(request.RequestID, request.KeySets);
    //        uw.SaveChanges();
    //    }

    //    public void DeleteRequestForm()
    //    {
    //        CleanRequestForm(RequestForm);
    //        Request request = Mapper.Map<Request, RequestForm>(RequestForm);

    //        uw.RequestRepository.Delete(request.RequestID);
    //        uw.SaveChanges();
    //    }

    //    public void PopulateSelectLists()
    //    {
    //        foreach (RequestSetForm rs in RequestForm.Sets)
    //        { 
    //            rs.RoomList = GetRoomSelectList(rs.RoomID.GetValueOrDefault(0));
    //        }
    //    }

    //    #region Helper Methods
    //    private void AppendPlaceHolderKeySets(RequestForm requestform)
    //    {
    //        while (requestform.Sets.Count < MAXROOMS)
    //        {
    //            requestform.Sets.Add(new RequestSetForm
    //            {
    //                RequestFormID = requestform.RequestFormID
    //            });
    //        }
    //    }

    //    private SelectList GetRoomSelectList(int id)
    //    {
    //        var rooms = uw.RoomRepository.Get().Where(r => r.Available);
    //        return new SelectList(rooms.ToList(), "RoomID", "Description", id);
    //    }

    //    //TODO: Refactor to remove need for this function
    //    private void CleanRequestForm(RequestForm requestform)
    //    {
    //        for (int i = requestform.Sets.Count - 1; i >= 0; i--)
    //        {
    //            if (requestform.Sets[i].RoomID.GetValueOrDefault(0) == 0)
    //            {
    //                requestform.Sets.Remove(requestform.Sets[i]);
    //            }
    //        }

    //        RequestForm = requestform;
    //    }
    //    #endregion
    //}
}