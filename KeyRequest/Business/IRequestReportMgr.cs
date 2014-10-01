using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyRequest.ViewModels;

namespace KeyRequest.Business
{
    public interface IRequestReportMgr : IDisposable
    {
        IEnumerable<RequestReport> GetAll();
    }
}
