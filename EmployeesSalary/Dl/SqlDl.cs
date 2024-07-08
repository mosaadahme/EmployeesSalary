using EmployeesSalary.Domains;
using EmployeesSalary.Serlizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSalary.Dl
{
    public class SqlDl : IReadEmployees
    {
        ISerlizer _serlizer;
        public SqlDl(ISerlizer serlizer) {
            _serlizer=serlizer;
        }
        public string ReadEmployees(out string message)
        {
            string file = "";
            string ConnectionString = "server=DESKTOP-6EN60AV\\SQLEXPRESS;database=HrExample;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                // open the connection  
                conn.Open();

                //Create a SqlDataAdapter object  
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from TbEmployees", conn))
                {
                    // Call DataAdapter's Fill method to fill data from the  
                    // Data Adapter to the DataSet  
                    DataSet ds = new DataSet("Customers");
                    adapter.Fill(ds);
                    file= _serlizer.Serlize(ds.Tables[0]);
                    message = "";
                    return file;
                }
            }

        }
    }
}
