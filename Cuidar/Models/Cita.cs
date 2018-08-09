﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuidar.Models
{
    public class Cita
    {
        public int pacienteID { get; set; }
        public int especialistaID { get; set; }
        public int citaID { get; set; }
        public string citaFecha { get; set; }
        public string citaHora { get; set; }
        public int estadoCitaID { get; set; }
    }
}