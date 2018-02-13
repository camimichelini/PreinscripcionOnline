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
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Numero de Documento")]
        public int NroDoc { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar un Tipo de Documento")]
        public virtual TipoDoc TipoDoc { get; set; }
                
    }
}
