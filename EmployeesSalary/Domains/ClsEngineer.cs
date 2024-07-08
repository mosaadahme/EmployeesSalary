using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Domains
{
    public class ClsEngineer : IEmployeeJob
    {
        public decimal CalculateSalary(EmployessModel empployee)
        {
            var salary = empployee.BasicSalary - empployee.DaysAbsence - empployee.TotalPenalitirs + empployee.Bouns;
            return (decimal)salary;
        }
    }
}
