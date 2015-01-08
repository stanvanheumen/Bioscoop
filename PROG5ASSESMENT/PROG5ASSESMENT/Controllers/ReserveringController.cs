using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainModel.Models;
using DomainModel.IRepositories;
using PagedList;

namespace PROG5ASSESMENT.Controllers {

    public class ReserveringController : Controller {

		private IReserveringRepository _reserveringRepository;
		private EntitySearchRepository _search;

        public ReserveringController() {
			_reserveringRepository = new EntityReserveringRepository( );
			_search = new EntitySearchRepository( );
        }

		public ActionResult Index ( string sortOrder, string currentFilter, string searchString, int? page, int pagesize = 10 ) {
			ViewBag.CurrentSort = sortOrder;
			ViewBag.ResultAmount = pagesize;
			ViewBag.NameSortParm = String.IsNullOrEmpty( sortOrder ) ? "Film" : "";

			if ( searchString != null ) {
				page = 1;
			} else {
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			var films = _reserveringRepository.GetAll( );
			if ( !String.IsNullOrEmpty( searchString ) ) {
				films = _search.GetReservationWith( searchString );
			}
			switch ( sortOrder ) {
				case "Film":
				films = films.OrderBy( f => f.Film.Naam).ToList( );
				break;
				default:
				films = films.OrderByDescending( b => b.Film.Naam ).ToList( );
				break;
			}
			int pageSize = pagesize;
			int pageNumber = ( page ?? 1 );
			return View( films.ToPagedList( pageNumber, pageSize ) );
		}

        [HttpPost]
        public ActionResult Create(int id = 1) {
            Reservering reservering = new Reservering();
            for (int i = 0; i < id; i++) {
                reservering.Gasten.Add(new Gast());
            }
            ViewBag.amount = id;
            ViewBag.films = _reserveringRepository.GetAllFilms();
            return View();
        }

        [HttpPost]
        public ActionResult CreateConfirm(Reservering reservering, int filmId) {
            reservering.Film = _reserveringRepository.GetFilm(filmId);
            reservering.Totaalprijs = reservering.Gasten.Count * reservering.Film.Prijs;
            if (!string.IsNullOrEmpty(reservering.KortingsCode)) {
                foreach (Korting k in _reserveringRepository.GetAllKortingen()) {
                    if (reservering.KortingsCode.Equals(k.KortingsCode)) {
                        if (reservering.Film.StartDatumMetTijd >= k.StartDatum && reservering.Film.StartDatumMetTijd <= k.EindDatum) {
                            reservering.Totaalprijs -= k.Kortingsprijs;
                            break;
                        }
                    }
                }
            }
            
            if (reservering.Totaalprijs < 0) reservering.Totaalprijs = 0;

            int counter = 0;
            foreach (var res in reservering.Film.Reserveringen) {
                counter += res.Gasten.Count;
            }

            if (counter + reservering.Gasten.Count > reservering.Film.Zaal.Zitplaatsen) return RedirectToAction("Index");

            if (CheckReservering(reservering)) {
                _reserveringRepository.Create(reservering);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id) {
            var model = _reserveringRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Reservering reservering) {
            if (CheckReservering(reservering)) {
                _reserveringRepository.Update(reservering);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id) {
            var model = _reserveringRepository.Get(id);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id) {
            var model = _reserveringRepository.Get(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id) {
            var model = _reserveringRepository.Get(id);
            _reserveringRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public bool CheckReservering(Reservering reservering) {
            //if (reservering.Film == null) return false;
            return true;
        }

    }

}
