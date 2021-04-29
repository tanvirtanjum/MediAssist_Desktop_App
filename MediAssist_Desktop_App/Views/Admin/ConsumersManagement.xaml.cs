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
    /// Interaction logic for CosumersManagement.xaml
    /// </summary>
    public partial class ConsumersManagement : Window
    {
        Login session = null;

        List<Consumers> table = null;

        Consumers loaded_consumers = null;

        bool sort = false;
        public ConsumersManagement(Login user)
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

            sortCB.Items.Add("ALL CONSUMERS");
            sortCB.Items.Add("ACTIVE CONSUMERS");
            sortCB.Items.Add("DEACTIVATED CONSUMERS");
            sortCB.Items.Add("PENDING REGISTRATION CONSUMERS");
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
            EmployeeManagement em = new EmployeeManagement(session);
            em.Show();
            this.Close();
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            //ConsumersManagement cm = new ConsumersManagement(session);
            //cm.Show();
            //this.Close();
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
            ConsumersModel cm = new ConsumersModel();

            table = cm.getTable();

            if (table == null) { }

            else
            {
                int Sl = 0;

                if (sortCB.SelectedIndex == 0)
                {
                    customersDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Reg_Status_obj.Status, i.Login_obj.Access_obj.Approval });
                    sort = false;
                }

                if (sortCB.SelectedIndex == 1)
                {
                    customersDG.ItemsSource = table.Where(j => j.Login_obj.Access == 1 && j.Login_obj.Reg_status == 2).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Reg_Status_obj.Status, i.Login_obj.Access_obj.Approval });
                    sort = true;
                }

                if (sortCB.SelectedIndex == 2)
                {
                    customersDG.ItemsSource = table.Where(j => j.Login_obj.Access == 2 && j.Login_obj.Reg_status == 2).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Reg_Status_obj.Status, i.Login_obj.Access_obj.Approval });
                    sort = true;
                }

                if (sortCB.SelectedIndex == 3)
                {
                    customersDG.ItemsSource = table.Where(j => j.Login_obj.Access == 2 && j.Login_obj.Reg_status == 1).Select(i => new { Sl = table.IndexOf(i) + 1, i.Login_obj.Username, i.Name, i.Login_obj.Reg_Status_obj.Status, i.Login_obj.Access_obj.Approval });
                    sort = true;
                }

            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            if (sort)
            {
                loaded_consumers = null;

                nameTB.Text = "";
                usernameTB.Text = "";
                usernameTB.IsReadOnly = true;
                occupationTB.Text = "";
                bgCB.SelectedItem = "A+";
                phoneTB.Text = "";
                emailTB.Text = "";
                MessageBox.Show("Sorted Data can't be loaded.\nSelect 'ALL EMPLOYEES' for load individual.");
            }
            else
            {
                try
                {
                    var currentRowIndex = customersDG.Items.IndexOf(customersDG.SelectedItem);

                    loaded_consumers = table[currentRowIndex];

                    if (loaded_consumers != null)
                    {
                        nameTB.Text = loaded_consumers.Name;
                        usernameTB.Text = loaded_consumers.Login_obj.Username;
                        occupationTB.Text = loaded_consumers.Occupation.ToString();
                        bgCB.SelectedItem = loaded_consumers.Blood_group;
                        phoneTB.Text = loaded_consumers.Phone;
                        emailTB.Text = loaded_consumers.Login_obj.Email_obj.Mail;

                        if (loaded_consumers.Login_obj.Access == 1 && loaded_consumers.Login_obj.Reg_status == 2)
                        {
                            activateBtn.Visibility = Visibility.Hidden;
                            deactiveBtn.Visibility = Visibility.Visible;
                        }

                        if (loaded_consumers.Login_obj.Access == 2 && loaded_consumers.Login_obj.Reg_status == 2)
                        {
                            activateBtn.Visibility = Visibility.Visible;
                            deactiveBtn.Visibility = Visibility.Hidden;
                        }

                        if(loaded_consumers.Login_obj.Reg_status == 1)
                        {
                            activateBtn.Visibility = Visibility.Hidden;
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
            bool active = lm.activateUser(loaded_consumers.Login_id);
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
            bool active = lm.deactivateUser(loaded_consumers.Login_id);
            if (active)
            {
                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }
        }

    }
}
