using Cuidar.Base_Datos;
using Cuidar.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class TipoDocumentoController : ApiController
    {
        TipoDocumentoDB tipoDocumentoDB = new TipoDocumentoDB();

        [Route("api/Documento/getDocumentos")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Documento> getDocumentos()
        {
            return tipoDocumentoDB.getDocumentos();
        }
    }
}
