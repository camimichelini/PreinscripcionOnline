using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Models
{
    public class Modelo
    {
        //public List<Sexo>
        public List<Sexo> Sexo { get; set; }
        public List<TipoDoc> TipoDoc{ get; set; }
        public List<Nacionalidad> Nacionalidad { get; set; }
        public List<Provincia> Provincia { get; set; }
        public List<Localidad> Localidad { get; set; }
        public List<Carrera> Carrera { get; set; }
        public List<EstadoCivil> EstadoCivil { get; set; }

}
}