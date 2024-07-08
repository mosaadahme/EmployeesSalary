using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Domains
{
    public interface IEmployeeJob
    {
        public decimal CalculateSalary(EmployessModel empployee);
    }
}
