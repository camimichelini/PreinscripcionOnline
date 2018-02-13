using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Preinscripcion.Entidades;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web.Helpers;
using System.Configuration;
using Preinscripcion.AccesoDatos.Context;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Preinscripcion.Controllers
{
    public class AdministrativoController : Controller
    {
        private PreinscripcionContext db = new PreinscripcionContext();
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

        public ActionResult Login(Administrativo admin)
        {
            string message = string.Empty;
            var adminis = db.Administrativo
                   .Where(b => b.Usuario == admin.Usuario)
                   .FirstOrDefault();

            if (adminis != null)
            {
                if (adminis.Contraseña.Equals(admin.Contraseña))
                 {
                    return RedirectToAction("BuscarDoc", "Administrativo");
                  }
                 else
                 {
                    TempData["mensajeerror"] = "La contraseña introducida es incorrecta";
                    return RedirectToAction("Index", "Administrativo");
                 }
            }
            else
            {
                TempData["mensajeerror"] = "El usuario no se encuentra registrado";
                return RedirectToAction("Index", "Administrativo");
            }

        }


        public ActionResult Logout()
        {
            Session.Clear();
            //or Session["LoginMapper"]  = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult BuscarDocu(Alumno alu)
        {
            string message = string.Empty;
            var alum = db.Persona
                   .Where(b => b.NroDoc == alu.NroDoc)
                   .FirstOrDefault();

            if (alum != null)
            {
                    return RedirectToAction("VerificarDatosAdmin", "Alumno", new { alu = alum });
            }
            else
            {
                TempData["mensajeerror"] = "El alumno no se encuentra registrado";
                return RedirectToAction("BuscarDoc", "Administrativo");
            }
        }
    }
}
