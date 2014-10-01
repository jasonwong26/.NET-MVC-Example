using System.Collections.Generic;
using System.Web.Mvc;
using KeyRequest.Business;
using KeyRequest.ViewModels;

namespace KeyRequest.Controllers
{
    public class RequestReportController : Controller
    {
        private IRequestReportMgr reportMgr = RequestReportFactory.GetDefault();

        //
        // GET: /RequestReport/
        public ActionResult Index()
        {
            IEnumerable<RequestReport> report = reportMgr.GetAll();

            return View(report);
        }

        protected override void Dispose(bool disposing)
        {
            reportMgr.Dispose();
            base.Dispose(disposing);
        }
    }
}
