using BestBuyDemo;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

#region department
//instantiang the department repo class

var departmentrepo = new DapperDepartmentRepo(conn); //passing in our conn object. We used the parameterized constructor b/c we need to pass in an instance of the connection.
                                                     //We need the connection to query the database

departmentrepo.InsertDepartment("Miahs new deparment"); //this will then get inserted inside the database using that same cobject call the get all departments method which will return us all departments and we should see that new department at the bottom 

var departments = departmentrepo.GetAllDepartments(); //this is a collection of departments

foreach(var department in departments)
{
    Console.WriteLine(department.DepartmentID); //will output that departments ID
    //if fails to load make sure they have their connection string in the appsettings file 
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();

}

#endregion


#region get products





var productRepo = new DapperProductRepo(conn); //instantiating  passing in the connection ,
                                               //it will take that connection obhect and then pass
                                               //it along inside ofthe IDbConnection in dapperproductrepo,
                                               //which will then use this to query the database
var productUpdated = productRepo.GetProduct(555);

productRepo.UpdateProduct(productUpdated);


var product = productRepo.GetAllProducts(); // you get back a collection of products from this method.
                                            // So you'll need to store that data in a variable and then you'll go ahead and loop through each product

foreach(var products in product)
{
    Console.WriteLine(products.ProductID);
    Console.WriteLine(products.Name);
    Console.WriteLine(products.Price);
    Console.WriteLine(products.CategoryID);
    Console.WriteLine(products.OnSale);
    Console.WriteLine(products.StockLevel);

    Console.WriteLine();
    Console.WriteLine();

}

#endregion

