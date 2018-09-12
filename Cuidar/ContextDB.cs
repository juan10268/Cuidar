using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cuidar.Base_Datos
{
    public class ContextDB
    {
        public SqlConnection DbConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["CuidarConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            return sqlConnection;
        }
    }
}