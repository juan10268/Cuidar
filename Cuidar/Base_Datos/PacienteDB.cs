using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Cuidar.Base_Datos
{
    public class PacienteDB
    {
        ContextDB contextDB = new ContextDB();

        public void AgregarPaciente(Paciente paciente)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spAgregarPaciente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@per_id", paciente.pacienteID);
                cmd.Parameters.AddWithValue("@doc_tip_id", paciente.documentoTipoId);
                cmd.Parameters.AddWithValue("@ciudad_id", paciente.ciudadID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }       
    }
}