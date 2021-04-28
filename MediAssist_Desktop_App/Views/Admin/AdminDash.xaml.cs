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
    /// Interaction logic for AdminDash.xaml
    /// </summary>
    public partial class AdminDash : Window
    {
        Login session = null;
        public AdminDash(Login user)
        {
            InitializeComponent();

            session = user;
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

        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FeedbackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //End
        /* ROUTES -- ADMIN */
    }
}
