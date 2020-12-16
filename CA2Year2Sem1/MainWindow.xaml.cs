using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CA2Year2Sem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush greyedOut = new SolidColorBrush(Color.FromRgb(0xa5, 0xa5, 0xa5));

        List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            FullTimeEmployee fullTime1 = new FullTimeEmployee("John", "Doe", 100);
            FullTimeEmployee fullTime2 = new FullTimeEmployee("Jill", "Doe", 200);

            employees.Add(fullTime1);
            employees.Add(fullTime2);

            PartTimeEmployee partTime1 = new PartTimeEmployee("Jane", "Smith", 10, 20);
            PartTimeEmployee partTime2 = new PartTimeEmployee("John", "Smith", 30, 40);

            employees.Add(partTime1);
            employees.Add(partTime2);

            lstbxEmployees.ItemsSource = employees;
        }

        private void rdobtnFullTime_Checked(object sender, RoutedEventArgs e)
        {
            //Allows the user to enter the data specific to full time employees
            tblkSalary.Foreground = Brushes.Black;
            tbxSalary.Background = Brushes.White;
            tbxSalary.IsEnabled = true;
            tbxSalary.Cursor = Cursors.IBeam;

            //Prevents the user from entering data that dosn't apply to a full time employee
            tblkHourlyRate.Foreground = greyedOut;
            tbxHourlyRate.Background = greyedOut;
            tbxHourlyRate.IsEnabled = false;
            tbxHourlyRate.Cursor = Cursors.Arrow;
            tblkHoursWorked.Foreground = greyedOut;
            tbxHoursWorked.Background = greyedOut;
            tbxHoursWorked.IsEnabled = false;
            tbxHoursWorked.Cursor = Cursors.Arrow;
        }

        private void rdobtnPartTime_Checked(object sender, RoutedEventArgs e)
        {
            //Allows the user to enter the data specific to part time employees
            tblkHourlyRate.Foreground = Brushes.Black;
            tbxHourlyRate.Background = Brushes.White;
            tbxHourlyRate.IsEnabled = true;
            tbxHourlyRate.Cursor = Cursors.IBeam;
            tblkHoursWorked.Foreground = Brushes.Black;
            tbxHoursWorked.Background = Brushes.White;
            tbxHoursWorked.IsEnabled = true;
            tbxHoursWorked.Cursor = Cursors.IBeam;

            //Prevents the user from entering data that dosn't apply to a part time employee
            tblkSalary.Foreground = greyedOut;
            tbxSalary.Background = greyedOut;
            tbxSalary.IsEnabled = false;
            tbxSalary.Cursor = Cursors.Arrow;
        }

       
        private void chbxFullTime_Click(object sender, RoutedEventArgs e)
        {
            List<FullTimeEmployee> fullTimes = new List<FullTimeEmployee>();
            List<PartTimeEmployee> partTimes = new List<PartTimeEmployee>();

            if (chbxFullTime.IsChecked == true && chbxPartTime.IsChecked == false)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    switch (employees[i] is FullTimeEmployee)
                    {
                        case true:
                            fullTimes.Add((FullTimeEmployee)employees[i]);
                            break;
                    }
                }

                lstbxEmployees.ItemsSource = null;
                lstbxEmployees.ItemsSource = fullTimes;
            }
            else if (chbxPartTime.IsChecked == true && chbxFullTime.IsChecked == false)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    switch (employees[i] is PartTimeEmployee)
                    {
                        case true:
                            partTimes.Add((PartTimeEmployee)employees[i]);
                            break;
                    }
                }

                lstbxEmployees.ItemsSource = null;
                lstbxEmployees.ItemsSource = partTimes;
            }
            else
            {
                lstbxEmployees.ItemsSource = null;
                lstbxEmployees.ItemsSource = employees;
            }
        }

        private void lstbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = lstbxEmployees.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                if (selectedEmployee is FullTimeEmployee)
                {
                    FullTimeEmployee fullTime = (FullTimeEmployee)selectedEmployee;

                    tbxFirstName.Text = fullTime.FirstName;
                    tbxSurname.Text = fullTime.Surname;
                    tbxSalary.Text = fullTime.Salary.ToString();
                    tblkMonthlyPay.Text = fullTime.CalculateMonthlyPay().ToString();
                    rdobtnFullTime.IsChecked = true;
                    rdobtnPartTime.IsChecked = false;

                    tbxHourlyRate.Text = "";
                    tbxHoursWorked.Text = "";
                }

                else
                {
                    PartTimeEmployee partTime = (PartTimeEmployee)selectedEmployee;

                    tbxFirstName.Text = partTime.FirstName;
                    tbxSurname.Text = partTime.Surname;
                    tbxHourlyRate.Text = partTime.HourlyRate.ToString();
                    tbxHoursWorked.Text = partTime.HoursWorked.ToString();
                    tblkMonthlyPay.Text = partTime.CalculateMonthlyPay().ToString();
                    rdobtnFullTime.IsChecked = false;
                    rdobtnPartTime.IsChecked = true;

                    tbxSalary.Text = "";
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (rdobtnFullTime.IsChecked == true)
            {
                FullTimeEmployee fullTime = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxSalary.Text));
                employees.Add(fullTime);
            }
            else
            {
                PartTimeEmployee partTime = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxHourlyRate.Text), double.Parse(tbxHoursWorked.Text));
                employees.Add(partTime);
            }

            employees.Sort();

            lstbxEmployees.ItemsSource = null;
            lstbxEmployees.ItemsSource = employees;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSalary.Text == "" || tbxHourlyRate.Text == "" || tbxHoursWorked.Text == "")
            {
                MessageBox.Show("INVALID INPUT, VALUES MUST BE ENTERED");
            }
            else
            {
                employees.Remove((Employee)lstbxEmployees.SelectedItem);

                if (rdobtnFullTime.IsChecked == true)
                {
                    FullTimeEmployee fullTime = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxSalary.Text));
                    employees.Add(fullTime);
                }
                else
                {
                    PartTimeEmployee partTime = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxHourlyRate.Text), double.Parse(tbxHoursWorked.Text));
                    employees.Add(partTime);
                }
            }

            lstbxEmployees.ItemsSource = null;
            lstbxEmployees.ItemsSource = employees;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
            tbxSurname.Clear();
            tbxSalary.Clear();
            tbxHoursWorked.Clear();
            tbxHourlyRate.Clear();
            tblkMonthlyPay.Text = null;
            rdobtnFullTime.IsChecked = false;
            rdobtnPartTime.IsChecked = false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            employees.Remove((Employee)lstbxEmployees.SelectedItem);

            btnClear_Click(null, null);

            lstbxEmployees.ItemsSource = null;
            lstbxEmployees.ItemsSource = employees;
        }
    }
}