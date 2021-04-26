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
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        Login session = null;
        public NotesWindow(Login user)
        {
            InitializeComponent();

            session = user;
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutUser au = new AboutUser(session);
            au.Show();
            this.Close();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminDash ad = new AdminDash(session);
            ad.Show();
            this.Close();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            session = null;
            LoginView lv = new LoginView();
            lv.Show();
            this.Close();
        }
    }
}
