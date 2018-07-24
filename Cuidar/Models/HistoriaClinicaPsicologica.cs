using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class HistoriaClinicaPsicologica
    {
        public DateTime fechaDeConsulta { get; set; }
        public int edadDelPaciente { get; set; }
        public string motivoDeConsulta { get; set; }
        public string  antecedentesMedicos { get; set; }
        public string antecedentesPsicologicos { get; set; }
        public string antecedentesPersonales { get; set; }
        public string antecedentesFamiliares { get; set; }
        public string formulacionDiagnosticoPronostico { get; set; }
        public string PlanDeTratamiento { get; set; }
        public int vinculacionTipoId { get; set; }
        public int personaId { get; set; }
        public int documentoTipoId { get; set; }
        public int ciudadId { get; set; }
    }
}