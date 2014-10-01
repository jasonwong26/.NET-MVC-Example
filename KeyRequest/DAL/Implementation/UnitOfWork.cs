using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyRequest.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private KeyRequestContext context = new KeyRequestContext();
        private bool disposed = false;

        private RequestRepository _RequestRepository;
        private RequestSetRepository _RequestSetRepository;
        private RoomRepository _RoomRepository;
        private KeyRepository _KeyRepository;

        public IRequestRepository RequestRepository
        {
            get {
                if (_RequestRepository == null)
                {
                    _RequestRepository = new RequestRepository(context);
                }
                return _RequestRepository;
            }
        }

        public IRequestSetRepository RequestSetRepository
        {
            get
            {
                if (_RequestSetRepository == null)
                {
                    _RequestSetRepository = new RequestSetRepository(context);
                }
                return _RequestSetRepository;
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                if (_RoomRepository == null)
                {
                    _RoomRepository = new RoomRepository(context);
                }
                return _RoomRepository;
            }
        }

        public IKeyRepository KeyRepository
        {
            get
            {
                if (_KeyRepository == null)
                {
                    _KeyRepository = new KeyRepository(context);
                }
                return _KeyRepository;
            }
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                context.Dispose();
            }
            this.disposed = true;
        }
    }
}