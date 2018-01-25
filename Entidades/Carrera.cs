using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Entidades
{
    [Table("Carrera")]
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }
        public string Nombre { get; set; }

    }
}