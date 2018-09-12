using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class EspecialistaDB
    {
        ContextDB contextDB = new ContextDB();

        public void AgregarEspecialista(Especialista especialista)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spAgregarEspecialista", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@especialidad_id", especialista.especialidadId);
                cmd.Parameters.AddWithValue("@especialista_id", especialista.especialistaId);
                cmd.Parameters.AddWithValue("@especialistaFechaIngreso", especialista.especialistaFechaIngreso);
                if(especialista.especialistaFechaRetiro !=null){
                cmd.Parameters.AddWithValue("@especialistaFechaRetiro", especialista.especialistaFechaRetiro);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@especialistaFechaRetiro", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@vinculacion_tipo", especialista.tipo_vinculacion);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<Especialista> getEspecialista()

        {
            List<Especialista> listaEspecialista = new List<Especialista>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetAllEspecialista", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Especialista especialista = new Especialista
                    {
                        especialistaId= Convert.ToInt16(rdr["especialista_id"]),
                        especialidadId=Convert.ToInt16(rdr["especialidad_id"]),
                        especialistaFechaIngreso = rdr["especialista_ingreso"].ToString(),
                        especialistaFechaRetiro = rdr["especialista_retiro"].ToString(),
                       tipo_vinculacion = Convert.ToInt16(rdr["tipo_vinculacion_id"])
                    };
                    listaEspecialista.Add(especialista);
                }
                con.Close();
            }
            return listaEspecialista;
        }
    }
}