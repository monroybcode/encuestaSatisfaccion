using EncuestaSatisfaccion.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestaSatisfaccion.Controllers
{
    [SecurityAuthorize]
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            ViewBag.Roles = (from a in db.Roles select a ).OrderBy(x => x.Name).ToList();
            ViewBag.Funciones = (from F in db.Funciones orderby F.Nombre where F.Ind_Activo == true select F).ToList();
        
            return View();
        }

        public ActionResult IndexP()
        {
            ViewBag.Roles = (from a in db.Roles select a).OrderBy(x => x.Name).ToList();
            ViewBag.Funciones = (from F in db.Funciones orderby F.Nombre where F.Ind_Activo == true select F).ToList();
           
            return PartialView("Index");
        }
        public ActionResult ObtenerInfoRol(string Rid)
        {
            try
            {
                var ObtenerRol = (from RL in db.Roles where RL.Id == Rid select new { RL.Id, RL.Name }).FirstOrDefault();
                var FxR = (from FR in db.FuncionesXRol where FR.Id_Rol == ObtenerRol.Id select FR.Id_Funcion).ToList();
            
                var result = new { Roles = ObtenerRol, FxR = FxR };
                var RJs = Json(result, JsonRequestBehavior.AllowGet);
                RJs.MaxJsonLength = 2147483644;
                return RJs;
            }
            catch (Exception e)
            {
                return Json(new { Error = "error" });
            }
        }
        public ActionResult GRolD(string RId, string RN, int[] Func)
        {
            try
            {

                var EResp = 0;
                var RolId = RId;
                if (RId == "")
                {
                    var ExisteRol = (from RL in db.Roles where RL.Name == RN select RL).Count();
                    if (ExisteRol == 0)
                    {
                        IdentityRole Rol = new IdentityRole
                        {
                            Name = RN,

                        };
                        db.Roles.Add(Rol);
                        db.SaveChanges();
                        RolId = Rol.Id;

                        new FuncionesGenericas().EjectQ("UPDATE dbo.AspNetRoles SET Ind_Activo = 1, Discriminator = 'ApplicationRole' where Id = '" + RolId + "'");
                    }
                    else
                    {
                        var result2 = new { Resp = 2, RolId = RolId };
                        var RJs2 = Json(result2, JsonRequestBehavior.AllowGet);
                        return RJs2;
                    }

                }
                else
                {
                    var Rol = db.Roles.Find(RId.ToString());
                    Rol.Name = RN;
                    db.Entry(Rol).State = EntityState.Modified;
                    db.SaveChanges();
                    RolId = Rol.Id;
                }

                //CustomizeTiposRol(RolId, Tipos);

                var funcionesXRol = (from fr in db.FuncionesXRol where fr.Id_Rol.ToString() == RolId.ToString() select fr).ToList();
                foreach (FuncionesXRol fr in funcionesXRol)
                {
                    var existe = false;
                    foreach (int idFunc in Func)
                    {
                        if (idFunc == fr.Id_Funcion)
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (existe == false)
                    {
                        db.FuncionesXRol.Remove(fr);
                        db.SaveChanges();
                    }

                }

                if (Func != null)
                {
                    foreach (int idFunc in Func)
                    {
                        var existe = false;
                        foreach (FuncionesXRol fr2 in funcionesXRol)
                        {
                            foreach (int idFunc2 in Func)
                            {
                                if (idFunc == fr2.Id_Funcion)
                                {
                                    existe = true;
                                    break;
                                }
                            }
                        }
                        if (existe == false)
                        {
                            FuncionesXRol fr = new FuncionesXRol
                            {
                                Id_Rol = RolId,
                                Id_Funcion = idFunc
                            };

                            db.FuncionesXRol.Add(fr);
                            db.SaveChanges();
                        }
                    }
                }

                EResp = 1;
                var estatus = new FuncionesGenericas().EjectQJson("SELECT Ind_Activo from dbo.AspNetRoles where Id = '" + RolId + "'");

                var result = new { Resp = EResp, RolId = RolId, Est = estatus }; //
                var RJs = Json(result, JsonRequestBehavior.AllowGet);
                RJs.MaxJsonLength = 2147483644;
                return RJs;
            }
            catch (Exception e)
            {
                var result2 = new { Resp = 3, RolId = 0 };
                var RJs2 = Json(result2, JsonRequestBehavior.AllowGet);
                return RJs2;
            }
        }


        private void CustomizeTiposRol(string Rol, List<int> TiposId)
        {
          
            //if(TiposId != null)
            //{
            //    foreach (var item in TiposId)
            //    {
            //        TiposIXRol tir = new TiposIXRol
            //        {
            //            Id_Rol = Rol,
            //            TipoInventarioId = item
            //        };
            //        db.TiposIXRol.Add(tir);
            //        db.SaveChanges();
            //    }
            //}
         

        }

        public ActionResult AccionesRol(string Id_Rol, bool Est)
        {
            try
            {
                var Data = db.Roles.Find(Id_Rol);
                new FuncionesGenericas().EjectQ("UPDATE dbo.AspNetRoles SET Ind_Activo ='" + Est + "' where Id = '" + Id_Rol + "'");
                var result = new { R = 1 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var result = new { R = 0 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


    }
}