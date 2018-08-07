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
    public class EstadoCitaController : ApiController
    {
        EstadoCitaDB estadoCitaDB = new EstadoCitaDB();

        [Route("api/EstadoCita/getEstadoCita")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<EstadoCita> getEstadoCita()
        {
            return estadoCitaDB.getEstadoCita();
        }
    }
}
