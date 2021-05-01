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
    /// Interaction logic for ConsumerDash.xaml
    /// </summary>
    public partial class ConsumerDash : Window
    {
        Login session = null;
        public ConsumerDash(Login user)
        {
            session = user;
            InitializeComponent();
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
            //ConsumerDash cd = new ConsumerDash(session);
            //cd.Show();
            //this.Close();
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
            AppointmentView av = new AppointmentView(session);
            av.Show();
            this.Close();
        }



        //End
        /*ROUTES -- CONSUMERS*/

    }
}
