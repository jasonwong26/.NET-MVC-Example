using KeyRequest.Business.Implementation;
using KeyRequest.DAL;

namespace KeyRequest.Business
{
    public static class RequestReportFactory
    {
        public static IRequestReportMgr GetDefault()
        { 
            return new RequestReportMgr(UnitOfWorkFactory.GetDefault());
        }
    }
}