using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KeyRequest.DAL.Implementation;

namespace KeyRequest.DAL
{
    public static class UnitOfWorkFactory
    {
        public static IUnitOfWork GetDefault()
        {
            return new UnitOfWork();
        }
    }
}