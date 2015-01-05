using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prog5Tentamen.Models;

namespace Prog5Tentamen.Controllers
{
    public class ZaalController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Zaal
        public ActionResult Index()
        {
            return View(db.Zaals.ToList());
        }

        // GET: Zaal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaal zaal = db.Zaals.Find(id);
            if (zaal == null)
            {
                return HttpNotFound();
            }
            return View(zaal);
        }

        // GET: Zaal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zaal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZaalId,Zitplaatsen,Naam")] Zaal zaal)
        {
            if (ModelState.IsValid)
            {
                db.Zaals.Add(zaal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zaal);
        }

        // GET: Zaal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaal zaal = db.Zaals.Find(id);
            if (zaal == null)
            {
                return HttpNotFound();
            }
            return View(zaal);
        }

        // POST: Zaal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZaalId,Zitplaatsen,Naam")] Zaal zaal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zaal);
        }

        // GET: Zaal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaal zaal = db.Zaals.Find(id);
            if (zaal == null)
            {
                return HttpNotFound();
            }
            return View(zaal);
        }

        // POST: Zaal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaal zaal = db.Zaals.Find(id);
            db.Zaals.Remove(zaal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
