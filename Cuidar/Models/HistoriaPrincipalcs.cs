using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class HistoriaPrincipalcs
    {
        public int rangoDeSalario { get; set; }
        public string antecedentesHospitalarios { get; set; }
        public int vinculacionTipoId { get; set; }
        public int personaId { get; set; }
        public int documentoTipoId { get; set; }
        public int ciudadId { get; set; }
    }
}