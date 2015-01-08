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

    public class GastController : Controller {

		private IGastRepository _gastRepository;
		private EntitySearchRepository _search;

        public GastController() {
			_gastRepository = new EntityGastRepository( );
			_search = new EntitySearchRepository( );
        }

		public ActionResult Index ( string sortOrder, string currentFilter, string searchString, int? page, int pagesize = 10 ) {
			ViewBag.CurrentSort = sortOrder;
			ViewBag.ResultAmount = pagesize;
			ViewBag.NameSortParm = String.IsNullOrEmpty( sortOrder ) ? "Voornaam" : "";

			if ( searchString != null ) {
				page = 1;
			} else {
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			var films = _gastRepository.GetAll( );
			if ( !String.IsNullOrEmpty( searchString ) ) {
				films = _search.GetGuestsWith( searchString );
			}
			switch ( sortOrder ) {
				case "Voornaam":
				films = films.OrderBy( f => f.Voornaam ).ToList( );
				break;
				case "Achternaam":
				films = films.OrderBy( f => f.Achternaam ).ToList( );
				break;
				default:
				films = films.OrderByDescending( b => b.Voornaam ).ToList( );
				break;
			}
			int pageSize = pagesize;
			int pageNumber = ( page ?? 1 );
			return View( films.ToPagedList( pageNumber, pageSize ) );
		}

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id) {
            var model = _gastRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Gast gast) {
            gast.Reservering = _gastRepository.Get(gast.GastId).Reservering;
            if (CheckGast(gast)) {
                _gastRepository.Update(gast);
                return RedirectToAction("Index");
            }
            return View(gast);
        }

        public bool CheckGast(Gast gast) {
            if (gast.Voornaam == null)      return false;
            if (gast.Achternaam == null)    return false;
            if (gast.Reservering == null)   return false;
            return true;
        }

    }

}
