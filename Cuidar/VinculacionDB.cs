using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class VinculacionDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Vinculacion> getVinculacion()
        {
            List<Vinculacion> listaVinculacion = new List<Vinculacion>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetVinculacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Vinculacion vinculacion = new Vinculacion();
                    vinculacion.vinculacionTipoId = Convert.ToInt16(rdr["tipo_vinculacion_id"]);
                    vinculacion.vinculacionTipoNombre = rdr["tipo_vinculacion_nombre"].ToString();
                    listaVinculacion.Add(vinculacion);
                }
                    con.Close();
                }
                return listaVinculacion;
            }
        }
    }
