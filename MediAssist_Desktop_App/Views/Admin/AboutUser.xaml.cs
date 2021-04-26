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
    /// Interaction logic for AboutUser.xaml
    /// </summary>
    public partial class AboutUser : Window
    {
        Login session = null;
        Employee employee = new Employee();
        public AboutUser(Login user)
        {

            InitializeComponent();

            session = user; 

            conditionLbl.Content = "Conditions: "+ "\n1. Empty spaces will be ignored/trimmed."+ "\n2. New password length must be greater than 3."+ "\n3. New password & Confirm Password must be matched."+ "\n4. Old password should be correct.";

            EmployeesModel em = new EmployeesModel();
            employee = em.getEmployee(session.ID);

            fillup(employee);

        }

        public void fillup(Employee employee)
        {
            nameTB.Text = employee.Name;
            usernameTB.Text = employee.Login_obj.Username;
            designationTB.Text = employee.Login_obj.Role_obj.Designation;
            salaryTB.Text = employee.Salary.ToString();
            bgTB.Text = employee.Blood_group;
            phoneTB.Text = employee.Phone;
            emailTB.Text = employee.Login_obj.Email_obj.Mail;
        }

        public void TBLogic()
        {
            if(proceedBtn.Visibility == Visibility.Visible)
            {
                nameTB.IsReadOnly = false;
                phoneTB.IsReadOnly = false;
                emailTB.IsReadOnly = false;
            }

            else
            {
                nameTB.IsReadOnly = true;
                phoneTB.IsReadOnly = true;
                emailTB.IsReadOnly = true;
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            proceedBtn.Visibility = Visibility.Visible;
            editBtn.Visibility = Visibility.Hidden;

            TBLogic();
        }

        private void proceedBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string oldp = oldpassTb.Password;
            string newp = newpassTb.Password;
            string conp = conpassTb.Password;

            bool validate = true;
            string msg = "Message: ";

            if(oldp != session.Password)
            {
                validate = false;
                msg += "\nWrong old password.";
            }

            if(newp.Trim().Length < 4)
            {
                validate = false;
                msg += "\nNew Password is too short.";
            }

            if(newp.Trim() != conp.Trim())
            {
                validate = false;
                msg += "\nNew Password and Confirm Password don't match.";
            }

            if(!validate)
            {
                MessageBox.Show(msg);
            }

            else
            {
                LoginsModel lm = new LoginsModel();
                bool confirmation = lm.changePassword(conp, session.ID);

                if(confirmation)
                {
                    MessageBox.Show("Password Changed.\nPlease Login Again.");
                    logoutBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }

        }

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

        private void NoteBtn_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow nw = new NotesWindow(session);
            nw.Show();
            this.Close();
        }
    }
}
