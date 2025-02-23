using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using System.Data;
using webApiProduct.Model;

namespace webApiProduct.DataAccess
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async  Task<IEnumerable<Product>> GetProductsList()
        {
            List<Product> products = new List<Product>();

            using( var connection = new SqlConnection(_connectionString))
            {

                await connection.OpenAsync();
                using (var command = new SqlCommand("dbo.sp_products", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.CategoryName= reader["Name"].ToString();
                        product.Price = Convert.ToInt32(reader["Price"]);
                        products.Add(product);
                    }

                    return products;

                }

            }

        }
    }
}
