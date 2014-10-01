using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.DAL;

namespace KeyRequest.Business.Implementation
{
    public abstract class BaseFormMgr : IDisposable
    {
        protected IUnitOfWork uw;
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
                uw.Dispose();
            }
            this.disposed = true;
        }
    }
}