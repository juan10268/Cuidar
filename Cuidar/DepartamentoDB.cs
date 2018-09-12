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
        public IEnumerable<Departamento> getDepartamentos()
        {
            List<Departamento> listaDepartamento = new List<Departamento>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetDepartamento", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Departamento departamento = new Departamento();
                    departamento.departamentoId = Convert.ToInt16(rdr["departamento_id"]);
                    departamento.departamentoNombre = rdr["departamento_nombre"].ToString();
                    listaDepartamento.Add(departamento);
                }
                con.Close();
            }
            return listaDepartamento;
        }
    }
}
    