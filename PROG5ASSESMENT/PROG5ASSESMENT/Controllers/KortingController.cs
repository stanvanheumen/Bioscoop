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

    public class KortingController : Controller {

		private IKortingRepository _kortingRepository;
		private EntitySearchRepository _search;

        public KortingController() {
			_kortingRepository = new EntityKortingRepository( );
			_search = new EntitySearchRepository( );
        }

		public ActionResult Index ( string sortOrder, string currentFilter, string searchString, int? page, int pagesize = 10 ) {
			ViewBag.CurrentSort = sortOrder;
			ViewBag.ResultAmount = pagesize;
			ViewBag.NameSortParm = String.IsNullOrEmpty( sortOrder ) ? "Koringscode" : "";

			if ( searchString != null ) {
				page = 1;
			} else {
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			var films = _kortingRepository.GetAll( );
			if ( !String.IsNullOrEmpty( searchString ) ) {
				films = _search.GetDiscountWith( searchString );
			}
			switch ( sortOrder ) {
				case "Koringscode":
				films = films.OrderBy( f => f.KortingsCode ).ToList( );
				break;
				default:
				films = films.OrderByDescending( b => b.KortingsCode ).ToList( );
				break;
			}
			int pageSize = pagesize;
			int pageNumber = ( page ?? 1 );
			return View( films.ToPagedList( pageNumber, pageSize ) );
		}

        [HttpGet]
        [Authorize]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Korting korting) {
            if (CheckKorting(korting)) {
                _kortingRepository.Create(korting);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id) {
            var model = _kortingRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Korting korting) {
            if (CheckKorting(korting)) {
                _kortingRepository.Update(korting);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id) {
            var model = _kortingRepository.Get(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id) {
            var model = _kortingRepository.Get(id);
            _kortingRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public bool CheckKorting(Korting korting) {
            if (korting.KortingsCode == null)   return false;
            if (korting.StartDatum == null)     return false;
            if (korting.EindDatum == null)      return false;
            return true;
        }

    }

}
