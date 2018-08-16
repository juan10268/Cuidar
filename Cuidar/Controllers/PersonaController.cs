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
    public class PersonaController : ApiController
    {
        PersonaDB personaDB = new PersonaDB();
        Persona persona = new Persona();

        [Route("api/Persona/Agregar")]
        [HttpPost]
        [AllowAnonymous]
        public void RegistrarPersona(Persona persona)
        {
            personaDB.AgregarPersona(persona);
        }
        [Route("api/Persona/getInformacion")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Persona> getIdentificacionPersona(int id)
        {
            return personaDB.GetInformacionPersonaID(id);
        }
    }
}