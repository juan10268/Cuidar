using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class HojaDeNutricionMayorDe18
    {
        public string motivoConsultaDelPaciente { get; set; }
        public string antecedentesPersonales { get; set; }
        public string antecedentesFamiliares { get; set; }
        public string antecedentesQuirurgicos { get; set; }
        public string historiaNutricional { get; set; }
        public string intolerancia { get; set; }
        public string rechazoAlimenticio { get; set; }
        public string lacteos { get; set; }
        public string proteinas { get; set; }
        public string quesoYsustitutos { get; set; }
        public string leguminosas { get; set; }
        public string frutas { get; set; }
        public string verduras { get; set; }
        public string tuberculos { get; set; }
        public string harinas { get; set; }
        public string dulces { get; set; }
        public string grasas { get; set; }
        public string snacks { get; set; }
        public string bebidasAzucaradas { get; set; }
        public int pesoAlNacer { get; set; }
        public int estaturaAlNacer { get; set; }
        public int pesoUsual { get; set; }
        public int pesoActual { get; set; }
        public int perimetroCefalico { get; set; }
        public int tallaActual { get; set; }
        public int pesoYtalla { get; set; }
        public int pesoYedad { get; set; }
        public int tallaYedad { get; set; }
        public int indiceDeMasaCorporalYedad { get; set; }
        public string diagnosticoSAntropologico { get; set; }
        public string analisisNutricional { get; set; }
        public string prscripcionDietaria { get; set; }
        public int vinculacionTipoId { get; set; }
        public int personaId { get; set; }
        public int documentoTipoId { get; set; }
        public int ciudadId { get; set; }
    }
}