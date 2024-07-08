using EmployeesSalary.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeesSalary.Dl
{
    public class JsonFileDl : IReadEmployees
    {
        public string ReadEmployees(out string message)
        {
            // open json file
            var file = File.ReadAllText("Employees.json");

            // validations
            if (!File.Exists("Employees.json"))
            {
                message = "file not exist";
                return "";
            }
            if (string.IsNullOrEmpty(file))
            {
                message = "file is empyu";
                return "";
            }
            message = "";
            return file;
        }
    }
}
