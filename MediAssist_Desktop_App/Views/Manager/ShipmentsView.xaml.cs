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
    /// Interaction logic for ShipmentsView.xaml
    /// </summary>
    public partial class ShipmentsView : Window
    {
        Login session = null;

        List<Order> table = null;

        Order loaded_order = null;
        public ShipmentsView(Login user)
        {
            InitializeComponent();

            session = user;

            LoadTableOrders();
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
            MedicineManagement mm = new MedicineManagement(session);
            mm.Show();
            this.Close();
        }

        private void PendingOrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            PendingOrders po = new PendingOrders(session);
            po.Show();
            this.Close();
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            //ShipmentsView sv = new ShipmentsView(session);
            //sv.Show();
            //this.Close();
        }

        //End
        /*ROUTES -- MANAGER*/


        private void LoadTableOrders()
        {
            OrdersModel om = new OrdersModel();

            table = om.getOrders();

            if (table == null) { }

            else
            {
                int Sl = 0;
                orderDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, Identification = i.Cart_key_id, i.Login_obj_cus.Username, Status =  i.Order_status_obj.Stat });
            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = orderDG.Items.IndexOf(orderDG.CurrentItem);

                loaded_order = table[currentRowIndex];

                string txt = "";
                txt += "Identification Code: " + loaded_order.Cart_key_id;
                txt += "\nOrdered By: " + loaded_order.Login_obj_cus.Username;
                txt += "\nOrder Status: " + loaded_order.Order_status_obj.Stat;
                txt += "\n________________________________________________________________";
                txt += "\nMedicine";
                txt += "  Quantity";
                txt += "  Net Price";
                double price = 0.0;
                //foreach (Cart med in loaded_order.Items)
                for (int i = 0; i < loaded_order.Items.Count(); i++)
                {
                    price += loaded_order.Items[i].Total_Price;
                    txt += "\n" + loaded_order.Items[i].Medicine_obj.Name + "\t" + loaded_order.Items[i].Quantity_Ordered + "\t" + loaded_order.Items[i].Total_Price;
                }
                txt += "\n\nTo be paid: " + price;

                detailsTB.Text = txt;

            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }
        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            detailsTB.Text = "";
           
            loaded_order = null;

            LoadTableOrders();
        }
    }
}
