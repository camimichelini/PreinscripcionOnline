using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Preinscripcion.AccesoDatos.Context;
using System.Data.Entity;

namespace Preinscripcion.Controllers
{
    public class PreinscripcionController : Controller
    {

        private PreinscripcionContext db = new PreinscripcionContext();
        // GET: Preinscripcion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Preinscripcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Preinscripcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Preinscripcion/Create
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

        // GET: Preinscripcion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Preinscripcion/Edit/5
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

        // GET: Preinscripcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Preinscripcion/Delete/5
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

        // GET: Fin preinscripcion
        public ActionResult FinPreinscripcion()
        {
            return View();
        }

    }
    
    
}
