using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;
using System;

namespace KeyRequest.Business.Implementation
{
    public class RequestFormMgr : BaseFormMgr, IRequestFormMgr
    {
        private const int MAXROOMS = 5;

        public RequestFormMgr(IUnitOfWork unitofwork)
        {
            this.uw = unitofwork;
        }

        public IEnumerable<RequestForm> GetAll()
        { 
            List<RequestForm> forms = new List<RequestForm>();
            foreach (Request r in uw.RequestRepository.GetAll())
            {
                forms.Add(Mapper.Map<RequestForm, Request>(r));
            }

            return forms;
        }

        /// <summary>
        /// Constructs Empty ViewModel, including creation of placeholder RequestSetForm objects to populate web form
        /// </summary>
        public RequestForm Create(bool dataentry = false)
        {
            RequestForm result = new RequestForm();
            result.RequestDate = DateTime.Today;

            result.Sets = new List<RequestSetForm>();

            if (dataentry)
            {
                RefreshForDataEntry(result);
            }

            return result;
        }

        /// <summary>
        /// Retrieves Mapped Model from Repository and constructs ViewModel.  Including creation of placeholder RequestSetForm objects to populate web form
        /// </summary>
        public RequestForm Get(int id, bool dataentry = false)
        {
            Request request = uw.RequestRepository.Get().Include(x => x.KeySets).SingleOrDefault(x => x.RequestID == id);
            RequestForm result = Mapper.Map<RequestForm, Request>(request);

            if (dataentry)
            {
                RefreshForDataEntry(result);
            }

            return result;
        }

        public void RefreshForDataEntry(RequestForm requestForm)
        {
            AppendPlaceHolderKeys(requestForm);
            PopulateSelectLists(requestForm);
        }

        public void Save(RequestForm requestForm)
        {
            CleanRequestForm(requestForm);
            Request request = Mapper.Map<Request, RequestForm>(requestForm);

            if (request.RequestID == 0) {
                uw.RequestRepository.Insert(request);
            }
            else {
                uw.RequestRepository.Update(request);
            }

            uw.RequestSetRepository.SaveForRequest(request.RequestID, request.KeySets);
            uw.SaveChanges();
        }

        public void Delete(RequestForm requestForm)
        {
            CleanRequestForm(requestForm);
            Request request = Mapper.Map<Request, RequestForm>(requestForm);

            uw.RequestRepository.Delete(request.RequestID);
            uw.SaveChanges();
        }

        #region Helper Methods
        private void AppendPlaceHolderKeys(RequestForm requestForm)
        {
            while (requestForm.Sets.Count < MAXROOMS)
            {
                requestForm.Sets.Add(new RequestSetForm
                {
                    RequestFormID = requestForm.RequestFormID
                });
            }
        }

        private void PopulateSelectLists(RequestForm requestform)
        {
            foreach (RequestSetForm rs in requestform.Sets)
            {
                rs.RoomList = GetRoomSelectList(rs.RoomID.GetValueOrDefault(0));
            }
        }

        private SelectList GetRoomSelectList(int id)
        {
            var rooms = uw.RoomRepository.Get().Where(r => r.Available);
            return new SelectList(rooms.ToList(), "RoomID", "Description", id);
        }

        //TODO: Refactor to remove need for this function
        private RequestForm CleanRequestForm(RequestForm requestform)
        {
            List<RequestSetForm> sets = requestform.Sets;

            for (int i = sets.Count - 1; i >= 0; i--)
            {
                if (sets[i].RoomID.GetValueOrDefault(0) == 0)
                {
                    sets.Remove(sets[i]);
                }
            }

            requestform.Sets = sets;
            return requestform;
        }
        #endregion
    }
}