using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Especialista
    {
        public int especialistaID { get; set; }
        public int especialistaEspecialidad { get; set; }
        public string especialistaIngreso { get; set; }
        public string especialistaRetiro { get; set; }
        public int especialistaVinculacion { get; set; }
    }
}