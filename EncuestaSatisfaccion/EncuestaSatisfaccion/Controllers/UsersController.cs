using EncuestaSatisfaccion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestaSatisfaccion.Controllers
{
    [SecurityAuthorize]
    public class UsersController : Controller
    {
        // GET: Users
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: AdminUsers
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var Usuario = Session["UserID"].ToString();
            var userRoles = UserManager.GetRoles(Usuario);
            Session["Rol"] = userRoles[0];
            var RID = Session["Rol"].ToString();
            var ObtenerRol = (from Rl in db.Roles where Rl.Name == RID select Rl).FirstOrDefault();
            Session["RolId"] = ObtenerRol.Id.ToString();
            var Rol = Session["RolId"].ToString();
            if (Rol == "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
            {
                var UMPU = (from PUUM in db.UnidadesMedicas
                            where PUUM.active == true
                            select PUUM).ToList();
                ViewBag.UniMed = UMPU;
            }
            else
            {
                var UMPU = (from PUUM in db.UsuarioxUmedica
                            join Unimed in db.UnidadesMedicas on PUUM.UserID equals Usuario
                            where Unimed.Id_UnidadMedica == PUUM.Id_unidad && PUUM.UserID == Usuario
                            select Unimed).ToList();
                ViewBag.UniMed = UMPU;
            }

            var Usuarios = (from Us in db.Users
                            select new Tbluser { Id = Us.Id, UserName = Us.UserName, IndAct = Us.IndAct, NombreCompleto = Us.NombreCompleto, Email = Us.Email, Rol = (from r in db.Roles where r.Id == Us.Roles.FirstOrDefault().RoleId select r.Name).FirstOrDefault() }).OrderBy(x=>x.UserName).ToList();

            ViewBag.Usuarios = Usuarios;
            var Roles = (from a in db.ApplicationRole
                         where a.Ind_Activo == true
                         select a
            ).ToList();
            ViewBag.Roles = Roles;

            //var direcciones = db.Direcciones.Where(x => x.active == true).ToList();
            //ViewBag.Direc = direcciones;

            //var Grupos = db.Grupos_Chat.Where(x => x.Active == true).Select(x => new ChatG { Id = x.Id_CG, Descripcion = x.Descripcion }).ToList();
            //ViewBag.Grupos = Grupos;

            return View();
        }
        public ActionResult IndexP()
        {
            var Usuario = Session["UserID"].ToString();
            var userRoles = UserManager.GetRoles(Usuario);
            Session["Rol"] = userRoles[0];
            var RID = Session["Rol"].ToString();
            var ObtenerRol = (from Rl in db.Roles where Rl.Name == RID select Rl).FirstOrDefault();
            Session["RolId"] = ObtenerRol.Id.ToString();
            var Rol = Session["RolId"].ToString();
            if (Rol == "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
            {
                var UMPU = (from PUUM in db.UnidadesMedicas
                            where PUUM.active == true
                            select PUUM).ToList();
                ViewBag.UniMed = UMPU;
            }
            else
            {
                var UMPU = (from PUUM in db.UsuarioxUmedica
                            join Unimed in db.UnidadesMedicas on PUUM.UserID equals Usuario
                            where Unimed.Id_UnidadMedica == PUUM.Id_unidad && PUUM.UserID == Usuario
                            select Unimed).ToList();
                ViewBag.UniMed = UMPU;
            }

            var Usuarios = (from Us in db.Users
                            select new Tbluser { Id = Us.Id, UserName = Us.UserName, IndAct = Us.IndAct, NombreCompleto = Us.NombreCompleto, Email = Us.Email, Rol = (from r in db.Roles where r.Id == Us.Roles.FirstOrDefault().RoleId select r.Name).FirstOrDefault() }).OrderBy(x => x.UserName).ToList();

            ViewBag.Usuarios = Usuarios;
            var Roles = (from a in db.ApplicationRole
                         where a.Ind_Activo == true
                         select a
               ).ToList();
            
            ViewBag.Roles = Roles;


            //var direcciones = db.Direcciones.Where(x => x.active == true).ToList();
            //ViewBag.Direc = direcciones;

            //var Grupos = db.Grupos_Chat.Where(x => x.Active == true).Select(x => new ChatG { Id = x.Id_CG, Descripcion = x.Descripcion }).ToList();
            //ViewBag.Grupos = Grupos;

            return PartialView("Index");
        }

        public class Tbluser
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string NombreCompleto { get; set; }
            public string Email { get; set; }
            public bool IndAct { get; set; }
            public string  Rol { get; set; }
        }

        // GET: AdminUsers/Details/5
        public ActionResult GetUSer(string Id_User)
        {
            try
            {
                var query = (from User in db.Users
                             where User.Id == Id_User.ToString()
                             select new
                             {
                                 Id_Usuario = User.Id,
                                 nomcom = User.NombreCompleto,
                                 email = User.Email,
                                 username = User.UserName,
                                 Roles = (from r in db.Roles where r.Id == User.Roles.FirstOrDefault().RoleId select r.Name).FirstOrDefault()
                             }).FirstOrDefault();
                var uniMed = (from Med in db.UsuarioxUmedica
                              join user in db.Users on Med.UserID equals user.Id
                              where Med.UserID == Id_User
                              select Med.Id_unidad).ToList();
                var result = new { User = query, Umed = uniMed};

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Error = "ErrorDetails" });
            }

        }

        // GET: AdminUsers/Create
        public ActionResult ResetPass(string Id, string Contraseña) {
            try
            {
                var user = UserManager.FindById(Id);
                if (user == null)
                {
                    // No revelar que el usuario no existe
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                var result =  UserManager.ResetPassword(user.Id, UserManager.GeneratePasswordResetToken(user.Id),Contraseña);
                if (result.Succeeded)
                {
                    var r= new { User = user, R = 1 };
                    return Json(r, JsonRequestBehavior.AllowGet);
                }
                else {
                    var r = new { msg= result.Errors, R = 2 };
                    return Json(r, JsonRequestBehavior.AllowGet);
                }
               

                
            }
            catch (Exception e)
            {
                return Json(new { Error = "ErrorDetails" });
            }

        }

        // GET: AdminUsers/Create
        public ActionResult Create(string Id, string NombreCompleto, string Email, string UserName, string CeSa, string RoleId, string Contraseña, string Direc, string Grupos)
        {
            try
            {
                var Estatus = false;
                var cesa = CeSa.Split(',');
                var userFac = new ApplicationUser();
                var query = (from User in db.Users
                             where User.Id == Id
                             select new { User.Id, User.UserName, User.Email }).ToList();

                if (query.Count == 0)
                {
                    var queryNN = (from NN in db.Users
                                   where NN.UserName == UserName || NN.Email == Email
                                   select NN).ToList();

                    if (queryNN.Count > 0)
                    {
                        return Json(new { R=0, Error = "El usuario ya existe en la base de datos" });
                    }
                    else
                    {
                        userFac = new ApplicationUser
                        {
                            NombreCompleto = NombreCompleto,
                            UserName = UserName,
                            Email = Email,
                            IndAct = true

                        };
                        if (Contraseña == null || Contraseña == "")
                        {
                            Contraseña = "Inicio.18";
                            userFac.PasswordHash = UserManager.PasswordHasher.HashPassword(Contraseña);
                        }
                        else {
                            userFac.PasswordHash = UserManager.PasswordHasher.HashPassword(Contraseña);
                        }

                        var TodoOk = UserManager.Create(userFac, Contraseña);


                        if (TodoOk.Succeeded)
                        {
                            string cesas = "";
                            if (cesa.Length > 0)
                            {
                                for (var i = 0; i < cesa.Length; i++)
                                {
                                    try
                                    {
                                        var aux = Convert.ToInt32(cesa[i]);
                                        var hospital = (from hospT in db.UnidadesMedicas
                                                        join UxUM in db.UsuarioxUmedica on hospT.Id_UnidadMedica equals UxUM.Id_unidad
                                                        where hospT.Id_UnidadMedica == aux && UxUM.UserID == userFac.Id
                                                        select hospT).FirstOrDefault();
                                        if (hospital == null)
                                        {
                                            var permisosHospital = new UsuarioxUmedica
                                            {
                                                UserID = userFac.Id,
                                                Id_unidad = aux
                                            };

                                            db.UsuarioxUmedica.Add(permisosHospital);
                                            db.SaveChanges();
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        var xxx = ":(";
                                    }

                                }
                            }
                            else
                            {
                                return Json(new { Error = "ErrorCesa" });
                            }
                            var result = UserManager.AddToRole(userFac.Id, RoleId);
                        }
                        else {
                            return Json(new { R = 2, Id = userFac.Id, msg= TodoOk.Errors.First() });
                        }
                        Estatus = userFac.IndAct;
                        return Json(new { R = 1, Id = userFac.Id, Est = Estatus });
                    }

                }
                else
                {
                    try
                    {
                        if (Contraseña == null)
                            Contraseña = "";

                        userFac = UserManager.FindById(query[0].Id);
                        userFac.NombreCompleto = NombreCompleto;
                        userFac.Email = Email;
                        var adminresult = UserManager.Update(userFac);
                        var usuarioH = (from puh in db.UsuarioxUmedica where puh.UserID == userFac.Id select puh).ToList();
                        foreach (UsuarioxUmedica item in usuarioH)
                        {
                            db.UsuarioxUmedica.Remove(item);
                            db.SaveChanges();
                        }
                        string cesas = "";
                        if (cesa.Length > 0)
                        {
                            for (var i = 0; i < cesa.Length; i++)
                            {
                                try
                                {
                                    var aux = Convert.ToInt32(cesa[i]);
                                    var hospital = (from hospT in db.UnidadesMedicas
                                                    join UxUM in db.UsuarioxUmedica on hospT.Id_UnidadMedica equals UxUM.Id_unidad
                                                    where hospT.Id_UnidadMedica == aux && UxUM.UserID == userFac.Id
                                                    select hospT).FirstOrDefault();
                                    if (hospital == null)
                                    {
                                        var permisosHospital = new UsuarioxUmedica
                                        {
                                            UserID = userFac.Id,
                                            Id_unidad = aux
                                        };

                                        db.UsuarioxUmedica.Add(permisosHospital);
                                        db.SaveChanges();
                                    }
                                }
                                catch (Exception e)
                                {
                                    var Error = ":(";
                                }
                            }
                        }
                        //AltaDireccionesU(Direc, userFac.Id);
                        var roles = UserManager.GetRoles(query[0].Id);
                        UserManager.RemoveFromRoles(query[0].Id, roles.ToArray());
                        var result = UserManager.AddToRole(userFac.Id, RoleId);
                        //var gr = Grupos.Split(',');
                        //PUsGr(userFac.Id, gr);

                    }

                    catch (Exception e)

                    {
                        return Json(new { R = 0 });
                    }

                }
                Estatus = userFac.IndAct;
                return Json(new { R = 1, Id = userFac.Id, Est = Estatus });


            }
#pragma warning disable CS0168 // La variable 'e' se ha declarado pero nunca se usa
            catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' se ha declarado pero nunca se usa
            {
                return Json(new { R = 0 });
            }
        }




        public ActionResult AccionesUsuario(string Id_Usuario, bool Est)
        {
            try
            {
                var Data = db.Users.Find(Id_Usuario);
                Data.IndAct = Est;
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();

                var result = new { R = 1 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
#pragma warning disable CS0168 // La variable 'e' se ha declarado pero nunca se usa
            catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' se ha declarado pero nunca se usa
            {
                var result = new { R = 0 };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}