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

namespace MediAssist_Desktop_App.Views.Manager
{
    /// <summary>
    /// Interaction logic for MedicineManagement.xaml
    /// </summary>
    public partial class MedicineManagement : Window
    {
        Login session = null;
        public MedicineManagement(Login user)
        {
            InitializeComponent();

            session = user;
        }

        /*ROUTES -- MANAGER*/
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
            ManagerDash md = new ManagerDash(session);
            md.Show();
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

        private void MedicinesBtn_Click(object sender, RoutedEventArgs e)
        {
            //MedicineManagement mm = new MedicineManagement(session);
            //mm.Show();
            //this.Close();
        }

        private void PendingOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            PendingOrders po = new PendingOrders(session);
            po.Show();
            this.Close();
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            ShipmentsView sv = new ShipmentsView(session);
            sv.Show();
            this.Close();
        }

        //End
        /*ROUTES -- MANAGER*/
    }
}
