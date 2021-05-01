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

namespace MediAssist_Desktop_App.Views.Doctor
{
    /// <summary>
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class AppointmentView : Window
    {
        Login session;

        List<Appointment> table = null;

        Appointment loaded_appointment = null;
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
        }

        /* ROUTES--DOCTOR */
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
            DoctorDash dd = new DoctorDash(session);
            dd.Show();
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

        private void AppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            //AppointmentView av = new AppointmentView(session);
            //av.Show();
            //this.Close();
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportsView rv = new ReportsView(session);
            rv.Show();
            this.Close();
        }

        //End
        /* ROUTES--DOCTOR */

        private void LoadTable(int doc, int id)
        {
            AppointmentsModel am = new AppointmentsModel();

            table = am.getTableForDoctor(doc, id);

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
                    string dtl = "Consumer Username: "+ loaded_appointment.Login_obj_cus.Username+"\nMail: "+ loaded_appointment.Login_obj_cus.Email_obj.Mail;
                    detailTB.Text = dtl; ;
                    issueTB.Text = loaded_appointment.Issue;
                    dateTB.Text = loaded_appointment.Date;

                    approveBtn.Visibility = Visibility.Visible;
                    rejectBtn.Visibility = Visibility.Visible;
                    refreshBtn.Visibility = Visibility.Visible;
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
            LoadTable(session.ID, sortCB.SelectedIndex);
        }

        private void approveBtn_Click(object sender, RoutedEventArgs e)
        {
            string date = dateTB.Text;
            bool validation = true;
            string msg = "Message";

            if(date.Trim().Length < 1)
            {
                msg += "\nPlease give any approximate date or massage about the date";
                validation = false;
            }

            if(!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Appointment toChng = new Appointment();
                AppointmentsModel am = new AppointmentsModel();

                toChng = loaded_appointment;

                if(toChng.Appointment_status == 4)
                {
                    MessageBox.Show("Appointment Already Canceled By Consumer.");
                    refreshBtn_Click(sender, e);
                }
                else 
                {
                    toChng.Date = date;
                    toChng.Appointment_status = 2;

                    bool res = am.changeStatus(toChng);

                    if(res)
                    {
                        MessageBox.Show("Approved.");
                        refreshBtn_Click(sender, e);
                    }

                    else
                    {
                        MessageBox.Show("Something went wrong.");
                    }
                }
            }
        }

        private void rejectBtn_Click(object sender, RoutedEventArgs e)
        {
            Appointment toChng = new Appointment();
            AppointmentsModel am = new AppointmentsModel();

            toChng = loaded_appointment;

            if (toChng.Appointment_status == 4)
            {
                MessageBox.Show("Appointment Already Canceled By Consumer.");
                refreshBtn_Click(sender, e);
            }
            else
            {
                toChng.Appointment_status = 3;

                bool res = am.changeStatus(toChng);

                if (res)
                {
                    MessageBox.Show("Rejected.");
                    refreshBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            detailTB.Text = "";
            issueTB.Text = "";
            dateTB.Text = "";

            approveBtn.Visibility = Visibility.Hidden;
            rejectBtn.Visibility = Visibility.Hidden;
            refreshBtn.Visibility = Visibility.Hidden;

            loaded_appointment = null;
            LoadTable(session.ID, sortCB.SelectedIndex);
        }
    }
}
