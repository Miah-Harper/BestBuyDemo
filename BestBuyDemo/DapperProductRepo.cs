using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDemo
{
    public class DapperProductRepo : IProductRepo // creating the actual repository class that implements the interface
    {
        //we are going to need some implementation in order to call the database we're going to need a connection

        private readonly IDbConnection _conn; // will need to generate a constructor 

        public DapperProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        //public void CreateProduct(string name, double price, int categoryID)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Product> GetAllProducts() //with this object we'll go ahead and return all of the 
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id) //we will be going to query the database with our object, this time it'll be with a single product
        { 
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;", new { id = id }); //from this parameter we will get the ID.
                                                                                                            //this will get us back a product.
                                                                                                            //So in order to then update that product
                                                                                                            //we will then take the connection object
                                                                                                            //and then we will go ahead and execute
                                                                                                            //something against the database
        }

        //public void UpdateProduct(int productID, string name) //we won't be reading anything back, just executing this which is why the method is void 
        //{

        //    _conn.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
        //        new { name = name, productID = productID });



        //    //_conn.Execute("UPDATE products" +
        //    //    " SET  Name = @name, " +
        //    //    " Price = @price, " +
        //    //    " CategoryId = @catID, " +
        //    //    " OnSale = @sale," +
        //    //    " Stocklevel = @stock",
        //    //    " WHERE ProductID = @id;",
        //    //    new { name = name, price = price, catID = catID, sale = sale, stock = stock, id = productID  });
        //}

        public void UpdateProduct(Product product)
        {

            _conn.Execute("UPDATE products" +
                    " SET Name = @name," +
                    " Price = @price," +
                    " CategoryID = @catID," +
                    " OnSale = @onSale," +
                    " StockLevel = @stock" +
                    " WHERE ProductID = @id;",
                    new
                    {
                        id = product.ProductID,
                        name = product.Name,
                        price = product.Price,
                        catID = product.CategoryID,
                        onSale = product.OnSale,
                        stock = product.StockLevel
                    });
        }
    }
}
