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
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : Window
    {
        Login session;

        List<Report> table = null;
        List<Login> table2 = null;

        Report loaded_report = null;
        Login loaded_cus = null;
        public ReportsView(Login user)
        {
            InitializeComponent();

            session = user;

            LoadTableReports();
            LoadTableCus();
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
            AppointmentView av = new AppointmentView(session);
            av.Show();
            this.Close();
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            //ReportsView rv = new ReportsView(session);
            //rv.Show();
            //this.Close();
        }

        //End
        /* ROUTES--DOCTOR */

        private void LoadTableReports()
        {
            ReportsModel rm = new ReportsModel();

            table = rm.getTableForDoctor(session.ID);

            if (table == null) { }

            else
            {
                int Sl = 0;
                reportDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, Subject = i.Subject, Consumer = i.Login_obj_cus.Username, Email = i.Login_obj_cus.Email_obj.Mail });
            }
        }

        private void LoadTableCus()
        {
            LoginsModel om = new LoginsModel();

            table2 = om.getCus();

            if (table2 == null) { }

            else
            {
                int Sl = 0;
                consumerDG.ItemsSource = table2.Select(i => new { Sl = table2.IndexOf(i) + 1, Username = i.Username, Email = i.Email_obj.Mail });
            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = reportDG.Items.IndexOf(reportDG.CurrentItem);

                loaded_report = table[currentRowIndex];


                prescribetoTB.Text = loaded_report.Login_obj_cus.Username;
                subjectTB.Text = loaded_report.Subject;
                reportTB.Text = loaded_report.Report_txt;

                updateBtn.Visibility = Visibility.Visible;
                deleteBtn.Visibility = Visibility.Visible;
                prescribeBtn.Visibility = Visibility.Hidden;
                prescribeBtn.IsEnabled = false;

                consumerDG.IsEnabled = false;

                loaded_cus = null;

            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void load_del_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = consumerDG.Items.IndexOf(consumerDG.CurrentItem);

                loaded_cus = table2[currentRowIndex];

                prescribetoTB.Text = loaded_cus.Username;

                updateBtn.Visibility = Visibility.Hidden;
                deleteBtn.Visibility = Visibility.Hidden;
                prescribeBtn.Visibility = Visibility.Visible;
                prescribeBtn.IsEnabled = true;

                loaded_report = null;
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            prescribetoTB.Text = "";
            subjectTB.Text = "";
            reportTB.Text = "";

            updateBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
            prescribeBtn.Visibility = Visibility.Visible;
            prescribeBtn.IsEnabled = false;

            consumerDG.IsEnabled = true;

            loaded_report = null;
            loaded_cus = null;

            LoadTableReports();
            LoadTableCus();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string prescribeto = prescribetoTB.Text;
            string subject = subjectTB.Text;
            string report = reportTB.Text;

            bool validation = true;
            string msg = "Message:";

            if (prescribeto.Trim().Length < 1 || loaded_report == null)
            {
                msg += "\nNo Consumer Selected.";
                validation = false;
            }

            if (subject.Trim().Length < 1)
            {
                msg += "\nPrescription Requied.";
                validation = false;
            }

            if (prescribeto.Trim().Length < 1)
            {
                msg += "\nReport Required.";
                validation = false;
            }

            if (!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Report rep = new Report();
                rep = loaded_report;

                rep.Subject = subject;
                rep.Report_txt = report;

                ReportsModel rm = new ReportsModel();

                bool result = rm.updateReport(rep);

                if (result)
                {
                    MessageBox.Show("Report Updated");

                    refreshBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }

        private void prescribeBtn_Click(object sender, RoutedEventArgs e)
        {
            string prescribeto = prescribetoTB.Text;
            string subject = subjectTB.Text;
            string report = reportTB.Text;

            bool validation = true;
            string msg = "Message:";

            if(prescribeto.Trim().Length <1 || loaded_cus == null)
            {
                msg += "\nNo Consumer Selected.";
                validation = false;
            }

            if (subject.Trim().Length < 1)
            {
                msg += "\nPrescription Requied.";
                validation = false;
            }

            if (prescribeto.Trim().Length < 1)
            {
                msg += "\nReport Required.";
                validation = false;
            }

            if(!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Report rep = new Report();

                rep.Subject = subject;
                rep.Report_txt = report;
                rep.Prescribe_by = session.ID;
                rep.Prescribe_for = loaded_cus.ID;

                ReportsModel rm = new ReportsModel();

                bool result = rm.addReport(rep);

                if(result)
                {
                    MessageBox.Show("Report Prescribed");

                    refreshBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loaded_report == null)
            {
                MessageBox.Show("No Report Found.");
            }

            else
            {
                ReportsModel rm = new ReportsModel();
                bool result = rm.DeleteReport(loaded_report.ID);

                if(result)
                {
                    MessageBox.Show("Report Deleted.");
                    refreshBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }
    }
}
