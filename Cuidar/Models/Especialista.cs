using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Especialista
    {
        public int personaId { get; set; }
        public int tipoDocumentoId { get; set; }
        public int ciudadId { get; set; }
        public int especialistaId { get; set; }
    }
}