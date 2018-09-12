using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class EscolaridadDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Escolaridad> getEscolaridades()
        {
            List<Escolaridad> listaEscolaridad = new List<Escolaridad>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetEscolaridad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Escolaridad escolaridad = new Escolaridad();
                    escolaridad.escolaridadId = Convert.ToInt16(rdr["escolaridad_nivel"]);
                    escolaridad.escolaridadNombre = rdr["escolaridad_nombre"].ToString();
                    listaEscolaridad.Add(escolaridad);
                }
                con.Close();
            }
            return listaEscolaridad;
       
    }
}
}