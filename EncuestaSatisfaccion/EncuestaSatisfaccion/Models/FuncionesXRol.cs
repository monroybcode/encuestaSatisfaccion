using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    public class FuncionesXRol
    {
        [Key]
        public int Id_FuncionesXRol { get; set; }
        public int Id_Funcion { get; set; }
        [ForeignKey("Id_Funcion")]
        public virtual Funciones IdFun { get; set; }
        public string Id_Rol { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public string UserID { get; set; } = HttpContext.Current.Session.Count > 0 ? HttpContext.Current.Session["UserID"].ToString() : "";
        [ForeignKey("UserID")]
        public virtual ApplicationUser IdApplicationUser { get; set; }
    }
}