using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class EstadoCitaDB
    {
        ContextDB contextDB = new ContextDB();

        public IEnumerable<EstadoCita> getEstadoCita()
        {
            List<EstadoCita> listaEstadoCita = new List<EstadoCita>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("getEstadoCita", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EstadoCita estadoCita = new EstadoCita();
                    estadoCita.EstadoCitaID = Convert.ToInt16(rdr["estadocita_id"]);
                    estadoCita.EstadoCitaNombre = rdr["estadocita_nombre"].ToString();
                    listaEstadoCita.Add(estadoCita);
                }
                con.Close();
            }
            return listaEstadoCita;
        }
    }
}