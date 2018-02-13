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
    [Table("Alumno")]
    public class Alumno : Persona
    {
        [Key]
        public int AlumnoId { get; set; }
        public int Legajo { get; set; }

        [Required(ErrorMessage = "Debe infresar una fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar un domicilio")]
        public string Domicilio { get; set;  }

        [Required(ErrorMessage = "Debe ingresar un telefono")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar un celular")]
        public int Celular { get; set; }

        [Required(ErrorMessage = "Debe ingresar un mail")]
        [RegularExpression(@"^[0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@(ua)\.(es)$")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Debe elegir una opcion")]
        public Boolean Enmancipacion { get; set; }

        public string FotoCarnet { get; set; }

        public string FotocopiaDoc { get; set; }

        public string CertificadoTrabajo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Colegio")]
        public string NombreColegio { get; set; }

        [Required(ErrorMessage = "Debe ingresar el titulo obtenido del Colegio")]
        public string TituloColegio { get; set; }

        public string TipoAnalitico { get; set; }

        public string FotocAnalitico { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar un Estado Civil")]
        public virtual EstadoCivil EstadoCivil { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar una Nacionalidad")]
        public virtual Nacionalidad Nacionalidad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Sexo")]
        public virtual Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Localidad de Nacimiento")]
        public virtual Localidad LugarNacimiento { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Localidad de Domicilio")]
        public virtual Localidad LugarDomicilio { get; set; }

    }
}
