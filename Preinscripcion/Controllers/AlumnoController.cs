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

            //var TiposDOC = new List<SelectListItem>();
            //TiposDOC = db.TipoDoc.Select(c => new SelectListItem()

            //{
            //    Text = c.Descripcion,
            //    Value = c.TipoDocId.ToString()

            //}).ToList();

            //ViewBag.TipoDocs = TiposDOC;

            var EstadosC = new List<SelectListItem>();
            EstadosC = db.EstadoCivil.Select(c => new SelectListItem()

            {
                Text = c.Descripcion,
                Value = c.EstadoCivilId.ToString()

            }).ToList();

            ViewBag.EstadosCivil = EstadosC;

            var Carreras = new List<SelectListItem>();
            Carreras = db.Carrera.Select(c => new SelectListItem()

            {
                Text = c.Nombre,
                Value = c.CarreraId.ToString()

            }).ToList();

            ViewBag.Carreras = Carreras;

            var nacionalidades = new List<SelectListItem>();
            nacionalidades = db.Nacionalidad.Select(c => new SelectListItem()

            {
                Text = c.Descripcion,
                Value = c.NacionalidadId.ToString()

            }).ToList();

            ViewBag.nacionalidades = nacionalidades;

            var Provincias = new List<SelectListItem>();
            Provincias = db.Provincia.Select(c => new SelectListItem()

            {
                Text = c.Nombre,
                Value = c.ProvinciaId.ToString()

            }).ToList();

            ViewBag.Provincias = Provincias;

            var Localidades = new List<SelectListItem>();
            Localidades = db.Localidad.Select(c => new SelectListItem()

            {
                Text = c.Nombre,
                Value = c.LocalidadId.ToString()

            }).ToList();

            ViewBag.Localidades = Localidades;

            var Sexos = new List<SelectListItem>();
            Sexos = db.Sexo.Select(c => new SelectListItem()

            {
                Text = c.Descripcion,
                Value = c.SexoId.ToString()

            }).ToList();

            ViewBag.Sexos = Sexos;


            //PARA NUEVOS SELECT
            ViewBag.Descripcion = new SelectList(db.TipoDoc, "Descripcion", "Descripcion");
            //ViewBag.Descripcion = new SelectList(db.Nacionalidad, "Descripcion", "Descripcion");
            //ViewBag.Nombre = new SelectList(db.Provincia, "Nombre", "Nombre");
            //ViewBag.Nombre = new SelectList(db.Localidad, "Nombre", "Nombre");
            //ViewBag.Descripcion = new SelectList(db.EstadoCivil, "Descripcion", "Descripcion");
            //ViewBag.Descripcion = new SelectList(db.Sexo, "Descripcion", "Descripcion");
            //ViewBag.Nombre = new SelectList(db.Carrera, "Nombre", "Nombre");


            return View();
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
