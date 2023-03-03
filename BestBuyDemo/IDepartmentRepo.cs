using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDemo
{
    public interface IDepartmentRepo //adding a new item for the interface
    {
        public IEnumerable<Department> GetAllDepartments();//ienumerable is  an interface that iterates over collections .
                                                           //if department has an error make sure it's public. Making a method to get all departments
    }
}
