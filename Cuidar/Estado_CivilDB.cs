using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class Estado_CivilDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Estado_Civil> getEstadoCivil()
        {
            List<Estado_Civil> listaEstado_Civil = new List<Estado_Civil>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetEstado_Civil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Estado_Civil estado_civil = new Estado_Civil();
                    estado_civil.estado_civil_Id = Convert.ToInt16(rdr["stv_id"]);
                    estado_civil.estado_civil_Nombre = rdr["stv_nombre"].ToString();
                    listaEstado_Civil.Add(estado_civil);
                }
                con.Close();
            }
            return listaEstado_Civil;
        }
    }
}