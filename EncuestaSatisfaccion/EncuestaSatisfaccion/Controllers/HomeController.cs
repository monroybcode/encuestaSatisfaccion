using EncuestaSatisfaccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestaSatisfaccion.Controllers
{
    [SecurityAuthorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private FuncionesGenericas fn = new FuncionesGenericas();
        public ActionResult Index()
        {
            var Usuario = Session["UserID"].ToString();
            var h = Int16.Parse(Session["HospitalE"].ToString());
            var UniMed = (from PUUM in db.UsuarioxUmedica
                          join um in db.UnidadesMedicas on PUUM.Id_unidad equals um.Id_UnidadMedica
                          where PUUM.UserID == Usuario && PUUM.IdUnidad.active == true
                          select um).ToList();
            ViewBag.h = h;
            ViewBag.Hospitales = UniMed;
            ViewBag.HospitalesCount = Session["escoge"];
            return View();
            
        }

        public ActionResult IndexP()
        {
            var Usuario = Session["UserID"].ToString();
            var h = Int16.Parse(Session["HospitalE"].ToString());
            var UniMed = (from PUUM in db.UsuarioxUmedica
                          join um in db.UnidadesMedicas on PUUM.Id_unidad equals um.Id_UnidadMedica
                          where PUUM.UserID == Usuario && PUUM.IdUnidad.active == true
                          select um).ToList();
            ViewBag.h = h;
            ViewBag.Hospitales = UniMed;
            ViewBag.HospitalesCount = Session["escoge"];

            return PartialView("Index");
        }
        
        public bool AsignaH(int h)
        {
            Session["HospitalE"] = h;
            Session["escoge"] = 0;
            return true;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult GData(int h) {
        //    try
        //    {
                
        //        DateTime startDateTime = DateTime.Today; //Today at 00:00:00
        //        DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

        //        //entradas
        //        var e = db.Registro.Select(x => x)
        //            .Where(x=> x.FechaEntrada >= startDateTime && x.FechaEntrada <= endDateTime && x.UnidadMedica == h).Count();

        //        //salidas
        //        var s = db.Registro.Select(x => x)//solo salidas del mismo dia?
        //            .Where(x => x.FechaSalida >= startDateTime && x.FechaSalida <= endDateTime && x.UnidadMedica == h ).Count();

        //        //activos
        //        var a = db.Registro.Select(x => x)
        //            .Where(x => x.FechaEntrada >= startDateTime && x.FechaEntrada <= endDateTime && x.UnidadMedica == h
        //            && x.FechaSalida.ToString()=="" ).Count();

        //        var r = db.Registro.Select(x => x)
        //            .Where(x => x.FechaEntrada >= startDateTime && x.FechaEntrada <= endDateTime && x.UnidadMedica == h).ToList();

        //        hours lxh = new hours();
        //        TimeSpan ts8 = TimeSpan.Parse("8:59");
        //        TimeSpan ts9 = TimeSpan.Parse("9:59");
        //        TimeSpan ts10 = TimeSpan.Parse("10:59");
        //        TimeSpan ts11 = TimeSpan.Parse("11:59");
        //        TimeSpan ts12 = TimeSpan.Parse("12:59");
        //        TimeSpan ts13 = TimeSpan.Parse("13:59");
        //        TimeSpan ts14 = TimeSpan.Parse("14:59");
        //        TimeSpan ts15 = TimeSpan.Parse("15:59");
        //        TimeSpan ts16 = TimeSpan.Parse("16:59");
        //        TimeSpan ts17 = TimeSpan.Parse("17:59");
        //        TimeSpan ts18 = TimeSpan.Parse("18:59");
        //        TimeSpan ts19 = TimeSpan.Parse("19:59");
        //        TimeSpan ts20 = TimeSpan.Parse("20:59");


        //        foreach (Registro x in r) {
        //            TimeSpan aux = TimeSpan.Parse(x.HoraEntrada);
        //            if (aux <= ts8) {
        //                lxh.em8 = lxh.em8 + 1;
        //            } else if (aux > ts8 && aux <= ts9) {
        //                lxh.em9 = lxh.em9 + 1;
        //            } else if (aux > ts9 && aux <= ts10) {
        //                lxh.em10 = lxh.em10 + 1;
        //            }else if (aux > ts10 && aux <= ts11){
        //                lxh.em11 = lxh.em11 + 1;
        //            }else if (aux > ts11 && aux <= ts12){
        //                lxh.em12 = lxh.em12 + 1;
        //            }else if (aux > ts12 && aux <= ts13){
        //                lxh.et13 = lxh.et13 + 1;
        //            }else if (aux > ts13 && aux <= ts14){
        //                lxh.et14 = lxh.et14 + 1;
        //            }
        //            else if (aux > ts14 && aux <= ts15)
        //            {
        //                lxh.et15 = lxh.et15 + 1;
        //            }
        //            else if (aux > ts15 && aux <= ts16)
        //            {
        //                lxh.et16 = lxh.et16 + 1;
        //            }
        //            else if (aux > ts16 && aux <= ts17)
        //            {
        //                lxh.et17 = lxh.et17 + 1;
        //            }
        //            else if (aux > ts17 && aux <= ts18)
        //            {
        //                lxh.et18 = lxh.et18 + 1;
        //            }
        //            else if (aux > ts18 && aux <= ts19)
        //            {
        //                lxh.et19 = lxh.et19 + 1;
        //            }
        //            else if(aux > ts19)
        //            {
        //                lxh.et20 = lxh.et20 + 1;
        //            }
        //        }

        //        //obj week
        //        week w = new week();
        //        //DateTime dauxs = DateTime.Today.AddDays(-1);//ayer al inicio del dia
        //        //DateTime dauxe = DateTime.Today.AddTicks(-1);//ayer al termino del dia
        //        w.d0 = e;
        //        w.d1 = CalxDias(-1, h);
        //        w.d2 = CalxDias(-2, h);
        //        w.d3 = CalxDias(-3, h);
        //        w.d4 = CalxDias(-4, h);
        //        w.d5 = CalxDias(-5, h);
        //        w.d6 = CalxDias(-6, h);

        //        var result = new { r = 1, e, s , a, l = lxh, w};
                
        //        var n = "";
        //        var RJs = Json(result, JsonRequestBehavior.AllowGet);
        //        return RJs;
        //    }
        //    catch (Exception e) {
        //        var result = new { r = 0, error = e };

        //        var RJs = Json(result, JsonRequestBehavior.AllowGet);

        //        return RJs;
        //    }
        //}

        //public int CalxDias(int d, int h) {
        //    DateTime dauxs = DateTime.Today.AddDays(d);
        //    DateTime dauxe = DateTime.Today.AddTicks(d);

        //    if(d!= -1)
        //        dauxe = DateTime.Today.AddDays(d+1).AddTicks(d);

        //    var e = db.Registro.Select(x => x)
        //            .Where(x => x.FechaEntrada >= dauxs && x.FechaEntrada <= dauxe && x.UnidadMedica == h).Count();

        //    return e;

        //}

        //public class hours {
        //    public int em8 { set; get; } = 0;
        //    public int em9 { set; get; } = 0;
        //    public int em10 { set; get;} = 0;
        //    public int em11 { set; get; } = 0;
        //    public int em12 { set; get;} = 0;
        //    public int et13 { set; get; } = 0;
        //    public int et14 { set; get; } = 0;
        //    public int et15 { set; get; } = 0;
        //    public int et16 { set; get; } = 0;
        //    public int et17 { set; get; } = 0;
        //    public int et18 { set; get; } = 0;
        //    public int et19 { set; get; } = 0;
        //    public int et20 { set; get; } = 0;

        //}

        //public class week {
        //    public int d0 { set; get; }
        //    public int d1 { set; get; }
        //    public int d2 { set; get; }
        //    public int d3 { set; get; }
        //    public int d4 { set; get; }
        //    public int d5 { set; get; }
        //    public int d6 { set; get; }
        //}
    }
}