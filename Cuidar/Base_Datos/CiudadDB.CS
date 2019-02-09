using Cuidar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class CiudadDB
    {
        ContextDB contextDB = new ContextDB();
        public IEnumerable<Ciudad> getCiudades()
        {
            List<Ciudad> listaCiudades = new List<Ciudad>();
            using (SqlConnection con = contextDB.DbConnection())
            {
                SqlCommand cmd = new SqlCommand("spGetCiudades", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.ciudadId = Convert.ToInt16(rdr["ciudad_id"]);
                    ciudad.ciudadNombre = rdr["ciudad_nombre"].ToString();
                    ciudad.ciudadDepartamento= Convert.ToInt16(rdr["departamento_id"]);

                    listaCiudades.Add(ciudad);
                }
                con.Close();
            }
            return listaCiudades;
        }
    public IEnumerable<Ciudad> getCiudadesPorDepartamento(int idDepartamento)
        {
            IEnumerable<Ciudad> listaCiudadDepartamento = getCiudades().Where(c => c.ciudadDepartamento == idDepartamento);
            if (listaCiudadDepartamento.Any())
            {
                return listaCiudadDepartamento;
            }
            else
            {
                listaCiudadDepartamento = Enumerable.Empty<Ciudad>();
            }
            return listaCiudadDepartamento;
        }
    }
}