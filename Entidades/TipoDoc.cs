using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Entidades
{
    [Table("TipoDoc")]
    public class TipoDoc
    {
        [Key]
        public int TipoDocId { get; set; }
        public string Descripcion { get; set; }

    }
}
