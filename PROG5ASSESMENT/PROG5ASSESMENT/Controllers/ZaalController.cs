using DomainModel.IRepositories;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using PagedList;

namespace PROG5ASSESMENT.Controllers {

    public class ZaalController : Controller {

		private IZaalRepository _zaalRepository;
		private EntitySearchRepository _search;

        public ZaalController() {
			_zaalRepository = new EntityZaalRepository( );
			_search = new EntitySearchRepository( );
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

			var films = _zaalRepository.GetAll( );
			if ( !String.IsNullOrEmpty( searchString ) ) {
				films = _search.GetRoomsWith( searchString );
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
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Zaal zaal) {
            if (CheckZaal(zaal)) {
                _zaalRepository.Create(zaal);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id) {
            var model = _zaalRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Zaal zaal) {
            if (CheckZaal(zaal)) {
                _zaalRepository.Update(zaal);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id) {
            var model = _zaalRepository.Get(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id) {
            var model = _zaalRepository.Get(id);
            _zaalRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public bool CheckZaal(Zaal zaal) {
            if (zaal.Naam == null) return false;
            return true;
        }


    }
}
