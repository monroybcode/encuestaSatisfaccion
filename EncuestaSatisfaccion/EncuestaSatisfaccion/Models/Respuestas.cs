using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    [Table("Respuestas")]
    public class Respuestas
    {
        [Key]
        public int IdRegistro { set; get; }
        public int IdEncuestado { set; get; }
        [ForeignKey("IdEncuestado")]
        public virtual Encuestados EncuestadosId { set; get; }

        public string rp1 { set; get; }
        public string rp2 { set; get; }
        public string rp3 { set; get; }
        public string rp4 { set; get; }
        public string rp5 { set; get; }
        public string rp6 { set; get; }
        public string rp7 { set; get; }
        public string rp8 { set; get; }
        public string rp9 { set; get; }
        public string rp10 { set; get; }
        public string rp11 { set; get; }
        public string rp12 { set; get; }
        public string rp13 { set; get; }
        public string rp14 { set; get; }
        public string rp15 { set; get; }
        public string rp16 { set; get; }
        public string rp17 { set; get; }
        public string rp18 { set; get; }
        public string rp19 { set; get; }

    }

    public class listrepo{
        public int id { get; set; }
        public string nombre { set; get; }
        public string puesto { set; get; }
        public string contestado { set; get; }
        public DateTime fechaAlta { set; get; }
        public DateTime? fechaContestado { set; get; }
        public string rp1 { set; get; }
        public string rp2 { set; get; }
        public string rp3 { set; get; }
        public string rp4 { set; get; }
        public string rp5 { set; get; }
        public string rp6 { set; get; }
        public string rp7 { set; get; }
        public string rp8 { set; get; }
        public string rp9 { set; get; }
        public string rp10 { set; get; }
        public string rp11 { set; get; }
        public string rp12 { set; get; }
        public string rp13 { set; get; }
        public string rp14 { set; get; }
        public string rp15 { set; get; }
        public string rp16 { set; get; }
        public string rp17 { set; get; }
        public string rp18 { set; get; }
        public string rp19 { set; get; }
    }
}