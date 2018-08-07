using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cuidar.Models;
using System.Data.SqlClient;
using System.Data;

namespace Cuidar.Base_Datos
{
    public class CitaDB
    {
        ContextDB contextDB = new ContextDB();

        public void AgregarCita(Cita cita)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spAgregarCita", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@paciente_id", cita.pacienteID);
                cmd.Parameters.AddWithValue("@especialista_id", cita.especialistaID);
                cmd.Parameters.AddWithValue("@cita_id", cita.citaID);
                cmd.Parameters.AddWithValue("@cita_fecha", cita.citaFecha);
                cmd.Parameters.AddWithValue("@cita_hora", cita.citaHora);
                cmd.Parameters.AddWithValue("@estadocita_id", cita.estadoCitaID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }        
    }
}