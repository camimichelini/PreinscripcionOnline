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
    [Table("Persona")]
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // PK autoincremental (Identity column)
        public Int64 PersonaId { get; set; }


        public string Nombre { get; set; }


        public string Apellido { get; set; }

        public int TipoDocId { get; set; }
        public virtual TipoDoc TipoDoc { get; set; }

        public int NroDoc { get; set; }

    }
}
