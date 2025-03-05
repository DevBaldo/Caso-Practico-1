using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProgramaController : Controller
    {
        private readonly IProgramaHelper _programaHelper;

        public ProgramaController(IProgramaHelper programaHelper)
        {
            _programaHelper = programaHelper;
        }

        // GET: ProgramaController
        public ActionResult Index()
        {
            var result = _programaHelper.GetProgramas();
            return View(result);
        }

        // GET: ProgramaController/Details/5
        public ActionResult Details(int id)
        {
            var result = _programaHelper.GetPrograma(id);
            return View(result);
        }

        // GET: ProgramaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.Add(programa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramaController/Edit/5
        public ActionResult Edit(int id)
        {
            var programa = _programaHelper.GetPrograma(id);
            return View(programa);
        }

        // POST: ProgramaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.Update(programa);
                return RedirectToAction("Details", new { id = programa.ProgramaId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramaController/Delete/5
        public ActionResult Delete(int id)
        {
            var programa = _programaHelper.GetPrograma(id);
            return View(programa);
        }

        // POST: ProgramaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.Delete(programa.ProgramaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
