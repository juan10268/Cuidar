using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Cuidar.Base_Datos
{
    public class TipoDocumentoDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Documento> getDocumentos()
        {
            List<Documento> listaDocumentos = new List<Documento>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetAllDocumentos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Documento documento = new Documento();
                    documento.documentoTipoId = Convert.ToInt16(rdr["tipodoc_id"]);
                    documento.documentoTipoNombre = rdr["tipodoc_nombre"].ToString();
                    listaDocumentos.Add(documento);
                }
                con.Close();
            }
            return listaDocumentos;
        }
    }
}

   