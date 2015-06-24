using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using KeyRequest.Business;
using KeyRequest.ViewModels;

namespace KeyRequest.Controllers
{
    public class RequestFormController : Controller
    {
        private IRequestFormMgr formMgr = RequestFormMgrFactory.GetDefault();
        
        //
        // GET: /RequestForm/
        public ActionResult Index()
        {
            IEnumerable<RequestForm> forms = formMgr.GetAll();

            return View(forms);
        }

        //
        // GET: /RequestForm/Details/
        public ActionResult Details(int id)
        {
            RequestForm form = formMgr.Get(id);

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // GET: /RequestForm/Create
        public ActionResult Create()
        {
            RequestForm form = formMgr.Create(true);

            return View(form);
        } 

        //
        // POST: /RequestForm/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "EmployeeNo, LastName, FirstName, RequestDate, Sets")]
            RequestForm requestForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    formMgr.Save(requestForm);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again, and if the problem persists contact IT.");
            }

            formMgr.RefreshForDataEntry(requestForm);
            return View(requestForm);
        }
        
        //
        // GET: /RequestForm/Edit/
        public ActionResult Edit(int id)
        {
            RequestForm form = formMgr.Get(id, true);

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // POST: /RequestForm/Edit/
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "RequestFormID, EmployeeNo, LastName, FirstName, RequestDate, Sets")]
            RequestForm requestForm)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    formMgr.Save(requestForm);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again, and if the problem persists contact IT.");
            }

            formMgr.RefreshForDataEntry(requestForm);
            return View(requestForm);
        }

        //
        // GET: /RequestForm/Delete/5

        public ActionResult Delete(bool? saveChangesError, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            RequestForm form = formMgr.Get(id);

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                RequestForm form = formMgr.Get(id);
                formMgr.Delete(form);
            }
            catch (DataException /*dex*/)
            {
                return RedirectToAction("Delete", new { saveChangesError = true, id = id });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            formMgr.Dispose();
            base.Dispose(disposing);
        }
    }
}
