using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class EspecialidadController : ApiController
    {
        EspecialidadDB especialidadDB = new EspecialidadDB();

        [Route("api/Especialidades/getEspecialidades")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Especialidad> getEspecialidades()
        {
            return especialidadDB.getEspecialidades();
        }
    }
}