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
    public class FilmController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Film
        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            ViewBag.zalen = new System.Web.Mvc.SelectList(db.Zaals.Select(x => new SelectListItem { Value = x.Naam, Text = x.Naam }), "Value", "Text");

            //List<Zaal> lijstVanZalen = db.Zaals.Select(p => p).ToList();
            //List<string> lijstVanZaalNamen = new List<string>();
            //foreach (Zaal z in lijstVanZalen) {
            //    lijstVanZaalNamen.Add(z.Naam);
            //}
            //ViewBag.zalen = lijstVanZaalNamen;
            return View();
        }

        // POST: Film/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmId,TijdsduurinMinuten,Naam,Prijs,Datum")] Film film, string zalen)
        {
            List<Zaal> temp = db.Zaals.Select(z => z).ToList();
            foreach (Zaal z in temp) {
                if (z.Naam == zalen) {
                    film.Zaal = z;
                    break;
                }
            }
            ViewBag.zalen = new System.Web.Mvc.SelectList(db.Zaals.Select(x => new SelectListItem { Value = x.Naam, Text = x.Naam }), "Value", "Text");
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmId,TijdsduurinMinuten,Naam,Prijs,Datum")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
