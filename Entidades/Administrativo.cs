using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Entidades
{
    [Table("Administrativo")]
    public class Administrativo : Persona
    {
        [Key]
        public int AdministrativoId { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}