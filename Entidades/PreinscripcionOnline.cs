﻿using Preinscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preinscripcion.Entidades
{
    [Table("PreinscripcionOnline")]
    public class PreinscripcionOnline
    {
        [Key]
        public int PreinscripcionOnlineId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual Turno Turno { get; set; }
        

    }
}