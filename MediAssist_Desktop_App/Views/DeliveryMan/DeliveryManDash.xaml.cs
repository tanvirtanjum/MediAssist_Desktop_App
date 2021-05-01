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

namespace MediAssist_Desktop_App.Views.DeliveryMan
{
    /// <summary>
    /// Interaction logic for DeliveryManDash.xaml
    /// </summary>
    public partial class DeliveryManDash : Window
    {
        Login session = null;
        public DeliveryManDash(Login user)
        {
            session = user;

            InitializeComponent();
        }

        /*ROUTES -- DeliveryMan*/
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
            //DeliveryManDash dmd = new DeliveryManDash(session);
            //dmd.Show();
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

        private void ShipmentsBtn_Click(object sender, RoutedEventArgs e)
        {
            ShipmentsView sv = new ShipmentsView(session);
            sv.Show();
            this.Close();
        }

        //End
        /*ROUTES -- DeliveryMan*/

    }
}
