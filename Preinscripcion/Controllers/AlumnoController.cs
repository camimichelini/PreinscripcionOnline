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

        ////Prueba
        //public ActionResult Form()
        //{
        //    var TiposDOC = new List<SelectListItem>();
        //    TiposDOC = db.TipoDoc.Select(c => new SelectListItem()

        //    {
        //        Text = c.Descripcion,
        //        Value = c.TipoDocId.ToString()

        //    }).ToList();

        //    ViewBag.TipoDocs = TiposDOC;

        //    return View();
        //}

        // FORMULARIO 
        private PreinscripcionContext db = new PreinscripcionContext();
        public ActionResult Formulario()
        {
            //PARA NUEVOS SELECT
            ViewBag.TipoDoc = new SelectList(db.TipoDoc, "Descripcion", "Descripcion");
            ViewBag.Nacionalidad = new SelectList(db.Nacionalidad, "Descripcion", "Descripcion");
            ViewBag.Provincia = new SelectList(db.Provincia, "Nombre", "Nombre");
            ViewBag.Localidad = new SelectList(db.Localidad, "Nombre", "Nombre");
            ViewBag.EstadoCivil = new SelectList(db.EstadoCivil, "Descripcion", "Descripcion");
            ViewBag.Sexo = new SelectList(db.Sexo, "Descripcion", "Descripcion");
            ViewBag.Carrera = new SelectList(db.Carrera, "Nombre", "Nombre");

            return View();
        }

        // [Bind(Include = "Nombre,Apellido,NroDoc,FechaNAcimiento,Enmancipacion,FotoCarnet,FotocopiaDoc,CertificadoTrabajo,NOmbreColegio,TituloColegio,TipoAnalitico,FotoAnalitico,Domicilio,Telefono,Celular,Mail,Sexo,TipoDoc,Nacionalidad,Provincia,Localidad,Carrera,EstadoCivil")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Formulario([Bind(Include = "PersonaId,Nombre,Apellido,TipoDocId,TipoDoc,NroDoc,FechaNacimiento,Domicilio,Telefono,Celular,Mail,Enmancipacion,NomyApePMT,NombreColegio,EstadoCivilId,EstadoCivil,NacionalidadId,Nacionalidad,LugardeNacimiento.LocalidadId,LugarNacimiento,LugarDomicilio.LocalidadId,LugarDomicilio,CarreraId,Carrera")]Alumno alumno)
        {
            //string message = string.Empty;
            //var alumnos = db.Alumno
            //       .Where(b => b.NroDoc == alumno.NroDoc)
            //       .FirstOrDefault();

            //if (alumnoss != null)
            //{
                if (ModelState.IsValid)
            {
                db.Persona.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(alumno);
            }
            
        }



        public ActionResult VerificarDatosAdmin()
        {
            return View();
        }


        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        //// GET: Alumno/Create
        //public ActionResult Create()
        //{
        //    //var TiposDoc = new List<SelectListItem>();
        //    //TiposDoc = db.TipoDoc.Select(c => new SelectListItem()

        //    //{
        //    //    Text = c.Descripcion,
        //    //    Value = c.TipoDocId.ToString()

        //    //}).ToList();

        //    //ViewBag.TipoDocs = TiposDoc;

        //    //var EstadosC = new List<SelectListItem>();
        //    //EstadosC = db.EstadoCivil.Select(c => new SelectListItem()

        //    //{
        //    //    Text = c.Descripcion,
        //    //    Value = c.EstadoCivilId.ToString()

        //    //}).ToList();

        //    //ViewBag.EstadosCivil = EstadosC;

        //    //var Carreras = new List<SelectListItem>();
        //    //Carreras = db.Carrera.Select(c => new SelectListItem()

        //    //{
        //    //    Text = c.Nombre,
        //    //    Value = c.CarreraId.ToString()

        //    //}).ToList();

        //    //ViewBag.Carreras = Carreras;

        //    //var nacionalidades = new List<SelectListItem>();
        //    //nacionalidades = db.Nacionalidad.Select(c => new SelectListItem()

        //    //{
        //    //    Text = c.Descripcion,
        //    //    Value = c.NacionalidadId.ToString()

        //    //}).ToList();

        //    //ViewBag.nacionalidades = nacionalidades;

        //    //var Provincias = new List<SelectListItem>();
        //    //Provincias = db.Provincia.Select(c => new SelectListItem()

        //    //{
        //    //    Text = c.Nombre,
        //    //    Value = c.ProvinciaId.ToString()

        //    //}).ToList();

        //    //ViewBag.Provincias = Provincias;

        //    //var Localidades = new List<SelectListItem>();
        //    //Localidades = db.Localidad.Select(c => new SelectListItem()

        //    //{
        //    //    Text = c.Nombre,
        //    //    Value = c.LocalidadId.ToString()

        //    //}).ToList();

        //    //ViewBag.Localidades = Localidades;

        //    return View();
        //}

        //// POST: Alumno/Create

        ////[HttpPost]
        ////public ActionResult Create(FormCollection collection)
        ////{
        ////    try
        ////    {
        ////        // TODO: Add insert logic here

        ////        return RedirectToAction("Index");
        ////    }
        ////    catch
        ////    {
        ////        return View();
        ////    }
        ////}

        //// POST: Alumno/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create()
        //{
        //   return View();
        //}

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
