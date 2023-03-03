using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDemo
{
    public class Department //this will be like our model for the table in the database we want to query.
                            //Example in the departments table we have 2 columns, department ID and name,
                            //which can be seen as properties inside of our class
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }
    }
}
