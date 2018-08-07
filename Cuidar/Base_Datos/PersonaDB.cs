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
                cmd.CommandType = CommandType.StoredProcedure;
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
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<Persona> GetIdentificacionPersona()
        {
            List<Persona> listaPersonaporId = new List<Persona>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetIdentificacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   Persona personaDB = new Persona();
                   personaDB.personaID = Convert.ToInt16(rdr["per_id"]);
                   personaDB.personaNombre = rdr["per_nom"].ToString();
                   personaDB.personaApellido1 = rdr["per_ape1"].ToString();
                   personaDB.personaApellido2 = rdr["per_ape2"].ToString();
                   listaPersonaporId.Add(personaDB);
                   }
                }
            return listaPersonaporId;
        }
    }
}
                    
               
           