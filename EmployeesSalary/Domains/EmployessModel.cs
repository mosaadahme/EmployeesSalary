using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Domains
{
    public class EmployessModel
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public decimal BasicSalary { get; set; }
        public int DaysLate { get; set; }
        public int DaysAbsence { get; set; }
        public decimal TotalPenalitirs { get; set; }
        public decimal? Bouns { get; set; }
        public decimal? CommstionPercent { get; set; }
        public decimal? TotalSales { get; set; }
        public decimal? FinalSalary { get; set; }
    }
}
