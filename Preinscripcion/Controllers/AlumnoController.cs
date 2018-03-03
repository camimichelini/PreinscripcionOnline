using Preinscripcion.AccesoDatos.Context;
using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;



namespace Preinscripcion.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PruebaForm()
        {
            return View();
        }

        private PreinscripcionContext db = new PreinscripcionContext();

        public ActionResult VerificarDatosAdmin()
        {
            return View();
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alumno/Formulario
        public ActionResult Formulario()
        {
            ViewBag.TipoDocId = new SelectList(db.TipoDoc, "TipoDocId", "Descripcion");
            ViewBag.NacionalidadId = new SelectList(db.Nacionalidad, "NacionalidadId", "Descripcion");
            ViewBag.Provincia1Id = new SelectList(db.Provincia, "ProvinciaId", "Nombre");
            ViewBag.Provincia2Id = new SelectList(db.Provincia, "ProvinciaId", "Nombre");
            ViewBag.Localidad1Id = new SelectList(db.Localidad, "LocalidadId", "Nombre");
            ViewBag.Localidad2Id = new SelectList(db.Localidad, "LocalidadId", "Nombre");
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivil, "EstadoCivilId", "Descripcion");
            ViewBag.SexoId = new SelectList(db.Sexo, "SexoId", "Descripcion");
            ViewBag.CarreraId = new SelectList(db.Carrera, "CarreraId", "Nombre");

            return View();
        }

        // POST: Guardar Alumno en la BD
        [HttpPost]
        public ActionResult Formulario([Bind(Include = "PersonaId,Nombre,Apellido,TipoDocId,NroDoc,Telefono,Celular,Mail, Domicilio, NomyApePMT, EstadoCivilId, NacionalidadId, Localidad1Id, Localidad2Id, Provincia1Id, Provincia2Id, CarreraId, SexoId, FechaNacimiento, Emancipacion, NombreColegio, TituloColegio")] Alumno alumno)
        {
            string message = string.Empty;
            var p = db.Alumno
                   .Where(b => b.NroDoc == alumno.NroDoc)
                   .FirstOrDefault();

            if (p == null)
            {

                if (ModelState.IsValid)
                {
                    using (var ctx = new PreinscripcionContext())
                    {
                        ctx.Persona.Add(alumno);
                        ctx.SaveChanges();
                    }
                    return RedirectToAction("Turno","Turnera");
                }

                return View(new Alumno());

            }
            else
            {
                TempData["mensajeerror"] = "Ya te preinscribiste anteriormente";
                return RedirectToAction("Formulario", "Alumno");
            }
        }

        
     // GET: Alumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alumno/Edit/5
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

        // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumno/Delete/5
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

    }
}        