using EmployeesSalary.Domains;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Serlizer
{
    public class JsonSerlizer : ISerlizer
    {
        public List<EmployessModel> Deserlize(string json) {
            List<EmployessModel> lstEmployees = JsonConvert.DeserializeObject<List<EmployessModel>>(json);
            return lstEmployees;
        }

        public string Serlize(List<EmployessModel> employees)
        {
            string file = JsonConvert.SerializeObject(employees);
            return file;
        }

        public string Serlize(DataTable employees)
        {
            string file = JsonConvert.SerializeObject(employees);
            return file;
        }
    }
}
