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

namespace MediAssist_Desktop_App.Views.Consumer
{
    /// <summary>
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class AppointmentView : Window
    {
        Login session;

        List<Appointment> table = null;
        List<Login> table2 = null;

        Appointment loaded_appointment = null;
        Login loaded_doc = null;
        public AppointmentView(Login user)
        {
            InitializeComponent();

            session = user;

            sortCB.Items.Add("ALL APPOINTMENTS");
            sortCB.Items.Add("PENDING");
            sortCB.Items.Add("APPROVED");
            sortCB.Items.Add("REJECTED");
            sortCB.Items.Add("CANCELED");
            sortCB.SelectedIndex = 0;

            LoadTable(session.ID, sortCB.SelectedIndex);
            LoadTableDoc();
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
            //AppointmentView av = new AppointmentView(session);
            //av.Show();
            //this.Close();
        }

        //End
        /*ROUTES -- CONSUMERS*/

        private void LoadTable(int con, int id)
        {
            AppointmentsModel am = new AppointmentsModel();

            table = am.getTableForConsumer(con, id);

            if (table == null) { MessageBox.Show("....!"); }

            else
            {
                appointmentsDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, RequestBy = i.Login_obj_cus.Username, Date = i.Date, Status = i.Appointment_status_obj.Status });

            }
        }
        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = appointmentsDG.Items.IndexOf(appointmentsDG.SelectedItem);

                loaded_appointment = table[currentRowIndex];

                if (loaded_appointment != null)
                {
                    docTB.Text = loaded_appointment.Login_obj_doc.Username; ;
                    issueTB.Text = loaded_appointment.Issue;
                    dateTB.Text = loaded_appointment.Date;

                    appointBtn.Visibility = Visibility.Hidden;
                    rejectBtn.Visibility = Visibility.Visible;
                    refreshBtn.Visibility = Visibility.Visible;

                    issueTB.IsReadOnly = true;

                    if(loaded_appointment.Appointment_status == 1 || loaded_appointment.Appointment_status == 2)
                    {
                        rejectBtn.IsEnabled = true;
                    }
                    else
                    {
                        rejectBtn.IsEnabled = false;
                    }

                    docDG.IsEnabled = false;

                    loaded_doc = null;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
                refreshBtn_Click(sender, e);
            }
        }

        private void LoadTableDoc()
        {
            LoginsModel om = new LoginsModel();

            table2 = om.getDoc();

            if (table2 == null) { }

            else
            {
                int Sl = 0;
                docDG.ItemsSource = table2.Select(i => new { Sl = table2.IndexOf(i) + 1, Username = i.Username, Email = i.Email_obj.Mail });
            }
        }

        private void load_doc_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = docDG.Items.IndexOf(docDG.CurrentItem);

                loaded_doc = table2[currentRowIndex];

                loaded_appointment = null;

                docTB.Text = loaded_doc.Username;

                appointBtn.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable(session.ID, sortCB.SelectedIndex);
        }

        private void rejectBtn_Click(object sender, RoutedEventArgs e)
        {
            Appointment toChng = new Appointment();
            AppointmentsModel am = new AppointmentsModel();

            toChng = loaded_appointment;

            if (toChng.Appointment_status == 3)
            {
                MessageBox.Show("Appointment Already Canceled By Doctor.");
                refreshBtn_Click(sender, e);
            }
            else
            {
                toChng.Appointment_status = 4;

                bool res = am.changeStatus(toChng);

                if (res)
                {
                    MessageBox.Show("Cancelled.");
                    refreshBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }

        }

        private void appointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loaded_doc == null)
            {
                MessageBox.Show("No Doctor Selected;");
            }
            else
            {
                string issue = issueTB.Text;
                string date = dateTB.Text;

                bool validation = true;
                string msg = "Message:";

                if (issue.Trim().Length < 1)
                {
                    validation = false;
                    msg += "\nIssue Required.";
                }
                if (date.Trim().Length < 1)
                {
                    validation = false;
                    msg += "\n Date/Message Regarding Date Required.";
                }

                if (!validation)
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    Appointment appointment = new Appointment();
                    appointment.Date = date;
                    appointment.Issue = issue;
                    appointment.Doctor_id = loaded_doc.ID;
                    appointment.Consumer_id = session.ID;
                    appointment.Appointment_status = 1;

                    AppointmentsModel am = new AppointmentsModel();
                    bool result = am.addAppointment(appointment);

                    if(result)
                    {
                        MessageBox.Show("Appointment Requested.");
                        refreshBtn_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong.");
                    }
                }
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            docTB.Text = "";
            issueTB.Text = "";
            issueTB.IsReadOnly = false;
            dateTB.Text = "";

            appointBtn.Visibility = Visibility.Visible;
            rejectBtn.Visibility = Visibility.Hidden;
            rejectBtn.IsEnabled = false;
            refreshBtn.Visibility = Visibility.Hidden;

            docDG.IsEnabled = true;

            LoadTable(session.ID, sortCB.SelectedIndex);
            LoadTableDoc();

            loaded_appointment = null;
            loaded_doc = null;
        }
    }
}
