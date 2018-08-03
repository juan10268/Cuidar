using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuidar.Controllers
{
    public class GeneroController : ApiController
    {
        GeneroDB generoDB = new GeneroDB();

        public ICollection<Genero> getGenero()
        {
            return generoDB.getGenero(); 
        }
    }
}
