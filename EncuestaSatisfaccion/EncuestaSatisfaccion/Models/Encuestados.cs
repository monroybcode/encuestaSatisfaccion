using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    [Table("Encuestados")]
    public class Encuestados
    {
        [Key]
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Apa { set; get; }
        public string Ama { set; get; }
        public string mail { set; get; }
        public string puesto { set; get; }
        public DateTime fechaAlta { set; get; }

        public DateTime? fechaContestado { set; get; }
        public string UserCap { get; set; }
        [ForeignKey("UserCap")]
        public virtual ApplicationUser IdApplicationUser { get; set; }
        public int Contestada { get; set; }
        public int DiasVig { get; set; }

        public bool Borrado { get; set; }

    }
}