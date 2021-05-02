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
    /// Interaction logic for PrescriptionView.xaml
    /// </summary>
    public partial class PrescriptionView : Window
    {
        Login session;

        List<Report> table = null;

        Report loaded_report = null;
        public PrescriptionView(Login user)
        {
            InitializeComponent();

            session = user;

            LoadTableReports();
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
            //PrescriptionView pv = new PrescriptionView(session);
            //pv.Show();
            //this.Close();
        }

        private void appontmentBtn_Click(object sender, RoutedEventArgs e)
        {
            AppointmentView av = new AppointmentView(session);
            av.Show();
            this.Close();
        }



        //End
        /*ROUTES -- CONSUMERS*/


        private void LoadTableReports()
        {
            ReportsModel rm = new ReportsModel();

            table = rm.getTableForConsumer(session.ID);

            if (table == null) { }

            else
            {
                int Sl = 0;
                reportDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, Subject = i.Subject, Doctor = i.Login_obj_cus.Username, Email = i.Login_obj_cus.Email_obj.Mail });
            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = reportDG.Items.IndexOf(reportDG.CurrentItem);

                loaded_report = table[currentRowIndex];

                subjectTB.Text = loaded_report.Subject;
                reportTB.Text = loaded_report.Report_txt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            subjectTB.Text = "";
            reportTB.Text = "";

            loaded_report = null;
           
            LoadTableReports();
        }
    }
}
