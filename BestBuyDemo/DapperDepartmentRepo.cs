using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDemo
{
    public class DapperDepartmentRepo : IDepartmentRepo
    {

        //connection needs to be passed into this class

        private readonly IDbConnection _conn; //we now have a place holder for our connection from program

        public DapperDepartmentRepo(IDbConnection conn) //made a parametereized constructor that forces you anytime you create an instance
                                                        //of this class you must pass it in an instance of a connection to a database ex. Idbconnection
        {
            _conn = conn;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments"); //with this connection object _conn we'll use this object to query the database.
                                                                         //select all the columns from the departments table 
        }

       

      public void InsertDepartment(string name ) //since this is void there is not return 
                                                //if we want to insert a method this will automatically insert the ids for us b/c it autoincrements, shown in the departments table on mysql
                                                //, all we need to worry about is the departments name b/c it doesn't auto increment
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", new {Name = name}); //inserting into the departments table and adding it into the name column.
                                                                           //Putting the values of the name parameter into the names column.
                                                                           //It will jsut be a string so we can add in a new annoymous type.
                                                                           //Setting the new{} object to represent the relationship between the parameter and the variable.
                                                                           ////vs also infers the name so you can even just do name {name}
                                                                           // we are assigning the variable name to the value of the parameter. 
        }

        //public void Update()
    }
}
