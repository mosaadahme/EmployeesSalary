using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Dl
{
    public interface IReadEmployees
    {
        public string ReadEmployees(out string message);
    }
}
