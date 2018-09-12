using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class Estado_ActivacionController : ApiController
    {
         Estado_ActivacionDB estadoActivacionDB = new Estado_ActivacionDB();

        [Route("api/EstadoActivacion/getEstadoActivacion")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Estado_Activacion> getEstadoActivacion()
        {
            return estadoActivacionDB.getEstadoActivacion();
        }
    }
}