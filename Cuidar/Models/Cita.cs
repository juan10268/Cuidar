using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Cita
    {
        public DateTime fecha { get; set; }
        public int hora { get; set; }
        public string especialista { get; set; }
        public string paciente { get; set; }
        public int vinculacionTipoId { get; set; }
        public int personaId { get; set; }
        public int documentoTipoId { get; set; }
        public int ciudadId { get; set; }


    }
}