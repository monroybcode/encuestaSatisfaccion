using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    [Table("Funciones")]
    public class Funciones
    {
        [Key]
        public int Id_Funcion { get; set; }
        public string NombreCorto { get; set; }
        public string Nombre { get; set; }
        public bool Ind_Activo { get; set; }
    }
}