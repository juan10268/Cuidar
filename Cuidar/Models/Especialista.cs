using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Especialista
    {
        public int EspecialistaID { get; set; }
        public int EspecialistaEspecialidad { get; set; }
        public string EspecialistaIngreso { get; set; }
        public string EspecialistaRetiro { get; set; }
        public int EspecialistaVinculacion { get; set; }
    }
}