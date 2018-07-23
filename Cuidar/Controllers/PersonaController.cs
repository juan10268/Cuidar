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
        [Route("/api/Persona/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public string Registrar(Persona persona)
        {
            Console.Write("Llego");
        }
    }
}
