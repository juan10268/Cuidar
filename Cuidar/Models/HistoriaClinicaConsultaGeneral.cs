using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class HistoriaClinicaConsultaGeneral
    {
        public int pesoPaciente { get; set; }
        public int talla { get; set; }
        public int indiceDeMasaCorporal { get; set; }
        public string diagnostico { get; set; }
        public string antecedentesPersonales { get; set; }
        public string antecedentesAlergicos { get; set; }
        public string antecedentesQuirurgicos { get; set; }
        public string antecedentesFamiliares { get; set; }
        public string craneo { get; set; }
        public string ojos { get; set; }
        public string fondoDeLosOjos { get; set; }
        public string oidos { get; set; }
        public string boca { get; set; }
        public string nariz { get; set; }
        public string garganta { get; set; }
        public string cuello { get; set; }
        public string torax { get; set; }
        public string pulmones { get; set; }
        public string cardiovascular { get; set; }
        public string abdomen { get; set; }
        public string genitalesExternos { get; set; }
        public string pielYfaneras { get; set; }
        public string muscoesqueletico { get; set; }
        public string tactoRectal { get; set; }
        public string tactoVaginal { get; set; }
        public string neurologico { get; set; }
        public string motilidad { get; set; }
        public string reflejos { get; set; }
        public string otros { get; set; }
        public string observaciones { get; set; }
        public string pendientes { get; set; }
        public int vinculacionTipoId { get; set; }
        public int personaId { get; set; }
        public int documentoTipoId { get; set; }
        public int ciudadId { get; set; }
                
    }
}