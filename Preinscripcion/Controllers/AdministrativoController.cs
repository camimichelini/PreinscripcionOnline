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
using Preinscripcion.Models;

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

        public ActionResult FinInscripcion([Bind(Include = "PersonaId,Nombre,Apellido,TipoDocId,NroDoc,Telefono,Celular,Mail, Domicilio, NomyApePMT, EstadoCivilId, NacionalidadId, Localidad1Id, Localidad2Id, Provincia1Id, Provincia2Id, CarreraId, SexoId, FechaNacimiento, Emancipacion, NombreColegio, TituloColegio")] Alumno alumno)
        {

            System.Int32 legajo =
             (from alu in db.Alumno
              select alu.Legajo)
             .Max();


            if (legajo <= 90000000)
            {
                alumno.Legajo = 90000000;
            }
            else
            {
                alumno.Legajo = legajo + 1;
            }

            if (ModelState.IsValid)
            {
                using (var ctx = new PreinscripcionContext())
                {
                    
                    ctx.Persona.Add(alumno);
                    ctx.SaveChanges();
                }
     
            }
            ViewData["Nombre"] = alumno.Nombre; 
            ViewData["Apellido"] = alumno.Apellido;
            ViewData["Legajo"] = alumno.Legajo;
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

                ViewBag.TipoDocId = new SelectList(db.TipoDoc, "TipoDocId", "Descripcion", alum.TipoDocId);
                ViewBag.NacionalidadId = new SelectList(db.Nacionalidad, "NacionalidadId", "Descripcion", alum.Nacionalidad);
                ViewBag.Provincia1Id = new SelectList(db.Provincia, "ProvinciaId", "Nombre",alum.Provincia1Id );
                ViewBag.Provincia2Id = new SelectList(db.Provincia, "ProvinciaId", "Nombre", alum.Provincia1Id);
                ViewBag.Localidad1Id = new SelectList(db.Localidad, "LocalidadId", "Nombre", alum.Localidad1Id);
                ViewBag.Localidad2Id = new SelectList(db.Localidad, "LocalidadId", "Nombre", alum.Localidad2Id);
                ViewBag.EstadoCivilId = new SelectList(db.EstadoCivil, "EstadoCivilId", "Descripcion", alum.EstadoCivilId);
                ViewBag.SexoId = new SelectList(db.Sexo, "SexoId", "Descripcion", alum.SexoId);
                ViewBag.CarreraId = new SelectList(db.Carrera, "CarreraId", "Nombre", alum.CarreraId);

                String fecha;
                fecha = alum.FechaNacimiento.ToShortDateString();
                DateTime fecha2 = alum.FechaNacimiento.Date;
                ViewData["Nombre"] = alum.Nombre;
                ViewData["Apellido"] = alum.Apellido;
                ViewData["FechaNacimiento"] = fecha;
                ViewData["NroDoc"] = alum.NroDoc;
                ViewData["Domicilio"] = alum.Domicilio;
                ViewData["Telefono"] = alum.Telefono;
                ViewData["Mail"] = alum.Mail;
                ViewData["Celular"] = alum.Celular;
                ViewData["NombreColegio"] = alum.NombreColegio;
                ViewData["TituloColegio"] = alum.TituloColegio;
                ViewData["NomyApePMT"] = alum.NomyApePMT;
                ViewData["Emancipacion"] = alum.Emancipacion;

                //archivos
                //ViewData["FotoCarnet"] = alum.FotoCarnet;
                //ViewData["FotocDoc"] = alum.FotocDoc;
                //ViewData["FotocAnalitico"] = alum.FotocAnalitico;
                //ViewData["CertifTrabajo"] = alum.CertifTrabajo;


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
