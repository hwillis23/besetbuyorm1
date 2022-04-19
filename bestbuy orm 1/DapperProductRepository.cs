using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace bestbuy_orm_1
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;           //field
        public DapperProductRepository(IDbConnection connection)            // constructor
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");    //type exactly what you would type in sequel in the ()
        }
        public void CreateProduct(string name, double price, int categoryID)  //create product method
        {
            _connection.Execute("INSERT INTO products (Name,Price,CategoryID) VALUES (@Name,@Price,@CategoryID);",   //@name is parameterization
                                 new { Name = name, Price = price, CategoryID = categoryID }); 
        }

        public void UpdateProduct(int productID, double updatedPrice)  //update product method
        {
            _connection.Execute("UPDATE products SET updatedPrice = @updatedPrice WHERE ProductID = @ProductID;",
                new { updatedPrice = updatedPrice, ProductID = productID });
        }
        public void DeleteProduct(int productID )
        {
            _connection.Execute("DELETE FROM Products WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM Sales WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM Reviews WHERE ProductID = @productID;",
                new { productID = productID });
            Console.WriteLine("Product information is deleted.");
        }
        public IEnumerable<Product>GetProducts()
            {
            return _connection.Query<Product>("SELECT * FROM products;");
        
            }
        public Product ShowUpdatedProduct(int productID, double updatedPrice)
        {
            return _connection.QuerySingle<Product>("UPDATE products SET Price = @updatedPrice WHERE ProductID = @productID;",
                new { productID = productID, updatedPrice = updatedPrice });

            Console.WriteLine("Product Updated");
        }

        public Product ShowUpdatedProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
