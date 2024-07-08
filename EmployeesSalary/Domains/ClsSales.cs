using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Domains
{
    internal class ClsSales : IEmployeeJob
    {
        public decimal CalculateSalary(EmployessModel empployee)
        {
            var salary = empployee.FinalSalary = empployee.BasicSalary - empployee.DaysLate - empployee.DaysAbsence - empployee.TotalPenalitirs + (empployee.CommstionPercent * empployee.TotalSales);
            return (decimal)salary;
        }
    }
}
