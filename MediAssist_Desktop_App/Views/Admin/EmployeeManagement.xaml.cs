using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using MediAssist_Desktop_App.Entity;
using MediAssist_Desktop_App.Model;
using MediAssist_Desktop_App.Sealed_Class;

namespace MediAssist_Desktop_App.Views.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeManagement.xaml
    /// </summary>
    public partial class EmployeeManagement : Window
    {
        Login session = null;

        List<Employee> table = null;

        Employee loaded_employee = null;

        bool sort = false;
        public EmployeeManagement(Login user)
        {
            InitializeComponent();

            session = user;

            bgCB.Items.Add("A+");
            bgCB.Items.Add("A-");
            bgCB.Items.Add("AB+");
            bgCB.Items.Add("AB-");
            bgCB.Items.Add("B+");
            bgCB.Items.Add("B-");
            bgCB.Items.Add("O+");
            bgCB.Items.Add("O-");
            bgCB.SelectedIndex = 0;

            designCB.Items.Add("---Select Designation---");
            designCB.Items.Add("ADMIN");
            designCB.Items.Add("MANAGER");
            designCB.Items.Add("DOCTOR");
            designCB.Items.Add("DELIVERY-MAN");
            designCB.SelectedIndex = 0;

            sortCB.Items.Add("ALL EMPLOYEES");
            sortCB.Items.Add("ACTIVE EMPLOYEES");
            sortCB.Items.Add("DEACTIVATED EMPLOYEES");
            sortCB.SelectedIndex = 0;

            LoadTable();
        }

        /* ROUTES -- ADMIN */
        //Start
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            session = null;
            LoginView lv = new LoginView();
            lv.Show();
            this.Close();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminDash ad = new AdminDash(session);
            ad.Show();
            this.Close();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutUser au = new AboutUser(session);
            au.Show();
            this.Close();
        }

        private void NoteBtn_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow nw = new NotesWindow(session);
            nw.Show();
            this.Close();
        }

        private void EmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            //EmployeeManagement em = new EmployeeManagement(session);
            //em.Show();
            //this.Close();
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            ConsumersManagement cm = new ConsumersManagement(session);
            cm.Show();
            this.Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationManagement rm = new RegistrationManagement(session);
            rm.Show();
            this.Close();
        }

        private void FeedbackBtn_Click(object sender, RoutedEventArgs e)
        {
            FeedbackView fv = new FeedbackView(session);
            fv.Show();
            this.Close();
        }

        //End
        /* ROUTES -- ADMIN */

        private void LoadTable()
        {
            EmployeesModel em = new EmployeesModel();

            table = em.getTable();

            if (table == null) { }

            else
            {
                int Sl = 0;

                if(sortCB.SelectedIndex == 0)
                {
                    employeesDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Role_obj.Designation, i.Login_obj.Access_obj.Approval });
                    sort = false;
                }

                if (sortCB.SelectedIndex == 1)
                {
                    employeesDG.ItemsSource = table.Where(j => j.Login_obj.Access == 1).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Role_obj.Designation, i.Login_obj.Access_obj.Approval });
                    sort = true;
                }

                if (sortCB.SelectedIndex == 2)
                {
                    employeesDG.ItemsSource = table.Where(j => j.Login_obj.Access == 2).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Role_obj.Designation, i.Login_obj.Access_obj.Approval });
                    sort = true;
                }

            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            if(sort)
            {
                loaded_employee = null;

                nameTB.Text = "";
                usernameTB.Text = "";
                usernameTB.IsReadOnly = true;
                designCB.SelectedIndex = 0;
                salaryTB.Text = "";
                bgCB.SelectedItem = "A+";
                phoneTB.Text = "";
                emailTB.Text = "";
                MessageBox.Show("Sorted Data can't be loaded.\nSelect 'ALL EMPLOYEES' for load individual.");
            }
            else
            {
                try
                {
                    var currentRowIndex = employeesDG.Items.IndexOf(employeesDG.SelectedItem);

                    loaded_employee = table[currentRowIndex];

                    if (loaded_employee != null)
                    {
                        nameTB.Text = loaded_employee.Name;
                        usernameTB.Text = loaded_employee.Login_obj.Username;
                        usernameTB.IsReadOnly = true;
                        designCB.SelectedIndex = loaded_employee.Login_obj.Role;
                        salaryTB.Text = loaded_employee.Salary.ToString();
                        bgCB.SelectedItem = loaded_employee.Blood_group;
                        phoneTB.Text = loaded_employee.Phone;
                        emailTB.Text = loaded_employee.Login_obj.Email_obj.Mail;

                        addBtn.Visibility = Visibility.Hidden;

                        updateBtn.Visibility = Visibility.Visible;

                        if (loaded_employee.Login_obj.Access == 1)
                        {
                            activateBtn.Visibility = Visibility.Hidden;
                            deactiveBtn.Visibility = Visibility.Visible;
                        }

                        if (loaded_employee.Login_obj.Access == 2)
                        {
                            activateBtn.Visibility = Visibility.Visible;
                            deactiveBtn.Visibility = Visibility.Hidden;
                        }

                        refreshBtn.Visibility = Visibility.Visible;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("NO DATA.");
                    refreshBtn_Click(sender, e);
                }
            }
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validate = true;

            string msg = "Error: ";

            string name = nameTB.Text.Trim();
            string username = usernameTB.Text.Trim();
            int designation = designCB.SelectedIndex;
            string salaryText = salaryTB.Text.Trim();
            double salary;
            bool isDouble = Double.TryParse(salaryText, out salary);
            string bg = bgCB.SelectedItem.ToString();
            string phone = phoneTB.Text.Trim();
            string email = emailTB.Text.Trim();

            if(name.Length<1)
            {
                validate = false;
                msg += "\nName Required.";
            }

            if (username.Length < 1)
            {
                validate = false;
                msg += "\nUsername Required.";
            }

            if (designation == 0)
            {
                validate = false;
                msg += "\nDesigntion Required.";
            }

            if (!isDouble)
            {
                validate = false;
                msg += "\nValid Salary Required.";
            }

            if (phone.Length < 11)
            {
                validate = false;
                msg += "\nValid Mobile Number Required.";
            }

            EmailValidator ev = new EmailValidator();

            if (!ev.ValidateEmail(email))
            {
                validate = false;
                msg += "\nValid Email Required.";
            }

            if(!validate)
            {
                MessageBox.Show(msg);
            }
            else
            {
                Employee empInsert = new Employee();
                empInsert.Name = name;
                empInsert.Blood_group = bg;
                empInsert.Phone = phone;
                empInsert.Salary = salary;

                Login logInsert = new Login();
                logInsert.Username = username;
                logInsert.Role = designation;

                Email emInsert = new Email();
                emInsert.Mail = email;

                EmployeesModel em = new EmployeesModel();
                int val = em.insertEmployee(empInsert, logInsert, emInsert);

                if(val == 0)
                {
                    MessageBox.Show("Error:\nDuplicate Username/Password");
                }
                else
                {
                    MessageBox.Show("Error:\nEmployee Added.");
                    refreshBtn_Click(sender, e);
                }
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            loaded_employee = null; 

            nameTB.Text = "";
            usernameTB.Text = "";
            usernameTB.IsReadOnly = false;
            designCB.SelectedIndex = 0;
            salaryTB.Text = "";
            bgCB.SelectedIndex = 0;
            phoneTB.Text = "";
            emailTB.Text = "";

            addBtn.Visibility = Visibility.Visible;

            updateBtn.Visibility = Visibility.Hidden;
            activateBtn.Visibility = Visibility.Hidden;
            deactiveBtn.Visibility = Visibility.Hidden;
            refreshBtn.Visibility = Visibility.Hidden;

            LoadTable();
        }

        private void activateBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginsModel lm = new LoginsModel();
            bool active = lm.activateUser(loaded_employee.Login_id);
            if (active)
            {
                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }
        }

        private void deactiveBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginsModel lm = new LoginsModel();
            bool active = lm.deactivateUser(loaded_employee.Login_id);
            if (active)
            {
                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validate = true;

            string msg = "Error: ";

            string name = nameTB.Text.Trim();
            string username = usernameTB.Text.Trim();
            int designation = designCB.SelectedIndex;
            string salaryText = salaryTB.Text.Trim();
            double salary;
            bool isDouble = Double.TryParse(salaryText, out salary);
            string bg = bgCB.SelectedItem.ToString();
            string phone = phoneTB.Text.Trim();
            string email = emailTB.Text.Trim();

            if (name.Length < 1)
            {
                validate = false;
                msg += "\nName Required.";
            }

            if (username.Length < 1)
            {
                validate = false;
                msg += "\nUsername Required.";
            }

            if (designation == 0)
            {
                validate = false;
                msg += "\nDesigntion Required.";
            }

            if (!isDouble)
            {
                validate = false;
                msg += "\nValid Salary Required.";
            }

            if (phone.Length < 11)
            {
                validate = false;
                msg += "\nValid Mobile Number Required.";
            }

            EmailValidator ev = new EmailValidator();

            if (!ev.ValidateEmail(email))
            {
                validate = false;
                msg += "\nValid Email Required.";
            }

            if (!validate)
            {
                MessageBox.Show(msg);
            }
            else
            {
                string priv = loaded_employee.Login_obj.Email_obj.Mail;

                Employee empUpdate = new Employee();
                empUpdate = loaded_employee;
                empUpdate.Name = name;
                empUpdate.Blood_group = bg;
                empUpdate.Phone = phone;
                empUpdate.Salary = salary;
                empUpdate.Login_obj.Role = designation;
                empUpdate.Login_obj.Email_obj.Mail = email;

                EmployeesModel em = new EmployeesModel();

                bool val = em.updateEmployee(empUpdate, priv);

                if (!val)
                {
                    MessageBox.Show("Error:\nDuplicate Email.");
                }
                else
                {
                    MessageBox.Show("Error:\nInformation Updated");
                    refreshBtn_Click(sender, e);
                }
            }
        }
    }
}
