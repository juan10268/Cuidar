using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Observaciones
    {
        public string detallePaciente { get; set; }
        public int vinculacionTipoID { get; set; }
        public int personaID { get; set; }
        public int documentoTipoID { get; set; }
        public int ciudadID { get; set; }
    }
}