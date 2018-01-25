using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Entidades
{
    [Table("Provincia")]
    public   class Provincia
    {
        [Key]
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
        public virtual Pais Pais { get; set; }
        
    }
}
