﻿using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class CiudadController : ApiController
    {
        CiudadDB ciudadDB = new CiudadDB();

        [Route("api/Ciudades/getCiudades")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Ciudad> getDocumentos()
        {
            return ciudadDB.getCiudades();
        }

        [Route("api/Ciudades/getCiudadDepartamento")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Ciudad> getCiudadesPorDepartamento(int idDepartamento)
        {
            return ciudadDB.getCiudadesPorDepartamento(idDepartamento);
        }
    }
}
