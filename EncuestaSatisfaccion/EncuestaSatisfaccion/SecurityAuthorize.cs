using EncuestaSatisfaccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncuestaSatisfaccion
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SecurityAuthorize : AuthorizeAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // If they are authorized, handle accordisngly
              if (this.AuthorizeCore(filterContext.HttpContext))
              {
                if (filterContext.HttpContext.Session.Keys.Count > 0)
                {
                    var URol = System.Web.HttpContext.Current.Session["RolId"].ToString();
                    var Controller = filterContext.Controller.ToString();
                    var function = filterContext.ActionDescriptor.ActionName;
                    var Acceso = true;

                 
                   if (Controller == "EncuestaSatisfaccion.Controllers.HomeController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F3"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }else if (Controller == "EncuestaSatisfaccion.Controllers.EntradaController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F4"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }
                    else if (Controller == "EncuestaSatisfaccion.Controllers.UsersController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F1"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }
                    else if (Controller == "EncuestaSatisfaccion.Controllers.RolesController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F2"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }
                    else if (Controller == "EncuestaSatisfaccion.Controllers.ReporteEController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F5"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }
                    else if (Controller == "EncuestaSatisfaccion.Controllers.ReporteVPController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F6"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }
                    else if (Controller == "EncuestaSatisfaccion.Controllers.DirectorioController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F7"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }
                    else if (Controller == "EncuestaSatisfaccion.Controllers.SincronizarController")
                    {
                        var Fn = System.Web.HttpContext.Current.Session["F8"].ToString();
                        if (Fn == "0" && URol != "a3eec76a-a5b5-446b-8c86-fe3a37e25c3c")
                        {
                            Acceso = false;
                        }
                    }

                    if (Acceso == true)
                    {
                        base.OnAuthorization(filterContext);
                    }
                    else
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                            filterContext.HttpContext.Items["AjaxPermissionDenied"] = true;
                        else
                            filterContext.HttpContext.Items["PageDenied"] = true;

                        base.HandleUnauthorizedRequest(filterContext);
                    }
                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                        filterContext.HttpContext.Items["AjaxPermissionDenied"] = true;
                    else
                        filterContext.HttpContext.Items["PageDenied"] = true;

                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                    filterContext.HttpContext.Items["AjaxPermissionDenied"] = true;
                else
                    filterContext.HttpContext.Items["PageDenied"] = true;

                base.HandleUnauthorizedRequest(filterContext);

            }
        }
    }
}