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
        public void Registrar(Persona persona)
        {
            personaDB.AgregarPersona(persona);
        }
    }
}
