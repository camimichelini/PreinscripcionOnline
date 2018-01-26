using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Preinscripcion.Controllers
{
    public class AdministrativoController : Controller
    {
        // GET: Administrativo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administrativo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrativo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrativo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrativo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrativo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrativo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FinInscripcion()
        {
            return View();
        }

        public ActionResult BuscarDoc()
        {
            return View();
        }
    }
}
