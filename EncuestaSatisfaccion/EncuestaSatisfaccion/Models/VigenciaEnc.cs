using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    [Table("VigenciaEnc")]
    public class VigenciaEnc
    {
        [Key]
        public int Id { set; get; }
        
        public int Dias { set; get; }

        public bool Activo { get; set; }
        public DateTime FechaAlta { set; get; }
        public string UserCap { get; set; }
        [ForeignKey("UserCap")]
        public virtual ApplicationUser IdApplicationUser { get; set; }
       

    }
}