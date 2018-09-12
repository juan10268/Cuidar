using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class EspecialistaController: ApiController
    {
        EspecialistaDB especialistaDB = new EspecialistaDB();

        [Route("api/Especialista/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarEspecialista(Especialista especialista)
        {
            especialistaDB.AgregarEspecialista(especialista);

        }
       [Route("api/Especialista/getEspecialista")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Especialista> getEspecialista()
        {
            return especialistaDB.getEspecialista();
        }
    }
}