using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Paciente
    {
        public string acompañante { get; set; }
        public int vinculacionTipoId { get; set; }
        public int pacienteID { get; set; }
        public int documentoTipoId { get; set; }
        public int ciudadId { get; set; }
    }
}