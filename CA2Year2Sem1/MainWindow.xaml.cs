
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

        //Creates a list of type employee
        List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            //Two fulltime employees
            FullTimeEmployee fullTime1 = new FullTimeEmployee("BruceBat", "WayneCave", 10000000);
            FullTimeEmployee fullTime2 = new FullTimeEmployee("ClarkSuper", "ManKent", 500);

            //Adds the two employees
            employees.Add(fullTime1);
            employees.Add(fullTime2);

            //Two parttime employees
            PartTimeEmployee partTime1 = new PartTimeEmployee("WadeDead", "WillsonPool", 20000, 5);
            PartTimeEmployee partTime2 = new PartTimeEmployee("GhostJohnny", "BlazeRider", 10, 50);

            //Adds the two employees
            employees.Add(partTime1);
            employees.Add(partTime2);

            employees.Sort();

            //Adds the employee list to the list box
            lstbxEmployees.ItemsSource = null;
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
            //Creates a list of type FullTimeEmployee
            List<FullTimeEmployee> fullTimes = new List<FullTimeEmployee>();
            //Creates a list of type PartTimeEmployee
            List<PartTimeEmployee> partTimes = new List<PartTimeEmployee>();

            //While full time checkbox is checked and the part time checkbox is not checked
            if (chbxFullTime.IsChecked == true && chbxPartTime.IsChecked == false)
            {
                //Loops through all of the employees
                for (int i = 0; i < employees.Count; i++)
                {
                    //checks if the employee selected is a full time employee
                    switch (employees[i] is FullTimeEmployee)
                    {
                        //if the employee is a fulltime employee then the code will execute
                        case true:
                            fullTimes.Add((FullTimeEmployee)employees[i]);
                            break;
                    }
                }

                //removes all of the employees from the list and adds only the full time employees
                lstbxEmployees.ItemsSource = null;
                lstbxEmployees.ItemsSource = fullTimes;
            }
            //while part time checkbox is checked and the full time checkbox is not checked
            else if (chbxPartTime.IsChecked == true && chbxFullTime.IsChecked == false)
            {
                //Loops through all of the employees
                for (int i = 0; i < employees.Count; i++)
                {
                    //checks if the employee selected is a part time employee
                    switch (employees[i] is PartTimeEmployee)
                    {
                        //If the employee is a part time employee, the code is executed
                        case true:
                            partTimes.Add((PartTimeEmployee)employees[i]);
                            break;
                    }
                }
                //Removes all of the employees from the list and adds only the part time employees
                lstbxEmployees.ItemsSource = null;
                lstbxEmployees.ItemsSource = partTimes;
            }
            else
            {
                //In all other cases, all of the employees will be added to the list box
                lstbxEmployees.ItemsSource = null;
                lstbxEmployees.ItemsSource = employees;
            }
        }

        private void lstbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Creates a variable of type employee that contains the selected employee from the list box
            Employee selectedEmployee = lstbxEmployees.SelectedItem as Employee;

            //if the selected employee has contents, the code will be executed
            if (selectedEmployee != null)
            {
                //if the selected employee is a full time employee, the code is executed
                if (selectedEmployee is FullTimeEmployee)
                {
                    //Creates a variable of type FullTimeEmployee that contains the selected employee casted to FullTimeEmployee
                    FullTimeEmployee fullTime = (FullTimeEmployee)selectedEmployee;

                    //Adds the name of the employee to the first name text box
                    tbxFirstName.Text = fullTime.FirstName;
                    //Adds the surname of the employee to the surname text box
                    tbxSurname.Text = fullTime.Surname;
                    //Adds the salary of the employee to the salary text box
                    tbxSalary.Text = fullTime.Salary.ToString();
                    //Adds the monthly pay of the employee to the monthly pay text block
                    tblkMonthlyPay.Text = fullTime.CalculateMonthlyPay().ToString();
                    //Unchecks the full time radio button
                    rdobtnFullTime.IsChecked = true;
                    //Checks the part time radio button
                    rdobtnPartTime.IsChecked = false;

                    //Removes the text from the hourly rate and hours worked text boxes
                    tbxHourlyRate.Text = "";
                    tbxHoursWorked.Text = "";
                }
                //if the selected employee is a part time employee, the code is executed
                else
                {
                    //creates a variable of type PartTimeEmployee that contains the selected employe casted to PartTimeEmployee
                    PartTimeEmployee partTime = (PartTimeEmployee)selectedEmployee;

                    //Adds the name of the employee to the first name text box
                    tbxFirstName.Text = partTime.FirstName;
                    //Adds the surname of the employee to the surname text box
                    tbxSurname.Text = partTime.Surname;
                    //Adds the hourly rate of the employee to the hourly rate text box
                    tbxHourlyRate.Text = partTime.HourlyRate.ToString();
                    //Adds the hours worked of the employee to the hours worked text box
                    tbxHoursWorked.Text = partTime.HoursWorked.ToString();
                    //Adds the monthly pay of the employee to the monthly pay text block
                    tblkMonthlyPay.Text = partTime.CalculateMonthlyPay().ToString();
                    //Unchecks the full time radio button
                    rdobtnFullTime.IsChecked = false;
                    //Checks the part time radio button
                    rdobtnPartTime.IsChecked = true;

                    //Removes the text from the hourly rate nd hours workedd text boxes
                    tbxSalary.Text = "";
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //If the full time radio button is checked, the code will execute
            if (rdobtnFullTime.IsChecked == true)
            {
                //Adds a new employee of type full time employee and adds it to the employee list
                FullTimeEmployee fullTime = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxSalary.Text));
                employees.Add(fullTime);
            }
            //If the part time radio button is checked, the code will execute
            else
            {
                //Adds a new employee of type part time employee and adds it to the employee list
                PartTimeEmployee partTime = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxHourlyRate.Text), double.Parse(tbxHoursWorked.Text));
                employees.Add(partTime);
            }

            //Sorts the employee list
            employees.Sort();

            //Removes the employees from the list box and adds the employee list back to the 
            lstbxEmployees.ItemsSource = null;
            lstbxEmployees.ItemsSource = employees;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //removes the selected employee from the employee list
            employees.Remove((Employee)lstbxEmployees.SelectedItem);

            //If the full time radio button is checked, the code is executed
            if (rdobtnFullTime.IsChecked == true)
            {
                //creates an employee of type FullTimeEmployee and adds it to the employee list
                FullTimeEmployee fullTime = new FullTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxSalary.Text));
                employees.Add(fullTime);
            }
            //If the part time radio button is checked, the code is executed
            else
            {
                //Creates an employee of type PartTimeEmployee and adds it to the employee list
                PartTimeEmployee partTime = new PartTimeEmployee(tbxFirstName.Text, tbxSurname.Text, decimal.Parse(tbxHourlyRate.Text), double.Parse(tbxHoursWorked.Text));
                employees.Add(partTime);
            }

            //Sorts the employee list
            employees.Sort();

            //Removes all the data from the text boxes 
            btnClear_Click(null, null);

            //Removes all of the employees from the list box and adds the employee list back to it
            lstbxEmployees.ItemsSource = null;
            lstbxEmployees.ItemsSource = employees;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Clears all of the data from the text boxes

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
            //checks to see if the selected employee has content
            if (lstbxEmployees.SelectedItem != null)
            {
                //removes the selected employee from the employee list
                employees.Remove((Employee)lstbxEmployees.SelectedItem);

                //Clears all fo the data from the text boxes
                btnClear_Click(null, null);
            }

            //Removes all of the employees form the list box and adds the employee list back to it
            lstbxEmployees.ItemsSource = null;
            lstbxEmployees.ItemsSource = employees;
        }
    }
}