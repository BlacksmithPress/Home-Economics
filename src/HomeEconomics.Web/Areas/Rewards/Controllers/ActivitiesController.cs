using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Web.Areas.Rewards.Models;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class ActivitiesController : Controller
    {
        private IDatabase _database;

        public ActivitiesController(IDatabase database)
        {
            _database = database;
        }

        // GET: Activities/Activities
        public virtual ActionResult Index()
        {
            return View(_database.Activities.Documents);
        }

        // GET: Activities/Activities/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Activity = _database.Activities.Retrieve(id.Value);
            if (Activity == null)
            {
                return HttpNotFound();
            }
            return View(Activity);
        }

        // GET: Activities/Activities/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Activities/Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(ActivityCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _database.Activities.Create(model.Entity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Activities/Activities/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Activities.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Activities/Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(ActivityUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _database.Activities.Update(model.Entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Activities/Activities/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Activities.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Activities/Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            _database.Activities.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
