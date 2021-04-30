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
    /// Interaction logic for PendingOrders.xaml
    /// </summary>
    public partial class PendingOrders : Window
    {
        Login session = null;

        List<Order> table = null;
        List<Login> table2 = null;

        Order loaded_order = null;
        Login loaded_del = null;
        public PendingOrders(Login user)
        {
            InitializeComponent();

            session = user;

            LoadTablePendingOrders();
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
            //PendingOrders po = new PendingOrders(session);
            //po.Show();
            //this.Close();
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            ShipmentsView sv = new ShipmentsView(session);
            sv.Show();
            this.Close();
        }

        //End
        /*ROUTES -- MANAGER*/

        private void LoadTablePendingOrders()
        {
            OrdersModel om = new OrdersModel();

            table = om.getPendings();

            if (table == null) { }

            else
            {
                int Sl = 0;
                orderDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, Identification = i.Cart_key_id, i.Login_obj_cus.Username });
            }
        }

        private void LoadTableDel()
        {
            LoginsModel om = new LoginsModel();

            table2 = om.getDel();

            if (table2 == null) { }

            else
            {
                int Sl = 0;
                deliveryDG.ItemsSource = table2.Select(i => new { Sl = table2.IndexOf(i) + 1, Username = i.Username });
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
                txt += "\n________________________________________________________________";
                txt += "\nMedicine";
                txt += "  Quantity";
                txt += "  Net Price";
                double price = 0.0;
                //foreach (Cart med in loaded_order.Items)
                for(int i = 0; i< loaded_order.Items.Count(); i++)
                {
                    price += loaded_order.Items[i].Total_Price;
                    txt += "\n" + loaded_order.Items[i].Medicine_obj.Name + "\t" + loaded_order.Items[i].Quantity_Ordered + "\t"+ loaded_order.Items[i].Total_Price;
                }
                txt += "\n\nTo be paid: " + price;

                detailsTB.Text = txt;

                deliveryDG.IsEnabled = true;

                acceptBtn.Visibility = Visibility.Visible;
                rejectBtn.Visibility = Visibility.Visible;

                LoadTableDel();
                
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
                var currentRowIndex = deliveryDG.Items.IndexOf(deliveryDG.CurrentItem);

                loaded_del = table2[currentRowIndex];

                delTB.Text = loaded_del.Username;

                acceptBtn.IsEnabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = null;
            order = loaded_order;
            order.Order_status = 2;
            order.Delivery_man = loaded_del.ID;

            OrdersModel om = new OrdersModel();
            bool result = om.UpdateOrderStatus(order);

            if(result)
            {
                MessageBox.Show("Order Accepted.");
                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }

        }

        private void rejectBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = null;
            order = loaded_order;
            order.Order_status = 5;

            OrdersModel om = new OrdersModel();
            bool result = om.UpdateOrderStatus(order);

            if (result)
            {
                MedicinesModel mm = new MedicinesModel();
                int quant = 0;
                //foreach (Cart med in loaded_order.Items)
                for (int i = 0; i < loaded_order.Items.Count(); i++)
                {
                    quant = loaded_order.Items[i].Quantity_Ordered+ loaded_order.Items[i].Medicine_obj.Quantity;
                    mm.updateMedicineQuant(loaded_order.Items[i].Medicine_id, quant);
                    quant = 0;
                   
                }

                MessageBox.Show("Order Cancelled.");

                refreshBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Something Went Wrong.");
            }
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            delTB.Text = "";
            detailsTB.Text = "";

            deliveryDG.IsEnabled = false;
            acceptBtn.IsEnabled = false;

            acceptBtn.Visibility = Visibility.Hidden;
            rejectBtn.Visibility = Visibility.Hidden;

            loaded_order = null;
            loaded_del = null;

            deliveryDG.ItemsSource = null;

            LoadTablePendingOrders();
        }
    }
}
