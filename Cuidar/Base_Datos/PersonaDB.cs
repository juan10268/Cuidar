using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class PersonaDB
    {
        ContextDB contextDB = new ContextDB();
        PacienteDB pacienteDB = new PacienteDB();

        public void AgregarPersona(Persona persona)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spAgregarPersona", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@per_id", persona.personaID);
                cmd.Parameters.AddWithValue("@per_nom", persona.personaNombre);
                cmd.Parameters.AddWithValue("@per_ape1", persona.personaApellido1);
                cmd.Parameters.AddWithValue("@per_ape2", persona.personaApellido2);
                cmd.Parameters.AddWithValue("@per_fec_nac", persona.personaFechaNacimiento);
                cmd.Parameters.AddWithValue("@per_dire", persona.personaDireccion);
                cmd.Parameters.AddWithValue("@per_tel", persona.personaTelefono);
                cmd.Parameters.AddWithValue("@estado_civil", persona.personaEstadoCivil);
                cmd.Parameters.AddWithValue("@genero", persona.personaGenero);
                cmd.Parameters.AddWithValue("@doc_tip_id", persona.personaTipoDocumento);
                cmd.Parameters.AddWithValue("@ciudad_id", persona.personaCiudad);
                cmd.Parameters.AddWithValue("@escolaridad", persona.personaEscolaridad);
                cmd.Parameters.AddWithValue("@departamento", persona.personaDepartamento);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void EditarPersona(Persona persona)
        {
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spEditarPersona", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@per_id", persona.personaID);
                cmd.Parameters.AddWithValue("@per_nom", persona.personaNombre);
                cmd.Parameters.AddWithValue("@per_ape1", persona.personaApellido1);
                cmd.Parameters.AddWithValue("@per_ape2", persona.personaApellido2);
                cmd.Parameters.AddWithValue("@per_fec_nac", persona.personaFechaNacimiento);
                cmd.Parameters.AddWithValue("@per_dire", persona.personaDireccion);
                cmd.Parameters.AddWithValue("@per_tel", persona.personaTelefono);
                cmd.Parameters.AddWithValue("@estado_civil", persona.personaEstadoCivil);
                cmd.Parameters.AddWithValue("@genero", persona.personaGenero);
                cmd.Parameters.AddWithValue("@doc_tip_id", persona.personaTipoDocumento);
                cmd.Parameters.AddWithValue("@ciudad_id", persona.personaCiudad);
                cmd.Parameters.AddWithValue("@escolaridad", persona.personaEscolaridad);
                cmd.Parameters.AddWithValue("@departamento", persona.personaDepartamento);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<Persona> getPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("getPersonas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Persona persona = new Persona
                    {
                        personaID = Convert.ToInt32(rdr["per_id"]),
                        personaNombre = rdr["per_nombre"].ToString(),
                        personaApellido1 = rdr["per_apellido1"].ToString(),
                        personaApellido2 = rdr["per_apellido2"].ToString(),
                        personaFechaNacimiento = rdr["per_nacimiento"].ToString(),
                        personaDireccion = rdr["per_direccion"].ToString(),
                        personaTelefono = rdr["per_telefono"].ToString(),
                        personaEstadoCivil = Convert.ToInt16(rdr["stv_id"]),
                        personaGenero = Convert.ToInt16(rdr["genero_id"]),
                        personaEscolaridad = Convert.ToInt16(rdr["escolaridad_nivel"]),
                        personaTipoDocumento = Convert.ToInt16(rdr["tipodoc_id"]),
                        personaDepartamento = Convert.ToInt16(rdr["departamento_id"]),
                        personaCiudad = Convert.ToInt16(rdr["ciudad_id"])
                    };
                    listaPersonas.Add(persona);
                }
                con.Close();
            }
            return listaPersonas;
        }
        public IEnumerable<Persona> GetPersonaPorID(int id)
        {
            IEnumerable<Persona> getResultadoPersona = getPersonas().Where(c => c.personaID == id);
            if (getResultadoPersona.Any())
            {
                return getResultadoPersona;
            }
            else
            {
                getResultadoPersona = Enumerable.Empty<Persona>();
            }
            return getResultadoPersona;
        }
        public IEnumerable<Persona> getPersonasPaciente(int ID)
        {
            IEnumerable<Paciente> getResultadoPaciente = pacienteDB.getInfoPaciente(ID);
            IEnumerable<Persona> getResultadoPersona = getPersonas().Where(c => c.personaID == ID);
            if ((getResultadoPaciente.Any()) && getResultadoPersona.Any())
            {
                return getResultadoPersona;
            }
            else
            {
                return getResultadoPersona = Enumerable.Empty<Persona>();
            }
        }        
    } 
}
                    
               
           