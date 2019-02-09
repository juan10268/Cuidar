using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Paciente
    {
        public string fechaingreso { get; set; }
        public string fecharetiro { get; set; }
        public int rangosalario { get; set; }
        public int vinculacionTipoId { get; set; }
        public int personasId { get; set; }
        public int activacionId { get; set; }
        public string observaciones { get; set; }
        
    }
}