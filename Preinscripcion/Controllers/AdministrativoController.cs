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

        public ActionResult FinInscripcion(Alumno alum)
        {
            System.Random randomGenerate = new System.Random();
            System.String Legajo = "";
            Legajo = System.Convert.ToString(randomGenerate.Next(90000000, 99999999)).PadLeft(4, '0');
            ViewData["Nombre"] = alum.Nombre; 
            ViewData["Apellido"] = alum.Apellido;
            ViewData["Legajo"] = Legajo;
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
            return RedirectToAction("Index", "Administrativo");
        }


        public ActionResult VerificarDatosAdmin(Alumno alu)
        {
            string message = string.Empty;
            var p = db.Persona
                   .Where(b => b.NroDoc == alu.NroDoc)
                   .FirstOrDefault();

            if (p != null)
            {

                var alum = db.Alumno
                       .Where(b => b.PersonaId == p.PersonaId)
                       .FirstOrDefault();

                ViewBag.TipoDoc = new SelectList(db.TipoDoc, "Descripcion", "Descripcion");
                ViewBag.Nacionalidad = new SelectList(db.Nacionalidad, "Descripcion", "Descripcion");
                ViewBag.Provincia = new SelectList(db.Provincia, "Nombre", "Nombre");
                ViewBag.Localidad = new SelectList(db.Localidad, "Nombre", "Nombre");
                ViewBag.EstadoCivil = new SelectList(db.EstadoCivil, "Descripcion", "Descripcion");
                ViewBag.Sexo = new SelectList(db.Sexo, "Descripcion", "Descripcion");
                ViewBag.Carrera = new SelectList(db.Carrera, "Nombre", "Nombre");

                String fecha;
                fecha = alum.FechaNacimiento.ToShortDateString();


                ViewData["Nombre"] = alum.Nombre;
                ViewData["Apellido"] = alum.Apellido;
                ViewData["FechaNac"] = fecha; //NO ANDA
                ViewData["NroDoc"] = alum.NroDoc;
                ViewData["Domicilio"] = alum.Domicilio;
                ViewData["Tel"] = alum.Telefono;
                ViewData["Email"] = alum.Mail;
                ViewData["Celular"] = alum.Celular;
                ViewData["NombreColegio"] = alum.NombreColegio;
                ViewData["TituloColegio"] = alum.TituloColegio;
                ViewData["Legajo"] = alum.Legajo;

                //ViewData["Nacionalidad"] = alum.Nacionalidad;
                //ViewData["PciaNac"] = alum.PciaNacimiento;
                //ViewData["PciaDom"] = alum.PciaDomicilio;
                //ViewData["TipoDoc"] = alum.TipoDoc;
                //ViewData["LugarDom"] = alum.LugarDomicilio;
                //ViewData["LugarNac"] = alum.LugarNacimiento;
                //ViewData["EstadoCivil"] = alum.EstadoCivil;
                //ViewData["Sexo"] = alum.Sexo;
                //ViewData["Carrera"] = alum.Carrera;
                //ViewData["TipoAnALI"] = alum.Carrera;
                //ViewData["Emancipacion"] = alum.Emancipacion;

                //ViewData["FotoCarnet"] = alum.FotoCarnet;
                //ViewData["FotocDoc"] = alum.FotocopiaDoc;
                //ViewData["FotocAnalitico"] = alum.FotocAnalitico;
                //ViewData["CertifTrabajo"] = alum.CertificadoTrabajo;


                return View();
            }
            else
            {
                TempData["mensajeerror"] = "El alumno no se encuentra registrado";
                return RedirectToAction("BuscarDoc", "Administrativo");
            }
        }


    }
}
