using EmployeesSalary.Domains;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Serlizer
{
    public interface ISerlizer
    {
        public List<EmployessModel> Deserlize(string json);

        public string Serlize(List<EmployessModel> employees);

        public string Serlize(DataTable employees);
    }
}
