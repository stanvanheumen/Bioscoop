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

namespace PROG5ASSESMENT.Controllers {

    public class KortingController : Controller {
        
        private IKortingRepository _kortingRepository;

        public KortingController() {
            _kortingRepository = new EntityKortingRepository();
        }

        [HttpGet]
        public ActionResult Index() {
            var model = _kortingRepository.GetAll();
            return View(model);
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
