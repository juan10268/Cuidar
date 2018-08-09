using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class TipoAntecedentesDB
    {
        ContextDB contextDB = new ContextDB();

        public IEnumerable<TipoAntecedentes> GetTipoAntecedentes()
        {
            List<TipoAntecedentes> listaTipoAntecedentes = new List<TipoAntecedentes>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetTipoAntecedentes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TipoAntecedentes tipoAntecedentes = new TipoAntecedentes();
                    tipoAntecedentes.TipoAntecedentesID = Convert.ToInt16(rdr["estadocita_id"]);
                    tipoAntecedentes.TipoAntecedentesNombre = rdr["estadocita_nombre"].ToString();
                    listaTipoAntecedentes.Add(tipoAntecedentes);
                }
                con.Close();
            }
            return listaTipoAntecedentes;
        }
    }
}