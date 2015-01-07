using DomainModel.IRepositories;
using DomainModel.Models;
using System.Web.Mvc;

namespace PROG5ASSESMENT.Controllers {

    public class ZaalController : Controller {

        private IZaalRepository _zaalRepository;

        public ZaalController() {
            _zaalRepository = new EntityZaalRepository();
        }

        [HttpGet]
        public ActionResult Index() {
            var model = _zaalRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Zaal zaal) {
            if (CheckZaal(zaal)) {
                _zaalRepository.Create(zaal);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var model = _zaalRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Zaal zaal) {
            if (CheckZaal(zaal)) {
                _zaalRepository.Update(zaal);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            var model = _zaalRepository.Get(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
