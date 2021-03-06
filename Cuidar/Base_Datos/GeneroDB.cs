﻿using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class GeneroDB
    {
        ContextDB contextDB = new ContextDB();

        public ICollection<Genero> getGenero()
        {
            List<Genero> listaGeneros = new List<Genero>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetGenero", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Genero genero = new Genero();
                    genero.generoId = Convert.ToInt16(rdr["estadocita_id"]);
                    genero.generoNombre = rdr["estadocita_nombre"].ToString();
                    listaGeneros.Add(genero);
                }
                con.Close();
            }
            return listaGeneros;
        }
    }
}