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
            var preins = db.PreinscripcionOnline.Where(p => p.PreinscripcionId == id).FirstOrDefault();
            var turN = db.Turno.Where(f => f.Estado == true).Select(f => f.Fecha); ;

            turN = turN.Distinct();


            string fecha;
            string hora;

            var t = db.Turno.Where(a => a.TurnoId == preins.TurnoId).FirstOrDefault();

            fecha = t.Fecha;
            hora = t.Hora;



            ViewBag.Fecha = new SelectList(turN, "Fecha");
            ViewBag.Hora = new SelectList(db.Turno, "TurnoId", "Hora");

            ViewData["FechaTur"] = fecha;
            ViewData["HoraTur"] = hora;
            ViewData["PreinscripcionID"] = id;

            return View(); ;

        }



        public ActionResult CancelarTurno(int? id)
        {
            var preins = db.PreinscripcionOnline.Where(p => p.PreinscripcionId == id).FirstOrDefault();
            string fecha;
            string hora;

            var t = db.Turno.Where(a => a.TurnoId == preins.TurnoId).FirstOrDefault();

            fecha = t.Fecha;
            hora = t.Hora;



            ViewData["Fecha"] = fecha;
            ViewData["Hora"] = hora;
            ViewData["PreinscripcionID"] = id;

            return View();
        }

        public ActionResult Turnera(int id)
        {
            var p = db.Turno.Where(f => f.Estado == true).Select(f => f.Fecha); ;
            
            p= p.Distinct();
            ViewBag.Fecha = new SelectList(p,  "Fecha");
            ViewBag.Hora = new SelectList(db.Turno, "TurnoId", "Hora");
            ViewData["PersonaId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Turnera([Bind(Include = "PersonaId,TurnoID")] PreinscripcionOnline preinscripcion, int hora, string fecha, int id)
        {
            string message = string.Empty;

            preinscripcion.TurnoId = hora;
            preinscripcion.PersonaId = id;

            var t = db.Turno
                   .Where(b => b.TurnoId == preinscripcion.TurnoId)
                   .FirstOrDefault();

            var a = db.Alumno
                   .Where(b => b.PersonaId == preinscripcion.PersonaId)
                   .FirstOrDefault();

            if ((t != null) & (a != null))
            {
                if ((fecha != null) & (hora != 0))
                {
                    if (ModelState.IsValid)
                    {
                        using (var ctx = new PreinscripcionContext())
                        {
                            ctx.PreinscripcionOnline.Add(preinscripcion);
                            ctx.SaveChanges();

                            var estNuevo = false;
                            t.Estado = estNuevo;
                            db.Entry(t).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        return RedirectToAction("FinPreinscripcion", "Preinscripcion");
                    }
                }

                else
                {
                    if (fecha == null)
                    {
                        TempData["mensajeerror"] = "Elija una fecha";
                        return RedirectToAction("Turnera", "Turno");
                    }

                    if (hora == 0)
                    {
                        TempData["mensajeerror"] = "Elija un horario";
                        return RedirectToAction("Turnera", "Turno");
                    }

                }


                return View(new PreinscripcionOnline());

            }
            else
            {
                TempData["mensajeerror"] = "Error en la preinscripcion";
                return RedirectToAction("Formulario", "Alumno");

            }
        }

        public ActionResult BuscarHorario(string id)
        {
            var types = HorarioList(id);
            return Json(types, JsonRequestBehavior.AllowGet);
        }
        private List<SelectListItem> HorarioList(string idtypes)
        {
            var stypes = db.Turno.Where(x => x.Fecha == idtypes)
                                 .Where(x => x.Estado == true);
            var resp = stypes.Select(x => new SelectListItem()
            {
                Value = x.TurnoId.ToString(),
                Text = x.Hora
            }).ToList();

            resp.Insert(0, new SelectListItem() { Value = "", Text = "Elija un horario" });

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

    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estNuevo = true;
            PreinscripcionOnline preins = db.PreinscripcionOnline.Find(id);
            Turno turno = db.Turno.Find(preins.TurnoId);
            Alumno alumno = db.Alumno.Find(preins.PersonaId);

            if (preins != null)
            {

                db.PreinscripcionOnline.Remove(preins);
                db.Alumno.Remove(alumno);
                db.SaveChanges();

                turno.Estado = estNuevo;
                db.Entry(turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CancelarTurnoOk");
            }
            return View();

        }



        public ActionResult Edit2([Bind(Include = "PersonaId, TurnoId")]  PreinscripcionOnline preinscripcion, int? idP, int idT)
        {
            if ((idP == null) || (idT == 0))
            {
                TempData["mensajeerror"] = "Elegí un Turno";
                return RedirectToAction("ModificarTurno", "Turno");
            }
            var estViejo = true;
            var estNuevo = false;


            PreinscripcionOnline preins = db.PreinscripcionOnline.Find(idP);
            Turno turnoViejo = db.Turno.Find(preins.TurnoId);
            Turno turnoNuevo = db.Turno.Find(idT);

            if (preins != null)
            {
                turnoViejo.Estado = estViejo;
                db.Entry(turnoViejo).State = EntityState.Modified;
                db.SaveChanges();

                turnoNuevo.Estado = estNuevo;
                db.Entry(turnoViejo).State = EntityState.Modified;
                db.SaveChanges();

                //preins.TurnoId = hora;
                db.Entry(preins).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ModificarTurnoOk");
            }
            return View();

        }


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
