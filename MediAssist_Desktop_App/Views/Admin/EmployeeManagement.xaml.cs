using System;
using System.Collections.Generic;
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
                }

                if (sortCB.SelectedIndex == 1)
                {
                    employeesDG.ItemsSource = table.Where(j => j.Login_obj.Access == 1).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Role_obj.Designation, i.Login_obj.Access_obj.Approval });
                }

                if (sortCB.SelectedIndex == 2)
                {
                    employeesDG.ItemsSource = table.Where(j => j.Login_obj.Access == 2).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Role_obj.Designation, i.Login_obj.Access_obj.Approval });
                }

            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = employeesDG.Items.IndexOf(employeesDG.CurrentItem);

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

            catch(Exception ex)
            {
                MessageBox.Show("NO DATA.");
                refreshBtn_Click(sender, e);
            }
            
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void activateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deactiveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
