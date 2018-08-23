﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int GetIDCita()
        {
            SqlConnection con = contextDB.DbConnection();
            SqlCommand cmd = new SqlCommand("GetIDCita", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int IDCita = Convert.ToInt32(rdr["cita_id"]);
            return IDCita;
        }

        private IEnumerable<Cita> getCitas()
        {
            List<Cita> listaCitas = new List<Cita>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("getCitas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cita cita = new Cita();
                    cita.pacienteID = Convert.ToInt16(rdr["paciente_id"]);
                    cita.citaID = Convert.ToInt16(rdr["cita_id"]);
                    cita.especialistaID = Convert.ToInt16(rdr["especialista_id"]);
                    cita.citaFecha = rdr["cita_fecha"].ToString();
                    cita.citaHora = rdr["cita_hora"].ToString();
                    cita.estadoCitaID = Convert.ToInt16(rdr["estadocita_id"]);
                    listaCitas.Add(cita);
                }
            }
            return listaCitas;
        }        
        public IEnumerable<Cita> getCitasPorPersona(int ID)
        {
            IEnumerable<Cita> getCitaResultado = getCitas();
            if (getCitaResultado.Any(c => c.pacienteID == ID))
            {
                return getCitaResultado;
            }
            else
            {
                return getCitaResultado = Enumerable.Empty<Cita>();
            }
        }
        public IEnumerable<Cita> getCitaPorId(int idCita)
        {
            IEnumerable<Cita> getCitaResultado = getCitas().Where(c => c.citaID == idCita);
            return getCitaResultado;
        }
    }
}
            