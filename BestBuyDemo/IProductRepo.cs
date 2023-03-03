using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDemo
{
    public interface IProductRepo
    {

        public IEnumerable<Product> GetAllProducts();

        //void CreateProduct(string name, double price, int categoryID);

        public Product GetProduct(int id); //you'll use the getproduct method to get you a product from the database and
                                           //then you'll pass that into the update product method and update that individual
                                           //product and everything will be inside of the updateproduct method , that way you don't have to type everything back out 
        public void UpdateProduct(Product product); //can also do int id, string newProduct, double newPrice
    }
}
