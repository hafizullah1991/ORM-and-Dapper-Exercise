using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Permissions;

namespace   ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var instance = new DapperDepartmentRepository(conn);
            var departments = instance.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
                Console.WriteLine(department.DepartmentID);
            }


            var productRepository = new DapperProductRepository(conn);
           

            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
            }


        }
    }
}
