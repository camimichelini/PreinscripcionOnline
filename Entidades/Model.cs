using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Preinscripcion.Entidades;

namespace Preinscripcion.Entidades
{
    public class Model
    {
        //    public string Nombre { get; set; }
        //    public string Apellido { get; set; }
        //    public int NroDoc { get; set; }
        //    public DateTime FechaNacimiento { get; set; }
        //    public Boolean Enmancipacion { get; set; }
        //    public string FotoCarnet { get; set; }
        //    public string FotocopiaDoc { get; set; }
        //    public string CertificadoTrabajo { get; set; }
        //    public string NombreColegio { get; set; }
        //    public string TituloColegio { get; set; }
        //    public string TipoAnalitico { get; set; }
        //    public string FotocAnalitico { get; set; }
        //    public string Domicilio { get; set; }
        //    public int Telefono { get; set; }
        //    public int Celular { get; set; }
        //    public string Mail { get; set; }
        public List<Sexo> Sexo { get; set; }
        public List<TipoDoc> TipoDoc { get; set; }
        public List<Nacionalidad> Nacionalidad { get; set; }
        public List<Provincia> Provincia { get; set; }
        public List<Localidad> Localidad { get; set; }
        public List<Carrera> Carrera { get; set; }
        public List<EstadoCivil> EstadoCivil { get; set; }
    }
}
