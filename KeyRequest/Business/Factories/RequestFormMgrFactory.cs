using KeyRequest.Business.Implementation;
using KeyRequest.DAL;

namespace KeyRequest.Business
{
    public class RequestFormMgrFactory
    {
        public static IRequestFormMgr GetDefault()
        {
            return new RequestFormMgr(UnitOfWorkFactory.GetDefault());
        }
    }
}