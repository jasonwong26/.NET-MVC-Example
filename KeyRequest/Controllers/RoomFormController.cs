using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using KeyRequest.Business;
using KeyRequest.ViewModels;


namespace KeyRequest.Controllers
{
    public class RoomFormController : Controller
    {
        private IRoomFormMgr formMgr = RoomFormMgrFactory.GetDefault();

        //
        // GET: /RoomForm/

        public ActionResult Index()
        {
            IEnumerable<RoomForm> forms = formMgr.GetAll();

            return View(forms);
        }

        //
        // GET: /RoomForm/Details/5

        public ActionResult Details(int id)
        {
            RoomForm form = formMgr.Get(id);

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // GET: /RoomForm/Create

        public ActionResult Create()
        {
            RoomForm form = formMgr.Create(true);

            return View(form);
        } 

        //
        // POST: /RoomForm/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "Description, Location, Available, Keys")]
            RoomForm roomForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    formMgr.Save(roomForm);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again, and if the problem persists contact IT.");
            }

            formMgr.RefreshForDataEntry(roomForm);
            return View(roomForm);
        }
        
        //
        // GET: /RoomForm/Edit/5
 
        public ActionResult Edit(int id)
        {
            RoomForm form = formMgr.Get(id, true);

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // POST: /RoomForm/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "RoomFormID, Description, Location, Available, Keys")]
            RoomForm roomForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    formMgr.Save(roomForm);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again, and if the problem persists contact IT.");
            }

            formMgr.RefreshForDataEntry(roomForm);
            return View(roomForm);
        }

        //
        // GET: /RoomForm/Delete/5

        public ActionResult Delete(bool? saveChangesError, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Please try again, and if the problem persists contact IT.";
            }

            RoomForm form = formMgr.Get(id);

            if (form == null)
            {
                return HttpNotFound();
            }

            return View(form);
        }

        //
        // POST: /RoomForm/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                RoomForm form = formMgr.Get(id);
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
