using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Antecedentes
    {
        public int AntecedentesID { get; set; }
        public DateTime AntecedentesFecha { get; set; }
        public int AntecedentesTipoID { get; set; }
        public String AntecedentesDescripcion { get; set; }
    }
}