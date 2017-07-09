using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOnline.DAL
{
    class DBHelper
    {

        string DBConnStr = @"Data Source=DESKTOP-B9DAPCK\MYSQLEXPRESS2008;Initial Catalog=CarsOnline;Integrated Security=True";
        SqlConnection conn = null;

        public DBHelper()
        {
            conn = new SqlConnection(DBConnStr);
            conn.Open();
        }

        public int ExecuteQuery(String sqlQuery)
        {
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            int count = comm.ExecuteNonQuery();
            return count;
        }

        public Object SqlScalar(String sqlQuery)
        {
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            return comm.ExecuteScalar();
        }

        public SqlDataReader ExecuteReader(String sqlQuery)
        {
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            return comm.ExecuteReader();
        }

    }
}
