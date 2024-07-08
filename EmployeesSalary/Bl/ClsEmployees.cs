using EmployeesSalary.Domains;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeesSalary.Dl;
using EmployeesSalary.Serlizer;

namespace EmployeesSalary.Bl
{
    public class ClsEmployees
    {
        IReadEmployees _dataAccess;
        ISerlizer _serlizer;
        public ClsEmployees(IReadEmployees dataAccess,
            ISerlizer serlizer)
        {
            _dataAccess = dataAccess;
            _serlizer= serlizer;
        }
        void x()
        {
            // open json file
            var file = File.ReadAllText("Employees.json");

            // validations
            if (!File.Exists("Employees.json"))
            {
                MessageBox.Show("file not exist");
                return;
            }
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("file is empty");
                return;
            }
            // deserilize json to objects
            List<EmployessModel> lstEmployees = JsonConvert.DeserializeObject<List<EmployessModel>>(file);
            if (lstEmployees == null)
            {
                MessageBox.Show("list is empty");
                return;
            }
            // loop employees
            foreach (var empployee in lstEmployees)
            {
                // calculate salary according to jon
                //swich case over job
                //calculate salary
                switch (empployee.Job)
                {
                    case "Engineer":
                        empployee.FinalSalary = empployee.BasicSalary - empployee.DaysAbsence - empployee.TotalPenalitirs + empployee.Bouns;
                        break;
                    case "Sales":
                        empployee.FinalSalary = empployee.BasicSalary - empployee.DaysLate - empployee.DaysAbsence - empployee.TotalPenalitirs + (empployee.CommstionPercent * empployee.TotalSales);
                        break;
                    case "Admin":
                        empployee.FinalSalary = empployee.BasicSalary - (empployee.DaysLate * 1.5m) - (empployee.DaysAbsence * 2) - empployee.TotalPenalitirs;
                        break;
                }
            }
        }

        string ValidateList(List<EmployessModel> lstEmployees)
        {
            if (lstEmployees == null)
            {
                return "list is empty";
            }
            return "";
        }

        List<EmployessModel> CalculateSalary(List<EmployessModel> lstEmployees)
        {
            // loop employees
            IEmployeeJob job;
            foreach (var empployee in lstEmployees)
            {
                // calculate salary according to jon
                //swich case over job
                //calculate salary
                switch (empployee.Job)
                {
                    case "Engineer":
                        job = new ClsEngineer();
                        empployee.FinalSalary = job.CalculateSalary(empployee);
                        break;
                    case "Sales":
                        job = new ClsSales();
                        empployee.FinalSalary = job.CalculateSalary(empployee);
                        break;
                    case "Admin":
                        job = new ClsAdmin();
                        empployee.FinalSalary = job.CalculateSalary(empployee);
                        break;
                }
            }
            return lstEmployees;
        }

        List<EmployessModel> GetEmployees(out string message)
        {
            string sMessage = "";
            var file = _dataAccess.ReadEmployees(out sMessage);
            if (!string.IsNullOrEmpty(sMessage))
            {
                message = sMessage;
                return new List<EmployessModel>();
            }

            // deserilize json to objects
            List<EmployessModel> lstEmployees = _serlizer.Deserlize(file);
            sMessage = ValidateList(lstEmployees);
            if (!string.IsNullOrEmpty(sMessage))
            {
                message = sMessage;
                return new List<EmployessModel>();
            }
            message = "";
            return lstEmployees;
        }
        public List<EmployessModel> ShowEmployees(out string message)
        {
            message = "";
            var lstEmployees = GetEmployees(out message);
            return CalculateSalary(lstEmployees);
        }
    }
}
