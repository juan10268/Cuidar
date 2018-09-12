using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class RangoSalarialController : ApiController
    {
        RangoSalarialDB rangoSalarialDB = new RangoSalarialDB();

        [Route("api/RangoSalarial/getRangoSalarial")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<RangoSalarial> getRangoSalarial()
        {
            return rangoSalarialDB.getRangoSalarial();
        }
    }
}