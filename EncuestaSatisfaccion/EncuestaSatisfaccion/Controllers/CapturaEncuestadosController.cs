using EncuestaSatisfaccion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EncuestaSatisfaccion.Controllers
{
    public class CapturaEncuestadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CapturaEncuestados
        public ActionResult Index()
        {
            var Enc = db.Encuestados.ToList();

            ViewBag.Encuestados = Enc;
            return View();
        }

        public ActionResult IndexP()
        {
            var Enc = db.Encuestados.ToList();

            ViewBag.Encuestados = Enc;
            return PartialView("Index");
        }

        // GET: CapturaEncuestados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDiasVig() {
            var dv = db.VigenciaEnc.Where(x => x.Activo == true).FirstOrDefault();

            return Json(new { R = 1, d= dv.Dias });
        }

        [HttpPost]
        public ActionResult SetDiasVig(int dias)
        {
            try
            {
                var dv = db.VigenciaEnc.Where(x => x.Activo == true).FirstOrDefault();
                if (dv != null)
                {
                    dv.Activo = false;
                    db.Entry(dv).State = EntityState.Modified;
                    db.SaveChanges();
                }
                VigenciaEnc v = new VigenciaEnc();
                v.Activo = true;
                v.Dias = dias;
                v.FechaAlta = DateTime.Now;
                v.UserCap = Session["UserID"].ToString();
                db.VigenciaEnc.Add(v);
                db.SaveChanges();

                return Json(new { R = 1, dv.Dias });
            }
            catch (Exception e) {
                return Json(new { R = 0, e.Message });
            }
        }

        [HttpPost]
        public ActionResult GetRespuestas(int Id)
        {
            try
            {
                var enc = db.Encuestados.Find(Id);
                var r = db.Respuestas.Where(x => x.IdEncuestado == enc.Id).FirstOrDefault();

                return Json(new { R = 1 ,enc,r});
            }
            catch (Exception e)
            {
                return Json(new { R = 0, e.Message });
            }

        }
        [HttpPost]
        public ActionResult MandaEnc(int Id)
        {
            try
            {
                var enc = db.Encuestados.Find(Id);
                FuncionesGenericas f = new FuncionesGenericas();
                var texto = "Hola " + enc.Nombre + ".<br/>" +
                    "¿Deseas contestar una breve encuesta para ayudarnos a mejorar nuestros servicios? ¡Sólo te tomará 5 minutos!" +
                    "" +
                    "Gracias de antemano por tus valiosos comentarios.  Tu opinión será utilizada para asegurar que continuemos mejorando. ";

                f.SendMail(texto, enc.mail, "Encuesta Star Medica", "");
                return Json(new { R = 1});
            }
            catch (Exception e) {
                return Json(new { R = 0, e.Message });
            }
        
        }
            // GET: CapturaEncuestados/Create
            [HttpPost]
        public async Task<ActionResult> Create(int Id, string nombre, string Email, string apa,string ama,string puesto )
        {
            if (Id == 0)
            {//nuevo 
                var enc = new Encuestados();
                enc.Nombre = nombre;
                enc.Apa = apa;
                enc.Ama = ama;
                enc.mail = Email;
                enc.puesto = puesto;
                enc.fechaAlta = DateTime.Now;
                enc.Contestada = 0;
                enc.UserCap = Session["UserID"].ToString();

                db.Encuestados.Add(enc);
                db.SaveChanges();
                FuncionesGenericas f = new FuncionesGenericas();
                string host = HttpContext.Request.Url.Host;
                f.SendMail(enc.Nombre, enc.mail, host, "");
                return Json(new { R = 1, enc });
                
                
                
            }
            else {//modifica
                var enc = db.Encuestados.Find(Id);
                enc.Nombre = nombre;
                enc.Apa = apa;
                enc.Ama = ama;
                enc.mail = Email;
                enc.puesto = puesto;
                enc.fechaAlta = DateTime.Now;
                enc.Contestada = 0;
                enc.UserCap = Session["UserID"].ToString();

                db.Entry(enc).State = EntityState.Modified;
                db.SaveChanges();


                return Json(new { R = 1, enc });
            }
            
        }

       

    }
}
