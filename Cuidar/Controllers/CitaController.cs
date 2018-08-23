using Cuidar.Base_Datos;
using Cuidar.Models;
using System.Collections.Generic;
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

        [Route("api/Cita/CitaPersona")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Cita> CitaPorPersona(int pacienteID)
        {
            return citaDB.getCitasPorPersona(pacienteID);
        }

        [Route("api/Cita/GetIDCita")]
        [HttpGet]
        [AllowAnonymous]
        public int GetIDCita()
        {
            return citaDB.GetIDCita();
        }
        
        [Route("api/Cita/DetalleCita")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Cita> DetalleCita(int idCita)
        {
            return citaDB.getCitaPorId(idCita);
        }
    }
}
