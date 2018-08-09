using Cuidar.Base_Datos;
using Cuidar.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class TipoAntecedentesController : ApiController
    {
        TipoAntecedentesDB tipoAntecedentesDB = new TipoAntecedentesDB();

        public IEnumerable<TipoAntecedentes> GetTipoAntecedentes()
        {
            return tipoAntecedentesDB.GetTipoAntecedentes();
        }
    }
}
