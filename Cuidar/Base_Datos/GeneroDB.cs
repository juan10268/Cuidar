using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class GeneroDB
    {
        ContextDB contextDB;
        public ICollection<Genero> getGenero()
        {
            using(SqlConnection con = contextDB.DbConnection())
            {
                List<Genero> listaGeneros = new List<Genero>();

            }
    }
}