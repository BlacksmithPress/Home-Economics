using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Types;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Controllers
{
    public abstract class EntityController<RepositoryType, EntityType, CreateModelType, UpdateModelType> : Controller
        where EntityType : IEntity
        where RepositoryType : IRepository<EntityType>
    {
        public EntityController(RepositoryType repository)
        {
            _repository = repository;
        }

        protected RepositoryType _repository;

        // GET: People/People
        public virtual ActionResult Index()
        {
            return View(_repository.Documents);
        }

        // GET: People/People/Details/5
        public virtual ActionResult Details(Guid? id)
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
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: People/People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(CreateViewModel<EntityType> model)
        {
            if (ModelState.IsValid)
            {
                model.Entity.Id = Guid.NewGuid();
                _repository.Create(model.Entity);
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
        public virtual ActionResult Edit(UpdateViewModel<EntityType> model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model.Entity);
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
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }

    public abstract class EntityController<RepositoryType, EntityType> : EntityController<RepositoryType, EntityType, CreateViewModel<EntityType>, UpdateViewModel<EntityType>>
        where EntityType : IEntity
        where RepositoryType : IRepository<EntityType>
    {
        public EntityController(RepositoryType repository) : base(repository) { }
    }
}
