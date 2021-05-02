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
using MediAssist_Desktop_App.Views.Admin;
using MediAssist_Desktop_App.Views.Manager;
using MediAssist_Desktop_App.Views.DeliveryMan;
using MediAssist_Desktop_App.Views.Doctor;
using MediAssist_Desktop_App.Views.Consumer;
using MediAssist_Desktop_App.Sealed_Class;

namespace MediAssist_Desktop_App
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void loginBTN_Click(object sender, RoutedEventArgs e)
        {
            Login user = null;
            Login session = null;

            bool validate = true;
            string msg = "Reqired: ";

            string username = usernameTB.Text.ToString();
            string password = passwordTB.Password.ToString();

            if(username.Trim().Length < 1)
            {
                msg += "\nUsername.";
                validate = false;
            }

            if (password.Trim().Length < 1)
            {
                msg += "\nPassword.";
                validate = false;
            }

            if(!validate)
            {
                MessageBox.Show(msg);
            }
            else
            {
                LoginsModel lm = new LoginsModel();

                user = lm.getUser(username, password);

                if(user != null)
                {
                    loginErrLbl.Visibility = Visibility.Hidden;

                    //For Check Purpose
                    ////MessageBox.Show("User: " + user.Username+"\nAccess: "+user.Access_obj.Approval+"\nRole: "+user.Role_obj.Designation+"\nEmail: "+user.Email_obj.Mail+"\nRegistration: "+user.Reg_Status_obj.Status);
                    //

                    if(user.Access == 1 && user.Reg_status == 2)
                    {
                        if(user.Role == 1)
                        {
                            session = user;
                            //Open Admin Dash
                            AdminDash ad = new AdminDash(session);
                            ad.Show();

                            this.Close();
                        }

                        if (user.Role == 2)
                        {
                            session = user;
                            //Open Manager Dash
                            ManagerDash md = new ManagerDash(session);
                            md.Show();
                           
                            this.Close();
                        }

                        if (user.Role == 3)
                        {
                            session = user;
                            //Open Doctor Dash
                            DoctorDash dd = new DoctorDash(session);
                            dd.Show();

                            this.Close();
                        }

                        if (user.Role == 4)
                        {
                            session = user;
                            //Open Delivery Man Dash
                            DeliveryManDash dmd = new DeliveryManDash(session);
                            dmd.Show();

                            this.Close();
                        }

                        if (user.Role == 5)
                        {
                            session = user;

                            TokenGenerator tg = new TokenGenerator();
                            session.Cart_id = tg.token(session.ID);

                            //Open Consumer Dash
                            ConsumerDash cd = new ConsumerDash(session);
                            cd.Show();

                            this.Close();
                        }
                    }
                    else
                    {
                        string msg2 = "ISSUES: ";

                        if(user.Reg_status != 2)
                        {
                            msg2 += "\nRegistration Status: "+user.Reg_Status_obj.Status;
                        }

                        if(user.Access != 1)
                        {
                            msg2 += "\nSystem Access: " + user.Access_obj.Approval;
                        }

                        MessageBox.Show(msg2);
                    }
                }

                else
                {
                    loginErrLbl.Visibility = Visibility.Visible;
                }
            }

            user = null;
        }

        private void registerBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
