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
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : Window
    {
        Login session;

        List<Order> table = null;

        Order loaded_order = null;
        public HistoryView(Login user)
        {
            InitializeComponent();

            session = user;

            sortCB.Items.Add("ALL ORDERS");
            sortCB.Items.Add("PENDING ORDERS");
            sortCB.Items.Add("SHIPPED ORDERS");
            sortCB.Items.Add("RECEIVED ORDERS");
            sortCB.Items.Add("RETURNED ORDERS");
            sortCB.Items.Add("CANCELED ORDERS");
            sortCB.SelectedIndex = 0;

            LoadTableOrders();
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
            //HistoryView hv = new HistoryView(session);
            //hv.Show();
            //this.Close();
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
        private void LoadTableOrders()
        {
            OrdersModel om = new OrdersModel();

            table = om.getOrdersForConsumer(session.ID, sortCB.SelectedIndex);

            if (table == null) { }

            else
            {
                int Sl = 0;
                orderDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, Identification = i.Cart_key_id, i.Login_obj_cus.Username, Status = i.Order_status_obj.Stat });
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

                refreshBtn.Visibility = Visibility.Visible;
                cancelBtn.Visibility = Visibility.Visible;
                
                if(loaded_order.Order_status == 1)
                {
                    cancelBtn.IsEnabled = true;
                }
                else
                {
                    cancelBtn.IsEnabled = false;
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
            refreshBtn.Visibility = Visibility.Hidden;
            cancelBtn.Visibility = Visibility.Hidden;
            cancelBtn.IsEnabled = false;
            detailsTB.Text = "";
            loaded_order = null;

            LoadTableOrders();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
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
