using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    [Table("UsuarioxUmedica")]
    public class UsuarioxUmedica
    {
        [Key]
        public Int32 Id_UUN { get; set; }
        public Int32 Id_unidad { get; set; }
        [ForeignKey("Id_unidad")]
        public virtual UnidadesMedicas IdUnidad { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser IdApplicationUser { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
    }
}