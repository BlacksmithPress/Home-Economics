using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Types;

namespace HomeEconomics.Web.Controllers
{
    public abstract class EntityController<RepositoryType, EntityType> : Controller
        where EntityType : IEntity
        where RepositoryType : IRepository<EntityType>
    {
        public EntityController(RepositoryType repository)
        {
            _repository = repository;
        }

        private RepositoryType _repository;

        // GET: People/People
        public ActionResult Index()
        {
            return View(_repository.Documents);
        }

        // GET: People/People/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _repository.Retrieve(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntityType entity)
        {
            if (ModelState.IsValid)
            {
                entity.Id = Guid.NewGuid();
                _repository.Create(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // GET: People/People/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _repository.Retrieve(id.Value);
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
        public ActionResult Edit(EntityType entity)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        // GET: People/People/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = _repository.Retrieve(id.Value);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: People/People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
