using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers 
{
    public class VinculacionController : ApiController
    {
        VinculacionDB vinculacionDB = new VinculacionDB();

        [Route("api/Vinculacion/getVinculacion")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Vinculacion> getVinculacion()
        {
            return vinculacionDB.getVinculacion();
        }
    }
}