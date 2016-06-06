using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Web.Areas.People.Models;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Families.Controllers
{
    public class FamiliesController : Controller
    {
        private IDatabase _database;

        public FamiliesController(IDatabase database)
        {
            _database = database;
        }

        // GET: Families/Families
        public virtual ActionResult Index()
        {
            return View(_database.Families.Documents);
        }

        // GET: Families/Families/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Family = _database.Families.Retrieve(id.Value);
            if (Family == null)
            {
                return HttpNotFound();
            }
            return View(Family);
        }

        // GET: Families/Families/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Families/Families/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(FamilyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _database.Families.Create(model.Entity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Families/Families/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Families.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Families/Families/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(FamilyUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _database.Families.Update(model.Entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Families/Families/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Families.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Families/Families/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            _database.Families.Delete(id);
            return RedirectToAction("Index");
        }
    }
}