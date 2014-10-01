using System.Collections.Generic;
using KeyRequest.DAL;
using KeyRequest.Mapping;
using KeyRequest.Models;
using KeyRequest.ViewModels;

namespace KeyRequest.Business.Implementation
{
    public class RequestReportMgr : BaseFormMgr, IRequestReportMgr
    {
        public RequestReportMgr(IUnitOfWork unitofwork)
        {
            this.uw = unitofwork;
        }

        public IEnumerable<RequestReport> GetAll() 
        {
            List<RequestReport> report = new List<RequestReport>();
            foreach (Key k in uw.KeyRepository.GetAll())
            {
                report.Add(Mapper.Map<RequestReport, Key>(k));
            }

            return report;
        }
    }
}