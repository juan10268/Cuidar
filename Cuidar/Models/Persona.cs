namespace Cuidar.Models
{
    public class Persona
    {
        public int personaID { get; set; }
        public string personaNombre { get; set; }
        public string personaApellido1 { get; set; }
        public string personaApellido2 { get; set; }
        public string personaFechaNacimiento { get; set; }
        public string personaTelefono { get; set; }
        public string personaDireccion { get; set; }
        public string personaEstadoCivil { get; set; }
        public string personaGenero { get; set; }
        public int personaCiudad { get; set; }
        public int personaTipoDocumento { get; set; }
        public int personaTipoVinculacion { get; set; }
    }
}