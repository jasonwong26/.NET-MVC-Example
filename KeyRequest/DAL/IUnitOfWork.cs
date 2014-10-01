using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyRequest.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRequestRepository RequestRepository { get; }
        IRequestSetRepository RequestSetRepository { get; }
        IRoomRepository RoomRepository { get; }
        IKeyRepository KeyRepository { get; }

        void SaveChanges();
    }
}
