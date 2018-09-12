using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class PacienteController : ApiController
    {
        PacienteDB pacienteDB = new PacienteDB();

        [Route("api/Paciente/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarPaciente(Paciente paciente)
        {
            pacienteDB.AgregarPaciente(paciente);
        }
        [Route("api/Paciente/getPacientes")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Paciente> getPacientes()
        {
            return pacienteDB.getPacientes();
        }
        [Route("api/Paciente/getPacientesid")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Paciente> getPacientesid(int pacienteID)
        {
            return pacienteDB.getPacientesid(pacienteID);
        }
        [Route("api/Paciente/Editar")]
        [HttpPost]
        [AllowAnonymous]
        public void EditarPersona(Paciente paciente)
        {
            pacienteDB.EditarPaciente(paciente);
        }
    }
}