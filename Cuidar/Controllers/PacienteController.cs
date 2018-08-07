using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class PacienteController : ApiController
    {
        PacienteDB pacienteDB = new PacienteDB();
        Paciente paciente = new Paciente();

        [Route("api/Paciente/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarPaciente(Paciente paciente)
        {
            pacienteDB.AgregarPaciente(paciente);
        } 
    }
}
