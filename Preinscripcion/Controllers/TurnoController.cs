using Preinscripcion.AccesoDatos.Context;
using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Preinscripcion.Controllers
{
    public class TurnoController : Controller
    {
        private PreinscripcionContext db = new PreinscripcionContext();
        // GET: Turno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ModificarTurno(int? id)
        {
            var tur = db.Turno.Where(b => b.TurnoId == id).FirstOrDefault();
            string fecha;
            string hora;
            fecha = tur.Fecha;
            hora = tur.Hora;



            ViewData["Fecha"] = fecha;
            ViewData["Hora"] = hora;
            ViewData["TurnoId"] = id;

            return View();
            
        }


        
        public ActionResult CancelarTurno(int id)
        {
            var tur = db.Turno.Where(b => b.TurnoId == id).FirstOrDefault(); 
            string fecha;
            string hora;
            fecha = tur.Fecha;
            hora = tur.Hora;
            


            ViewData["Fecha"] = fecha;
            ViewData["Hora"] = hora;
            ViewData["TurnoId"] = id;

            return View();
        }

        public ActionResult Turnera()
        {
            var p = db.Turno.Where(f => f.Estado == true);
            p= p.Distinct();
            ViewBag.Fecha = new SelectList(p,  "Fecha");
            ViewBag.Hora = new SelectList(db.Turno, "TurnoId", "Hora");
            return View();
        }
        public ActionResult BuscarHorario(string id)
        {
            var types = HorarioList(id);
            return Json(types, JsonRequestBehavior.AllowGet);
        }
        private List<SelectListItem> HorarioList(string dia)
        {
            var stypes = db.Turno.Where(x => x.Fecha == dia)
                                    .Where(x => x.Estado == true);
            var resp = stypes.Select(x => new SelectListItem()
            {
                Value = x.TurnoId.ToString(),
                Text = x.Hora
            }).ToList();

            resp.Insert(0, new SelectListItem() { Value = "", Text = "Elija una opción" });

            return resp;
        }
        // GET: Turno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Turno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turno/Create
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

        // GET: Turno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estNuevo = true;
            Turno turno = db.Turno.Find(id);

            if (turno != null)
            {
                turno.Estado = estNuevo;
                db.Entry(turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CancelarTurnoOk");
            }
            return View();

        }

        public ActionResult Edit2(int? id1, int? id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estViejo = true;
            var estNuevo = false;

            Turno turnoViejo = db.Turno.Find(id1);
            Turno turnoNuevo = db.Turno.Find(id2);

            if (turnoViejo != null) 
            {
                turnoViejo.Estado = estViejo;
                db.Entry(turnoViejo).State = EntityState.Modified;
                db.SaveChanges();
            }

            if (turnoNuevo != null)
            {
                turnoNuevo.Estado = estNuevo;
                db.Entry(turnoViejo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ModificarTurnoOk");
            }
            return View();

        }


        // POST: Turno/Edit/5
        [HttpPost]
        //public ActionResult Edit( int? id)
        //{

        //    //db.Entry(materiaComision).State = EntityState.Modified;
        //    //db.SaveChanges();
        //    // TODO: Add update logic here
            
        //        var estNuevo = true;
        //        var turno = db.Turno.Where(b => b.TurnoId == id).FirstOrDefault();
        //        if (turno != null)
        //        {
        //            turno.Estado = estNuevo;
        //            db.Entry(turno).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //       return View("~/Views/Turno/CancelarTurnoOk.cshtml");
        //}

        // GET: Turno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Turno/Delete/5
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

        // GET: ModificarTurnoOk
        public ActionResult ModificarTurnoOk()
        {
            return View();
        }

        // GET: CancelarTurnoOk
        public ActionResult CancelarTurnoOk()
        {
            
            
            return View();
        }
    }
}
