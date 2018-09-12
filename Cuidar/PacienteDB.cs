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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rangosalario", paciente.rangosalario);
                cmd.Parameters.AddWithValue("@vincu_tip_id", paciente.vinculacionTipoId);
                cmd.Parameters.AddWithValue("@per_id", paciente.personasId);
                cmd.Parameters.AddWithValue("@activacion", paciente.activacionId);
                cmd.Parameters.AddWithValue("@fechaingreso", paciente.fechaingreso);
                if (paciente.fecharetiro != null)
                {
                    cmd.Parameters.AddWithValue("@fecharetiro", paciente.fecharetiro);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fecharetiro", DBNull.Value);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void EditarPaciente(Paciente paciente)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spEditarPaciente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rangosalario", paciente.rangosalario);
                cmd.Parameters.AddWithValue("@vincu_tip_id", paciente.vinculacionTipoId);
                cmd.Parameters.AddWithValue("@per_id", paciente.personasId);
                cmd.Parameters.AddWithValue("@activacion", paciente.activacionId);
                cmd.Parameters.AddWithValue("@fechaingreso", paciente.fechaingreso);
                if (paciente.fecharetiro != null)
                {
                    cmd.Parameters.AddWithValue("@fecharetiro", paciente.fecharetiro);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fecharetiro", DBNull.Value);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<Paciente> getPacientes()
        {
            List<Paciente> listaPaciente = new List<Paciente>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetAllPacientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Paciente paciente = new Paciente
                    {
                        personasId = Convert.ToInt16(rdr["paciente_id"]),
                        fechaingreso = rdr["paciente_ingreso"].ToString(),
                        fecharetiro = rdr["paciente_retiro"].ToString(),
                        activacionId = Convert.ToInt16(rdr["activacion_id"]),
                        rangosalario = Convert.ToInt16(rdr["ransalarial_id"]),
                        vinculacionTipoId = Convert.ToInt16(rdr["tipo_vinculacion_id"])
                    };
                    listaPaciente.Add(paciente);
                }
                con.Close();
            }
            return listaPaciente;
        }
        public IEnumerable<Paciente> getPacientesid(int id)
        {
            Paciente paciente = new Paciente();
            List<Paciente> listaPacientes = new List<Paciente>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetIdentifipaciente", con);
                cmd.Parameters.AddWithValue("@paciente_id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                //


                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    paciente.personasId = Convert.ToInt16(rdr["paciente_id"]);
                    paciente.fechaingreso = rdr["paciente_ingreso"].ToString();
                    paciente.fecharetiro = rdr["paciente_retiro"].ToString();
                    paciente.activacionId = Convert.ToInt16(rdr["activacion_id"]);
                    paciente.rangosalario = Convert.ToInt16(rdr["ransalarial_id"]);
                    paciente.vinculacionTipoId = Convert.ToInt16(rdr["tipo_vinculacion_id"]); 
                }

                listaPacientes.Add(paciente);
                con.Close();
            }
            return listaPacientes;
        }
        }
}

