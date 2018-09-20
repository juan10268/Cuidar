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

        [Route("api/Persona/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarPersona(Persona persona)
        {
            personaDB.AgregarPersona(persona);
        }

        [Route("api/Persona/getPersonas")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> getPersonas()
        {
            return personaDB.getPersonas();
        }

        [Route("api/Persona/Editar")]
        [HttpPost]
        [AllowAnonymous]
        public void EditarPersona(Persona persona)
        {
            personaDB.EditarPersona(persona);
        }

        [Route("api/Persona/getPacienteInfo")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> getInfoPaciente(int idPaciente)
        {
            return personaDB.getPersonasPaciente(idPaciente);               
        }
    }
}