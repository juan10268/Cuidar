using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class RangoSalarialDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<RangoSalarial> getRangoSalarial()
        {
            List<RangoSalarial> listaRangoSalarial = new List<RangoSalarial>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetRangoSalario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RangoSalarial rangoSalarial = new RangoSalarial();
                    rangoSalarial.RangoSalario_Id = Convert.ToInt16(rdr["ransalarial_id"]);
                    rangoSalarial.RangoSalario_Nombre = rdr["ransalarial_nombre"].ToString();
                    listaRangoSalarial.Add(rangoSalarial);
                }
                con.Close();
            }
            return listaRangoSalarial;
        }
    }
}