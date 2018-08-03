using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class DepartamentoDB
    {
        ContextDB contextDB = new ContextDB();
        public ICollection<Departamento> getDepartamento()
        {
            List<Departamento> listaDepartamentos = new List<Departamento>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetAllDepartamentos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Departamento departamento = new Departamento();
                    departamento.DepartamentoID = Convert.ToInt16("");
                    departamento.DepartamentoNombre = rdr[""].ToString();
                    listaDepartamentos.Add(departamento);
                }
                return listaDepartamentos;
            }
        }
    }
}