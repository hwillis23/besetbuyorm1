using System;
using System.Collections.Generic;
using System.Text;

namespace bestbuy_orm_1
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int productID);
        public void CreateProduct(string name, double price, int categoryID);
        public void UpdateProduct(int productID, double updatedPrice); //bonus
        public void DeleteProduct(int productID);   //Bonus 2 
        public Product ShowUpdatedProduct(int productID); //Bonus x 3


    }
}
