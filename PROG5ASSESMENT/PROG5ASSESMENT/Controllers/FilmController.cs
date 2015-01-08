using DomainModel.IRepositories;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using PagedList;

namespace PROG5ASSESMENT.Controllers {

    public class FilmController : Controller {

        private IFilmRepository _filmRepository;
		private EntitySearchRepository _search;

        public FilmController() {
            _filmRepository = new EntityFilmRepository();
            _search = new EntitySearchRepository();
        }

		public ActionResult Index ( string sortOrder, string currentFilter, string searchString, int? page, int pagesize = 10 ) {
			ViewBag.CurrentSort = sortOrder;
			ViewBag.ResultAmount = pagesize;
			ViewBag.NameSortParm = String.IsNullOrEmpty( sortOrder ) ? "Naam" : "";

			if ( searchString != null ) {
				page = 1;
			} else {
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			var films = _filmRepository.GetAll( );
			if ( !String.IsNullOrEmpty( searchString ) ) {
				films = _search.GetFilmsWith( searchString );
			}
			switch ( sortOrder ) {
				case "Naam":
				films = films.OrderBy( f => f.Naam ).ToList( );
				break;
				default:
				films = films.OrderByDescending( b => b.Naam ).ToList( );
				break;
			}
			int pageSize = pagesize;
			int pageNumber = ( page ?? 1 );
			return View( films.ToPagedList( pageNumber, pageSize ) );
		}

        [HttpGet]
        [Authorize]
        public ActionResult Create() {
            ViewBag.zalen = _filmRepository.GetAllZalen();
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public ActionResult Edit(int id) {
            ViewBag.zalen   = _filmRepository.GetAllZalen();
            var model       = _filmRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public ActionResult Details(int id) {
            var model = _filmRepository.Get(id);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id) {
            var model = _filmRepository.Get(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
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
