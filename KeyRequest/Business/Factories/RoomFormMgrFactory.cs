using KeyRequest.Business.Implementation;
using KeyRequest.DAL;

namespace KeyRequest.Business
{
    public static class RoomFormMgrFactory
    {
        public static IRoomFormMgr GetDefault()
        {
            return new RoomFormMgr(UnitOfWorkFactory.GetDefault());
        }
    }
}