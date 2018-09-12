using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class DepartamentoController : ApiController
    {
        DepartamentoDB departamentoDB = new DepartamentoDB();

        [Route("api/Departamentos/getDepartamentos")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Departamento> getDepartamentos()
        {
            return departamentoDB.getDepartamentos();
        }
    }
}
