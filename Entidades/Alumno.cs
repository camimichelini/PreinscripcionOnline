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
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // PK autoincremental (Identity column)
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

        [ForeignKey("EstadoCivil")]
        public int EstadoCivilId { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        [ForeignKey("Nacionalidad")]
        public int NacionalidadId { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        [ForeignKey("Sexo")]
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }
        //[ForeignKey("LugarNacimiento")]
        public int Localidad1Id { get; set; }
        public virtual Localidad LugarNacimiento { get; set; }
        //[ForeignKey("LugarDomicilio")]
        public int Localidad2Id { get; set; }
        public virtual Localidad LugarDomicilio { get; set; }
        //[ForeignKey("ProvinciaNacimiento")]
        public int Provincia1Id { get; set; }
        public virtual Provincia ProvinciaNacimiento { get; set; }
        //[ForeignKey("ProvinciaDomicilio")]
        public int Provincia2Id { get; set; }
        public virtual Provincia ProvinciaDomicilio { get; set; }
        [ForeignKey("Carrera")]
        public int CarreraId { get; set; }
        public virtual Carrera Carrera { get; set; }

        //public byte?[] FotoCarnet { get; set; }
        public byte[] FotoCarnet { get; set; }
        public byte[] FotoDoc { get; set; }
        public byte[] Analitico { get; set; }
        public byte[] CertificadoTrabajo { get; set; }
    }
}
