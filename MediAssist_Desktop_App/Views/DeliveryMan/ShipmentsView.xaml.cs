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
    /// Interaction logic for ShipmentsView.xaml
    /// </summary>
    public partial class ShipmentsView : Window
    {
        Login session;

        List<Order> table = null;

        Order loaded_order = null;
        public ShipmentsView(Login user)
        {
            InitializeComponent();

            session = user;

            sortCB.Items.Add("ALL ORDERS");
            sortCB.Items.Add("SHIPPED ORDERS");
            sortCB.Items.Add("RECEIVED ORDERS");
            sortCB.Items.Add("RETURNED ORDERS");
            sortCB.Items.Add("CANCELED ORDERS");
            sortCB.SelectedIndex = 0;

            LoadTableOrders();
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
            DeliveryManDash dmd = new DeliveryManDash(session);
            dmd.Show();
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

        private void ShipmentsBtn_Click(object sender, RoutedEventArgs e)
        {
            //ShipmentsView sv = new ShipmentsView(session);
            //sv.Show();
            //this.Close();
        }

        //End
        /*ROUTES -- DeliveryMan*/

        private void LoadTableOrders()
        {
            OrdersModel om = new OrdersModel();

            table = om.getOrdersForDeliveryMan(session.ID, sortCB.SelectedIndex+1);

            if (table == null) { }

            else
            {
                int Sl = 0;
                orderDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, Identification = i.Cart_key_id, Consumer = i.Login_obj_cus.Username, Status = i.Order_status_obj.Stat });
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
                txt += "\nDelivery Status: " + loaded_order.Order_status_obj.Stat;
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

                refreshBtn.Visibility = Visibility.Visible;
                deliveredBtn.Visibility = Visibility.Visible;
                returnedBtn.Visibility = Visibility.Visible;

                if (loaded_order.Order_status == 2)
                {
                    deliveredBtn.IsEnabled = true;
                    returnedBtn.IsEnabled = true;
                }
                else
                {
                    deliveredBtn.IsEnabled = false;
                    returnedBtn.IsEnabled = false;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTableOrders();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            loaded_order = null;

            refreshBtn.Visibility = Visibility.Hidden;
            deliveredBtn.Visibility = Visibility.Hidden;
            returnedBtn.Visibility = Visibility.Hidden;

            detailsTB.Text = "";

            deliveredBtn.IsEnabled = true;
            returnedBtn.IsEnabled = true;

            LoadTableOrders();
        }

        private void deliveredBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loaded_order == null)
            {
                MessageBox.Show("No Order Loaded.");
            }
            else
            {
                Order order = new Order();
                order = loaded_order;
                order.Order_status = 3;

                OrdersModel om = new OrdersModel();
                bool result = om.UpdateOrderStatus(order);

                if(result)
                {
                    MessageBox.Show("Order Recieved.");
                    refreshBtn_Click(sender, e);
                }
            }
        }

        private void returnedBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = null;
            order = loaded_order;
            order.Order_status = 4;

            OrdersModel om = new OrdersModel();
            bool result = om.UpdateOrderStatus(order);

            if (result)
            {
                MedicinesModel mm = new MedicinesModel();
                int quant = 0;
                //foreach (Cart med in loaded_order.Items)
                for (int i = 0; i < loaded_order.Items.Count(); i++)
                {
                    quant = loaded_order.Items[i].Quantity_Ordered + loaded_order.Items[i].Medicine_obj.Quantity;
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
    }
}
