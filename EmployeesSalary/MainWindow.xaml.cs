using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmployeesSalary.Bl;
using EmployeesSalary.Domains;
using Newtonsoft.Json;
using EmployeesSalary.Dl;
using EmployeesSalary.Serlizer;
namespace EmployeesSalary
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var serlizer = new JsonSerlizer();
            ClsEmployees oClsEmployees = 
                new ClsEmployees(new SqlDl(serlizer), serlizer);
            string sMessage = "";
            var lstEmployees= oClsEmployees.ShowEmployees(out sMessage);
            if(!string.IsNullOrEmpty(sMessage) )
            {
                MessageBox.Show(sMessage);
                return;
            }
            // show empployee data on screen
            grdEmployess.ItemsSource = lstEmployees;
        }
    }
}
