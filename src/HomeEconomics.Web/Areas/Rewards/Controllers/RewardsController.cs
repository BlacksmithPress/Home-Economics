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
    public class RewardsController : Controller
    {
        private IDatabase _database;

        public RewardsController(IDatabase database)
        {
            _database = database;
        }

        // GET: Rewards/Rewards
        public virtual ActionResult Index()
        {
            return View(_database.Rewards.Documents);
        }

        // GET: Rewards/Rewards/Details/5
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Reward = _database.Rewards.Retrieve(id.Value);
            if (Reward == null)
            {
                return HttpNotFound();
            }
            return View(Reward);
        }

        // GET: Rewards/Rewards/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Rewards/Rewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(RewardCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _database.Rewards.Create(model.Entity);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Rewards/Rewards/Edit/5
        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Rewards.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Rewards/Rewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(RewardUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _database.Rewards.Update(model.Entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Rewards/Rewards/Delete/5
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _database.Rewards.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Rewards/Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            _database.Rewards.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
