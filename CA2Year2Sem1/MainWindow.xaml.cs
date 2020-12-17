
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
        //Creates a grey colour
        SolidColorBrush greyedOut = new SolidColorBrush(Color.FromRgb(0xa5, 0xa5, 0xa5));

        List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            //BruceBat WayneCave is a multi-millionare and makes da moola
            FullTimeEmployee fullTime1 = new FullTimeEmployee("BruceBat", "WayneCave", 10000000);
            //ClarkSuper ManKent is a journelist so dosen't make much money
            FullTimeEmployee fullTime2 = new FullTimeEmployee("ClarkSuper", "ManKent", 500);

            employees.Add(fullTime1);
            employees.Add(fullTime2);

            //WadeDead WillsonPool is a merc so makes a lot of money for a small amount of time
            PartTimeEmployee partTime1 = new PartTimeEmployee("WadeDead", "WillsonPool", 20000, 5);
            //GhostJohnny BlazeRider is an accountent so makes a small amount of money for a long amount of time
            PartTimeEmployee partTime2 = new PartTimeEmployee("GhostJohnny", "BlazeRider", 10, 50);

            employees.Add(partTime1);
            employees.Add(partTime2);

            lstbxEmployees.ItemsSource = employees;
        }

        private void rdobtnFullTime_Checked(object sender, RoutedEventArgs e)
        {
            //Allows the user to enter the data specific to full time employees
            //Changes font colour to black
            tblkSalary.Foreground = Brushes.Black;
            //Changes the background to white
            tbxSalary.Background = Brushes.White;
            //Prevent the user from entering in any data
            tbxSalary.IsEnabled = true;
            //Changes the cursor to an IBeam
            tbxSalary.Cursor = Cursors.IBeam;


            //Prevents the user from entering data that dosn't apply to a full time employee
            //Changes the font colour to grey
            tblkHourlyRate.Foreground = greyedOut;
            //Changes the background colour to grey
            tbxHourlyRate.Background = greyedOut;
            //Prevents the user from entering in any data
            tbxHourlyRate.IsEnabled = false;
            //Changes the cursor to an arrow
            tbxHourlyRate.Cursor = Cursors.Arrow;
            //Changes the font colour to grey
            tblkHoursWorked.Foreground = greyedOut;
            //Changes the background to grey
            tbxHoursWorked.Background = greyedOut;
            //Prevents the user from entering in any data
            tbxHoursWorked.IsEnabled = false;
            //Changes the cursor to an arrow
            tbxHoursWorked.Cursor = Cursors.Arrow;
        }

        private void rdobtnPartTime_Checked(object sender, RoutedEventArgs e)
        {
            //Allows the user to enter the data specific to part time employees
            //Changes font colour to black
            tblkHourlyRate.Foreground = Brushes.Black;
            //Changes background colour to white
            tbxHourlyRate.Background = Brushes.White;
            //Allows the user to enter in data
            tbxHourlyRate.IsEnabled = true;
            //Changes the cursor to an IBeam
            tbxHourlyRate.Cursor = Cursors.IBeam;
            //Changes font colour to black
            tblkHoursWorked.Foreground = Brushes.Black;
            //Changes background colour to white
            tbxHoursWorked.Background = Brushes.White;
            //Allows the user to enter in data
            tbxHoursWorked.IsEnabled = true;
            //Changes the cursor to an IBeam
            tbxHoursWorked.Cursor = Cursors.IBeam;


            //Prevents the user from entering data that dosn't apply to a part time employee
            //Changes the font colour to grey
            tblkSalary.Foreground = greyedOut;
            //Changes the backgorund colour to grey
            tbxSalary.Background = greyedOut;
            //Prevents the user from entering in text
            tbxSalary.IsEnabled = false;
            //Changes the cursor to an arrow
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

            employees.Sort();
            btnClear_Click(null, null);

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