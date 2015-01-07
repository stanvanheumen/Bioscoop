using DomainModel.IRepositories;
using DomainModel.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PROG5ASSESMENT.Controllers {

    public class FilmController : Controller {

        private IFilmRepository _filmRepository;

        public FilmController() {
            _filmRepository = new EntityFilmRepository();
        }

        [HttpGet]
        public ActionResult Index() {
            var model = _filmRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() {
            ViewBag.zalen = _filmRepository.GetAllZalen();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film film, int zaalId) {
            ViewBag.zalen   = _filmRepository.GetAllZalen();
            film.Zaal       = _filmRepository.GetZaal(zaalId);

            if (CheckFilm(film)) {
                _filmRepository.Create(film);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            ViewBag.zalen   = _filmRepository.GetAllZalen();
            var model       = _filmRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Film film, int zaalId) {
            ViewBag.zalen = _filmRepository.GetAllZalen();
            film.Zaal = _filmRepository.GetZaal(zaalId);

            if (CheckFilm(film)) {
                _filmRepository.Update(film);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id) {
            var model = _filmRepository.Get(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            var model = _filmRepository.Get(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            var model = _filmRepository.Get(id);
            _filmRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public bool CheckFilm(Film film) {
            if (film.Naam == null)              return false;
            if (film.StartDatumMetTijd == null) return false;
            if (film.EindDatumMetTijd == null)  return false;
            if (film.Zaal == null)              return false;

            foreach (Film f in film.Zaal.Films) {
                if (film.StartDatumMetTijd > f.StartDatumMetTijd && film.StartDatumMetTijd < f.EindDatumMetTijd) {
                    return false;
                }
                if (film.EindDatumMetTijd > f.StartDatumMetTijd && film.EindDatumMetTijd < f.EindDatumMetTijd) {
                    return false;
                }
                if (film.StartDatumMetTijd < f.StartDatumMetTijd && film.StartDatumMetTijd > f.EindDatumMetTijd) {
                    return false;
                }
                if (film.EindDatumMetTijd < f.StartDatumMetTijd && film.EindDatumMetTijd > f.EindDatumMetTijd) {
                    return false;
                }
            }

            return true;
        }

    }

}
