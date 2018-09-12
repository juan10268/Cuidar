using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class Estado_ActivacionDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Estado_Activacion> getEstadoActivacion()
        {
            List<Estado_Activacion> listaEstado_Activacion = new List<Estado_Activacion>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetEstado_Activacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Estado_Activacion estado_activacion = new Estado_Activacion();
                    estado_activacion.estado_activacion_Id = Convert.ToInt16(rdr["activacion_id"]);
                    estado_activacion.estado_activacion_Nombre = rdr["activacion_nombre"].ToString();
                    listaEstado_Activacion.Add(estado_activacion);
                }
                con.Close();
            }
            return listaEstado_Activacion;
        }
    }
}