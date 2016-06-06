using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Web.Areas.People.Models;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.People.Controllers
{
    public class PeopleController : Controller
    {
        private IDatabase _database;

        public PeopleController(IDatabase database)
        {
            _database = database;
        }

        // GET: People/People
        public virtual ActionResult Index()
        {
            return View(_database.People.Documents);
        }

        // GET: People/People/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _database.People.Retrieve(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/People/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: People/People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(PersonCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _database.People.Create(model.Entity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: People/People/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.People.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: People/People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(PersonUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _database.People.Update(model.Entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: People/People/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.People.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: People/People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            _database.People.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
