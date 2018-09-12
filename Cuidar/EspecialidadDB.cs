using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class EspecialidadDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Especialidad> getEspecialidades()
        {
            List<Especialidad> listaEspecialidad = new List<Especialidad>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetEspecialidades", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.especialidad_Id = Convert.ToInt16(rdr["especialidad_id"]);
                    especialidad.especialidad_Nombre = rdr["especialidad_nombre"].ToString();
                    listaEspecialidad.Add(especialidad);
                }
                con.Close();
            }
            return listaEspecialidad;

        }
    }
}