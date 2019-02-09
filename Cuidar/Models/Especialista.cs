using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Especialista
    {
        public int especialidadId { get; set; }
        public int especialistaId { get; set; }
        public String especialistaFechaIngreso { get; set; }
        public String especialistaFechaRetiro { get; set; }
        public int tipo_vinculacion { get; set; }
        public string observaciones { get; set; }
    }
}