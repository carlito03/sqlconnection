using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace WebApplicationDay3.Helpers
{
    public class DBUtil
    {
        static public SqlDataReader GetDataReader(string sql)
        {
            string connectionstring = Config.ConnectionString;

            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;

            
        }

        static public int Exec(string sql)
        {
            string connectionstring = Config.ConnectionString;

            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            return 0;
        }

        static public int Exec(string sql, SqlParameter[] myparameters)
        {
            string connectionstring = Config.ConnectionString;

            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach(SqlParameter p in myparameters)
            {
                cmd.Parameters.Add(p);
            }

            cmd.ExecuteNonQuery();

            return 0;
        }
    }
}