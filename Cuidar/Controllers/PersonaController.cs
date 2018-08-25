using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class PersonaController : ApiController
    {
        PersonaDB personaDB = new PersonaDB();
        Persona persona = new Persona();

        [Route("api/Persona/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarPersona(Persona persona)
        {
            personaDB.AgregarPersona(persona);
        }
        [Route("api/Persona/GetPersonaPorId")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> GetPersonaPorID(int id)
        {
            return personaDB.GetPersonaPorID(id);
        }
        [Route("api/Persona/PersonaPaciente")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> GetPersonaPaciente(int id)
        {
            return personaDB.GetPersonasPaciente(id);
        } 
    }
}