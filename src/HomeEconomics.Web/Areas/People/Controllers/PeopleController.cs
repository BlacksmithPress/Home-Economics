using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Areas.People.Controllers
{
    public class PeopleController : Controller
    {
        private Data.Repositories.People _people = Data.Repositories.Database.Instance.People;

        // GET: People/People
        public ActionResult Index()
        {
            return View(_people.RetrieveAll());
        }

        // GET: People/People/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _people.Retrieve(id.Value);
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
        public ActionResult Create([Bind(Include = "Sex,Birthdate,Name")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                _people.Create(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/People/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _people.Retrieve(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sex,Birthdate,Name")] Person person)
        {
            if (ModelState.IsValid)
            {
                _people.Update(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/People/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _people.Retrieve(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _people.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
