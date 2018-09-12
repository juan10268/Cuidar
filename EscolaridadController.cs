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
    public class EscolaridadController : ApiController
    {
        EscolaridadDB escolaridadDB = new EscolaridadDB();

    [Route("api/Escolaridades/getEscolaridades")]
    [HttpGet]
    [AllowAnonymous]
        public IEnumerable<Escolaridad> getEscolaridades()
        {
            return escolaridadDB.getEscolaridades();
        }
    }
}