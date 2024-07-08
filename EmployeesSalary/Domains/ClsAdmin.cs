using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Domains
{
    internal class ClsAdmin : IEmployeeJob
    {
        public decimal CalculateSalary(EmployessModel empployee)
        {
            var salary = empployee.FinalSalary = empployee.BasicSalary - (empployee.DaysLate * 1.5m) - (empployee.DaysAbsence * 2) - empployee.TotalPenalitirs;
            return (decimal)salary;
        }
    }
}
