using EncuestaSatisfaccion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestaSatisfaccion.Controllers
{
    public class EncuestaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Encuesta(string mail)
        {
            var existe = db.Encuestados.Where(x => x.mail == mail && x.Contestada == 0).FirstOrDefault();
            var vig = db.VigenciaEnc.Where(x => x.Activo == true).FirstOrDefault();
            if (existe != null)
            {
                var d = DateTime.Now.AddDays(vig.Dias);
                if (existe.fechaAlta <= d)
                {
                    ViewBag.Vencida = 0;
                }
                else {
                    ViewBag.Vencida = 1;
                }

                ViewBag.mail = mail;
            }
            else
            {
                ViewBag.mail = "";
            }
            return PartialView("Encuesta");
        }
        
        public ActionResult EncuestaM(string mail)
        {
            

            var existe = db.Encuestados.Where(x => x.mail == mail && x.Contestada==0).FirstOrDefault();

            if (existe != null)
            {
                ViewBag.mail = mail;
            }
            else {
                ViewBag.mail = "";
            }
            return PartialView("Encuesta");
        }

        [HttpPost]
        public ActionResult Create(string mail,string P1, string P2, string P3, string P4, string P5, 
            string P6, string P7, string P8, string P9, string P10, string P11, string P12, string P13, string P14, string P15, string P16, string P17, string P18, string P19)
        {
            var resp = 0;

            var existe = db.Encuestados.Where(x => x.mail == mail && x.Contestada == 0).FirstOrDefault();

            if (existe != null)
            {
                Respuestas r = new Respuestas();
                r.IdEncuestado = existe.Id;
                r.rp1 = P1;
                r.rp2 = P2;
                r.rp3 = P3;
                r.rp4 = P4;
                r.rp5 = P5;
                r.rp6 = P6;
                r.rp7 = P7;
                r.rp8 = P8;
                r.rp9 = P9;
                r.rp10 = P10;
                r.rp11 = P11;
                r.rp12 = P12;
                r.rp13 = P13;
                r.rp14 = P14;
                r.rp15 = P15;
                r.rp16 = P16;
                r.rp17 = P17;
                r.rp18 = P18;
                r.rp19 = P19;

                db.Respuestas.Add(r);
                db.SaveChanges();
                existe.fechaContestado = DateTime.Now;
                existe.Contestada = 1;

                db.Entry(existe).State = EntityState.Modified;
                db.SaveChanges();

                resp = 1;
            }
            else { resp = 2; }

            return Json(new { R = 1, resp });
        }

    }
}
