using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class Estado_CivilController : ApiController
    {
        Estado_CivilDB estadoCivilDB = new Estado_CivilDB();

        [Route("api/EstadoCivil/getEstadoCivil")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Estado_Civil> getEstadoCivil()
        {
            return estadoCivilDB.getEstadoCivil();
        }
    }
}