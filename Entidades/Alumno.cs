using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Preinscripcion.Entidades
{
    [Table("Alumno")]
    public class Alumno : Persona
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // PK autoincremental (Identity column)
        //public int AlumnoId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // PK autoincremental (Identity column)
        public Int32 Legajo { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public string Mail { get; set; }
        public string Domicilio { get; set; }
        public string NomyApePMT { get; set; }
        public string NombreColegio { get; set; }
        public string TituloColegio { get; set; }
        public string  Emancipacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public int EstadoCivilId { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public int NacionalidadId { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        public int Localidad1Id { get; set; }
        //public virtual Localidad LugarNacimiento { get; set; }
        public int Localidad2Id { get; set; }
        //public virtual Localidad LugarDomicilio { get; set; }
        public int Provincia1Id { get; set; }
        //public virtual Provincia ProvinciaNacimiento { get; set; }
        public int Provincia2Id { get; set; }
        //public virtual Provincia ProvinciaDomicilio { get; set; }
        public int CarreraId { get; set; }
        public virtual Carrera Carrera { get; set; }


        //VER ARCHIVOS
        //public FileStream FotoCarnet { get; set; }
        //public FileStream FotocDoc { get; set; }
        //public FileStream FotocAnalitico { get; set; }
        //public FileStream CertifTrabajo { get; set; }

    }
}
