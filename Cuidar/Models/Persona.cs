using System;

namespace Cuidar.Models
{
    public class Persona
    {
        public int personaID { get; set; }
        public string personaNombre { get; set; }
        public string personaApellido1 { get; set; }
        public string personaApellido2 { get; set; }
        public DateTime personaFechaNacimiento { get; set; }
        public string personaTelefono { get; set; }
        public string personaDireccion { get; set; }
        public int personaEstadoCivil { get; set; }
        public int personaGenero { get; set; }
        public int personaCiudad { get; set; }
        public int personaTipoDocumento { get; set; }
        public int personaEscolaridad { get; set; }
        public int personaDepartamento { get; set; }
    }
}