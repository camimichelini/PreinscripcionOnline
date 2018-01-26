using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Alumno")]
    public class Alumno : Persona
    {
        [Key]
        public int AlumnoId { get; set; }
        public int Legajo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set;  }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public EmailAddressAttribute Mail { get; set; }
        public Boolean Enmancipacion { get; set; }
        public string FotoCarnet { get; set; }
        public string FotocopiaDoc { get; set; }
        public string CertificadoTrabajo { get; set; }
        public string NombrColegio { get; set; }
        public string TituloColegio { get; set; }
        public string TipoAnalitico { get; set; }
        public string FotocAnalitico { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Localidad LugarNacimiento { get; set; }
        public virtual Localidad LugarDomicilio { get; set; }
    
    }
}
