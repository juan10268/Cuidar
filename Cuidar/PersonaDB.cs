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

        public IEnumerable<Persona> getPersonasid(int id)
        {
            Persona persona = new Persona();
            List<Persona> listaPersonas = new List<Persona>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetIdentificacion", con);
                cmd.Parameters.AddWithValue("@per_id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                //

                
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {

                    persona.personaID = Convert.ToInt16(rdr["per_id"]);
                    persona.personaNombre = rdr["per_nombre"].ToString();
                    persona.personaApellido1 = rdr["per_apellido1"].ToString();
                    persona.personaApellido2 = rdr["per_apellido2"].ToString();
                    persona.personaFechaNacimiento = rdr["per_nacimiento"].ToString();
                    persona.personaDireccion = rdr["per_direccion"].ToString();
                    persona.personaTelefono = rdr["per_telefono"].ToString();
                    persona.personaEstadoCivil = Convert.ToInt16(rdr["stv_id"]);
                    persona.personaGenero = Convert.ToInt16(rdr["genero_id"]);
                    persona.personaEscolaridad = Convert.ToInt16(rdr["escolaridad_nivel"]);
                    persona.personaTipoDocumento = Convert.ToInt16(rdr["tipodoc_id"]);
                    persona.personaDepartamento = Convert.ToInt16(rdr["departamento_id"]);
                    persona.personaCiudad = Convert.ToInt16(rdr["ciudad_id"]);
                    }


                listaPersonas.Add(persona);
                con.Close();
            }
            return listaPersonas;
            
        }

        public IEnumerable<Persona> getPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetAllPersonas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Persona persona = new Persona
                    {
                        personaID = Convert.ToInt16(rdr["per_id"]),
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
                        personaDepartamento=Convert.ToInt16(rdr["departamento_id"]),
                       personaCiudad = Convert.ToInt16(rdr["ciudad_id"])
                    };
                    listaPersonas.Add(persona);
                }
                con.Close();
            }
            return listaPersonas;
        }
    }
}