using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Paciente
    {
        public int pacienteID { get; set; }
        public int rangoSalarialID { get; set; }
        public int vinculacionTipoId { get; set; }
        public string pacienteFechaIngreso { get; set; }
        public string pacienteFechaRetiro { get; set; }
        public int activacionID { get; set; }
    }
}