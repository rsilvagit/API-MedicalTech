using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTech.Controllers
{
    public class EnfermeiroController : Controller
    {
        // GET: EnfermeiroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnfermeiroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnfermeiroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnfermeiroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EnfermeiroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnfermeiroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EnfermeiroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnfermeiroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
