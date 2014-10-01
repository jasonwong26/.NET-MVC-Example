using System;
using System.Collections.Generic;
using KeyRequest.ViewModels;

namespace KeyRequest.Business
{
    public interface IRequestFormMgr : IDisposable
    {
        IEnumerable<RequestForm> GetAll();
        RequestForm Create(bool dataentry = false);
        RequestForm Get(int id, bool dataentry = false);

        void RefreshForDataEntry(RequestForm requestForm);

        void Save(RequestForm requestForm);
        void Delete(RequestForm requestForm);
    }
}
