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
using MediAssist_Desktop_App.Sealed_Class;

namespace MediAssist_Desktop_App.Views.Consumer
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            bgCB.Items.Add("A+");
            bgCB.Items.Add("A-");
            bgCB.Items.Add("AB+");
            bgCB.Items.Add("AB-");
            bgCB.Items.Add("B+");
            bgCB.Items.Add("B-");
            bgCB.Items.Add("O+");
            bgCB.Items.Add("O-");
            bgCB.SelectedIndex = 0;
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validate = true;

            string msg = "Error: ";

            string name = nameTB.Text.Trim();
            string username = usernameTB.Text.Trim();
            string password = passwordTB.Text.Trim();
            string occupation = occupationTB.Text;
            string bg = bgCB.SelectedItem.ToString();
            string phone = conTB.Text.Trim();
            string email = mailTB.Text.Trim();

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

            if (password.Length < 4)
            {
                validate = false;
                msg += "\nPassword length must be >= 4.";
            }

            if (occupation.Trim().Length < 1)
            {
                validate = false;
                msg += "\nOccupation Required.";
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
                Consumers consumer = new Consumers();
                consumer.Name = name;
                consumer.Occupation = occupation;
                consumer.Blood_group = bg;
                consumer.Phone = phone;
              

                Login logInsert = new Login();
                logInsert.Username = username;
                logInsert.Password = password;
                logInsert.Role = 5;
                logInsert.Reg_status = 1;
                logInsert.Access = 2;

                Email emInsert = new Email();
                emInsert.Mail = email;

                ConsumersModel em = new ConsumersModel();
                int val = em.insertConsumer(consumer, logInsert, emInsert);

                if (val == 0)
                {
                    MessageBox.Show("Error:\nDuplicate Username/Password");
                }
                else
                {
                    MessageBox.Show("Registered.\nUsername: "+username+"\nPassword: "+password+"\nWait for ADMIN approval.");
                    registerBtn_Copy_Click(sender, e);
                   
                }
            }
        }

        private void registerBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            LoginView lv = new LoginView();
            lv.Show();
            this.Close();
        }
    }
}
