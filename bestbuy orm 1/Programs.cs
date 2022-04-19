using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
//^^^^MUST HAVE USING DIRECTIVES^^^^

namespace bestbuy_orm_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            //MySqlConnection Object (we can access this class's members using --> conn)
            IDbConnection conn = new MySqlConnection(connString);

            //DapperDepartmentsRepository Object (we can access this class's members using --> repo)
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a new Department name");

            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);

            //the result from GetAllDepartments() //
            var departments = repo.GetAllDepartments();

            Console.WriteLine(); 

            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);

            }
            //DapperProductRepository Object (now we can access this class's members using --> repoo)//
            var repoo = new DapperProductRepository(conn);    ///// holding location //

            var products = repoo.GetAllProducts(); //products = an IEnumerable<Product> "list"

            Console.WriteLine();

            foreach (var product in products)
            {
                Console.WriteLine($"The product is: {product.Name} {product.Price},{product.CategoryID}");
            }

            var repo2 = new DapperProductRepository(conn);

             repo2.CreateProduct("cassette tape",20.00,7);


            Console.WriteLine("Enter the consoleID of the one you want to delete");  ///delete 

            var prodID = int.Parse(Console.ReadLine());

            repo2.DeleteProduct(prodID);  //For the DeleteProduct() we only need to pass in the products ID as an argument; therefore, we pass in --> productID


          


        }
    }
}

