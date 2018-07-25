using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class CiudadDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Ciudad> getCiudades()
        {
            List<Ciudad> listaCiudades = new List<Ciudad>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetCiudades", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.ciudadId = Convert.ToInt16(rdr["ciudad_id"]);
                    ciudad.ciudadNombre = rdr["ciud_nomb"].ToString();
                    listaCiudades.Add(ciudad);
                }
                con.Close();
            }
            return listaCiudades;
        }
    }
}