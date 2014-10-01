using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyRequest.DAL.Implementation
{
    public abstract class BaseRepository : IDisposable
    {
        protected KeyRequestContext context;
        protected bool disposed = false;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                context.Dispose();
            }
            this.disposed = true;
        }
    }
}