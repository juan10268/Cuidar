using Cuidar.Models;
using System;
using System.Collections.Generic;
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
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }           
        }
    }
}