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

    public class GastController : Controller {
       
        private IGastRepository _gastRepository;

        public GastController() {
            _gastRepository = new EntityGastRepository();
        }

        [HttpGet]
        public ActionResult Index() {
            var model = _gastRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var model = _gastRepository.Get(id);
            return View(model);
        }

        [HttpPost]
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
