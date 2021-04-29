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
    /// Interaction logic for RegistrationManagement.xaml
    /// </summary>
    public partial class RegistrationManagement : Window
    {
        Login session = null;

        List<Login> table = null;

        Login loaded_consumers = null;
        public RegistrationManagement(Login user)
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
            EmployeeManagement em = new EmployeeManagement(session);
            em.Show();
            this.Close();
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            ConsumersManagement cm = new ConsumersManagement(session);
            cm.Show();
            this.Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            //RegistrationManagement rm = new RegistrationManagement(session);
            //rm.Show();
            //this.Close();
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
            LoginsModel cm = new LoginsModel();

            table = cm.getTable();

            if (table == null) { }

            else
            {
                customersDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, i.Consumers_obj.Name, i.Username, i.Consumers_obj.Login_obj.Email_obj.Mail, i.Consumers_obj.Phone });
            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = customersDG.Items.IndexOf(customersDG.SelectedItem);

                if(currentRowIndex != null)
                {
                    loaded_consumers = table[currentRowIndex];

                    if (loaded_consumers != null)
                    {
                        nameTB.Text = loaded_consumers.Consumers_obj.Name;
                        usernameTB.Text = loaded_consumers.Username;
                        occupationTB.Text = loaded_consumers.Consumers_obj.Occupation.ToString();
                        bgCB.SelectedItem = loaded_consumers.Consumers_obj.Blood_group;
                        phoneTB.Text = loaded_consumers.Consumers_obj.Phone;
                        emailTB.Text = loaded_consumers.Consumers_obj.Login_obj.Email_obj.Mail;

                        activateBtn.Visibility = Visibility.Visible;
                        deactiveBtn.Visibility = Visibility.Visible;

                        refreshBtn.Visibility = Visibility.Visible;
                    }
                }

                else
                {
                    MessageBox.Show("NO DATA.");
                    refreshBtn_Click(sender, e);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
                refreshBtn_Click(sender, e);
            }
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            loaded_consumers = null;

            nameTB.Text = "";
            usernameTB.Text = "";
            usernameTB.IsReadOnly = false;
            occupationTB.Text = "";
            bgCB.SelectedIndex = 0;
            phoneTB.Text = "";
            emailTB.Text = "";

            activateBtn.Visibility = Visibility.Hidden;
            deactiveBtn.Visibility = Visibility.Hidden;
            refreshBtn.Visibility = Visibility.Hidden;

            LoadTable();
        }

        private void activateBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginsModel lm = new LoginsModel();
            bool active = lm.acccptConsumer(loaded_consumers.ID);
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
            bool active = lm.rejectUser(loaded_consumers);
            if (active)
            {
                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }
        }

        private void acceptAllBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginsModel lm = new LoginsModel();
            bool acceptAll = lm.acccptAllConsumers();

            if(acceptAll)
            {
                MessageBox.Show("All Registrations are Accepted.");
                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }
        }
    }
}
