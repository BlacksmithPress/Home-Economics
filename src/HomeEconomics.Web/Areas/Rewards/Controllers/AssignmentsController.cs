using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{

    public class AssignmentsController : Controller
    {
        private IDatabase _database;

        public AssignmentsController(IDatabase database)
        {
            _database = database;
        }

        // GET: Activities/Activities
        public virtual ActionResult Index()
        {
            return View(_database.Assignments.Documents);
        }

        // GET: Activities/Activities/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Assignments.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // GET: Activities/Activities/Create
        public virtual ActionResult Create()
        {
            var model = new AssignmentCreateViewModel
            {
                Entity = new Assignment(),
                Activities = Database.Instance.Activities.Documents.Select<Activity, SelectListItem>(a => a.ToSelectListItem()),
                People = Database.Instance.People.Documents.Select<Person, SelectListItem>(a => a.ToSelectListItem()),
                Rewards = Database.Instance.Rewards.Documents.Select<Reward, SelectListItem>(a => a.ToSelectListItem()),
            };
            return View(model);
        }

        // POST: Activities/Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(AssignmentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _database.Assignments.Create(model.Entity);
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

            var entity = _database.Assignments.Retrieve(id.Value);
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
        public virtual ActionResult Edit(AssignmentUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _database.Assignments.Update(model.Entity);
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

            var entity = _database.Assignments.Retrieve(id.Value);
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
            _database.Assignments.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
