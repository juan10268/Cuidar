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
    public class DepartamentoController : ApiController
    {
        DepartamentoDB departamentoDB = new DepartamentoDB();

        [Route("api/Departamento/getDepartamento")]
        [HttpGet]
        [AllowAnonymous]
        public ICollection<Departamento> getDepartamento()
        {
            return departamentoDB.getDepartamento();
        }
    }
}
