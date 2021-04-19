using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EncuestaSatisfaccion.Models
{
    [Table("UnidadesMedicas")]
    public class UnidadesMedicas
    {
        [Key]
        public int Id_UnidadMedica { get; set; }
        public int ClaveUnidad { get; set; }
        public string UnidadMedica { get; set; }
        public bool active { get; set; }
        public string Direccion { get; set; }
        public string UsuarioJuridico { get; set; }
        public string UsuarioCoordinador { get; set; }
        public string Domicilio { get; set; }
        public string Correo { get; set; }
        public int Consecutivo { get; set; }
    }
}