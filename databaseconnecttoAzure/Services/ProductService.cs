using databaseconnecttoAzure.Models;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;

namespace databaseconnecttoAzure.Services
{
    public class ProductService
    {
        private static string db_source = "sampledatabaseserver1.database.windows.net";
        private static string db_user = "databaselogin";
        private static string db_password = "databasePassword@123";
        private static string db_name = "sampledatabase";

        private SqlConnection GetConnection() 
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_name;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection sqlConn = GetConnection();
            List<Product> productList = new List<Product>();
            string statement = "select  productID, productName, Quantity from products";
            sqlConn.Open();

            SqlCommand cmd = new SqlCommand(statement, sqlConn);
            using( SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Product product = new Product()
                    {
                        productID = reader.GetInt32(0),
                        productName = reader.GetString(1),
                        productCount = reader.GetInt32(2)

                    };

                    productList.Add(product);
                }
            }
            sqlConn.Close();
            return productList;

        }
    }
}
