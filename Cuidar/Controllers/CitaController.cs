﻿using Cuidar.Base_Datos;
using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class CitaController : ApiController
    {
        CitaDB citaDB = new CitaDB();

        [Route("api/Cita/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarCita(Cita cita)
        {
            citaDB.AgregarCita(cita);
        }        
    }
}
