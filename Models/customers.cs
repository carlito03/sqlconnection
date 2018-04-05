
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationDay3.Models
{
    public class customers
    {
        public string Customerid;
        public string CustomerEmail; 

        public SqlDataReader showCustomers()
        {

            string sql = @"select * from customers";
            SqlDataReader dr = DBUtil.GetDataReader(sql);
            return dr;  

        }

        public SqlDataReader showOrders(int id)
        {

            string sql = @"select * FROM Orders WHERE CustomerID=" + id.ToString();
            SqlDataReader dr = DBUtil.GetDataReader(sql);
            return dr;

        }

    }
}