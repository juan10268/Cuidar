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
    public class HistoriaGeneralController : ApiController
    {
        HistoriaClinicaGeneralDB historiaClinicaGeneralDB = new HistoriaClinicaGeneralDB();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/HistoriaGeneral/Agregar")]
        public void agregarHistoriaClinicaGeneral(HistoriaClinicaGeneral historiaClinicaGeneral)
        {
            historiaClinicaGeneralDB.agregarHistoriaClinicaGeneral(historiaClinicaGeneral);
        }         
    }
}
