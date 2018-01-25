using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Entidades
{
    [Table("Preinscripcion")]
    public class Preinscripcion
    {
        [Key]
        public int PreinscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

    }
}
