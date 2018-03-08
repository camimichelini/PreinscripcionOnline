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
    [Table("PreinscripcionOnline")]
    public class PreinscripcionOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // PK autoincremental (Identity column)
        public int PreinscripcionId { get; set; }
        public int PersonaId { get; set; }
        public int TurnoId { get; set; }

    }
}
