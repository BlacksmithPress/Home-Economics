using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class EvaluationsController : Controller
    {
        private IDatabase _database;

        public EvaluationsController(IDatabase database)
        {
            _database = database;
        }

        // GET: Evaluations/Evaluations
        public virtual ActionResult Index()
        {
            return View(_database.Evaluations.Documents);
        }

        // GET: Evaluations/Evaluations/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Evaluation = _database.Evaluations.Retrieve(id.Value);
            if (Evaluation == null)
            {
                return HttpNotFound();
            }
            return View(Evaluation);
        }

        // GET: Evaluations/Evaluations/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Evaluations/Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(EvaluationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _database.Evaluations.Create(model.Entity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Evaluations/Evaluations/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Evaluations.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Evaluations/Evaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(EvaluationUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _database.Evaluations.Update(model.Entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Evaluations/Evaluations/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Evaluations.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Evaluations/Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            _database.Evaluations.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
