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
    /// Interaction logic for AboutUser.xaml
    /// </summary>
    public partial class AboutUser : Window
    {
        Login session = null;
        Consumers consumer = new Consumers();
        public AboutUser(Login user)
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

            session = user; 

            conditionLbl.Content = "Conditions: "+ "\n1. Empty spaces will be ignored/trimmed."+ "\n2. New password length must be greater than 3."+ "\n3. New password & Confirm Password must be matched."+ "\n4. Old password should be correct.";

            

            fillup(session);

        }


        /*ROUTES -- CONSUMERS*/
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
            ConsumerDash cd = new ConsumerDash(session);
            cd.Show();
            this.Close();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            //AboutUser au = new AboutUser(session);
            //au.Show();
            //this.Close();
        }

        private void NoteBtn_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow nw = new NotesWindow(session);
            nw.Show();
            this.Close();
        }

        private void shopBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopView sv = new ShopView(session);
            sv.Show();
            this.Close();
        }

        private void puchaseHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            HistoryView hv = new HistoryView(session);
            hv.Show();
            this.Close();
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionView pv = new PrescriptionView(session);
            pv.Show();
            this.Close();
        }

        private void appontmentBtn_Click(object sender, RoutedEventArgs e)
        {
            AppointmentView av = new AppointmentView(session);
            av.Show();
            this.Close();
        }



        //End
        /*ROUTES -- CONSUMERS*/

        public void fillup(Login session)
        {
            ConsumersModel em = new ConsumersModel();
            consumer = em.getConsumer(session.ID);

            nameTB.Text = consumer.Name;
            usernameTB.Text = consumer.Login_obj.Username;
            designationTB.Text = consumer.Login_obj.Role_obj.Designation;
            salaryTB.Text = consumer.Occupation.ToString();
            bgCB.SelectedItem = consumer.Blood_group;
            phoneTB.Text = consumer.Phone;
            emailTB.Text = consumer.Login_obj.Email_obj.Mail;
        }

        public void TBLogic()
        {
            if(proceedBtn.Visibility == Visibility.Visible)
            {
                nameTB.IsReadOnly = false;
                phoneTB.IsReadOnly = false;
                emailTB.IsReadOnly = false;
                bgCB.IsEnabled = true;
            }

            else
            {
                nameTB.IsReadOnly = true;
                phoneTB.IsReadOnly = true;
                emailTB.IsReadOnly = true;
                bgCB.IsEnabled = false;
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
            string name = nameTB.Text;
            string phone = phoneTB.Text;
            string mail = emailTB.Text;

            bool validate = true;
            string msg = "Message: ";

            if(name.Trim().Length < 1)
            {
                validate = false;
                msg += "\nName Required.";
            }

            if (phone.Trim().Length < 1)
            {
                validate = false;
                msg += "\nPhone Number Required.";
            }

            if (phone.Trim().Length < 11)
            {
                validate = false;
                msg += "\nInvalid Phone Number.";
            }

            if (mail.Trim().Length < 1)
            {
                validate = false;
                msg += "\nEmail Required.";
            }
            else
            {
                EmailValidator ev = new EmailValidator();

                if (!ev.ValidateEmail(mail))
                {
                    validate = false;
                    msg += "\nInvalid Email.";
                }
            }

            if(!validate)
            {
                MessageBox.Show(msg);
            }
            else
            {
                string priv = consumer.Login_obj.Email_obj.Mail;

                Consumers consumerUpdate = new Consumers();
                consumerUpdate = consumer;

                consumerUpdate.Name = name;
                consumerUpdate.Login_obj.Email_obj.Mail = mail;
                consumerUpdate.Phone = phone;
                consumerUpdate.Blood_group = bgCB.Text;

                ConsumersModel em = new ConsumersModel();

                bool confirm = em.updateProfile(consumerUpdate, priv);

                if(confirm)
                {
                    proceedBtn.Visibility = Visibility.Hidden;
                    editBtn.Visibility = Visibility.Visible;

                    MessageBox.Show("Profile Updated.");

                    TBLogic();
                    fillup(session);
                }

                else
                {
                    MessageBox.Show("Error.\nPossible Issue:\nRequired Unique Email.");
                }
            }

           
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

        
    }
}
