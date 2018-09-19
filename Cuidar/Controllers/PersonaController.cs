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
    public class PersonaController : ApiController
    {
        PersonaDB personaDB = new PersonaDB();

        [Route("api/Persona/getPacienteInfo")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> getInfoPaciente(int idPaciente)
        {
            return personaDB.getPersonasPaciente(idPaciente);               
        }
    }
}