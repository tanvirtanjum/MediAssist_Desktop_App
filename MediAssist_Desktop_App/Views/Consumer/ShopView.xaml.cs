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
using MediAssist_Desktop_App.Sealed_Class;

namespace MediAssist_Desktop_App.Views.Consumer
{
    /// <summary>
    /// Interaction logic for ShopView.xaml
    /// </summary>
    public partial class ShopView : Window
    {
        Login session;

        List<Medicine> table = null;

        List<Cart> table2 = null;

        List<Cart> order = null;

        Medicine loaded_medicine = null;

        Cart loaded_cart = null;
        public ShopView(Login user)
        {
            InitializeComponent();

            session = user;

            sortCB.Items.Add("---All Medicines---");
            sortCB.Items.Add("TABLET");
            sortCB.Items.Add("CAPSULE");
            sortCB.Items.Add("LIQUID");
            sortCB.Items.Add("OINTMENT");
            sortCB.Items.Add("OTHER");
            sortCB.SelectedIndex = 0;

            LoadTableMed();
            LoadTableCart();
            LoadDetailCart();
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
            //ShopView sv = new ShopView(session);
            //sv.Show();
            //this.Close();
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

        private void LoadTableMed()
        {
            MedicinesModel mm = new MedicinesModel();

            table = mm.getTableByType(sortCB.SelectedIndex);

            if (table == null) { MessageBox.Show("....!"); }

            else
            {
                medicinesDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, i.Name, i.Distributer, i.Availability_obj.Status, i.Price, i.Quantity });

            }
        }

        private void LoadTableCart()
        {
            CartsModel cm = new CartsModel();

            table2 = cm.getCarts(session.Cart_id);

            if (table2 == null) { MessageBox.Show("....!"); }

            else
            {
                cartDG.ItemsSource = table2.Select(j => new { Sl = table2.IndexOf(j) + 1, j.Medicine_obj.Name, j.Quantity_Ordered, j.Total_Price});

            }
        }

        private void LoadDetailCart()
        {
            CartsModel cm = new CartsModel();

            order = cm.getCarts(session.Cart_id);

            if (order == null || order.Count < 1) 
            { 
                detailsTB.Text = "";
                checkoutBtn.IsEnabled = false;
            }

            else
            {
                checkoutBtn.IsEnabled = true ;

                string txt = "";
                txt += "Identification Code: " + order[0].Cart_key;
                txt += "\nOrdered By: " + order[0].Login_obj.Username;
                txt += "\n___________________________________________________________";
                txt += "\nMedicine";
                txt += "  Quantity";
                txt += "  Net Price";
                double price = 0.0;
                //foreach (Cart med in loaded_order.Items)
                for (int i = 0; i < order.Count(); i++)
                {
                    price += order[i].Total_Price;
                    txt += "\n" + order[i].Medicine_obj.Name + "\t" + order[i].Quantity_Ordered + "\t" + order[i].Total_Price;
                }
                txt += "\n\nTo be paid: " + price;

                detailsTB.Text = txt;
            }
        }

        private void load_data_med(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = medicinesDG.Items.IndexOf(medicinesDG.SelectedItem);

                loaded_medicine = table[currentRowIndex];

                if (loaded_medicine != null)
                {
                    nameTB.Text = loaded_medicine.Name;
                    aqTB.Text = loaded_medicine.Quantity.ToString();

                    if(loaded_medicine.Quantity < 1 || loaded_medicine.Availability != 1)
                    {
                        addcartBtn.IsEnabled = false;
                    }
                    else
                    {
                        addcartBtn.IsEnabled = true;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
                refreshacBtn_Click(sender, e);
            }
        }

        private void load_data_cart(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = cartDG.Items.IndexOf(cartDG.SelectedItem);

                loaded_cart = table2[currentRowIndex];

                if (loaded_cart != null)
                {
                    crtnameTB.Text = loaded_cart.Medicine_obj.Name;
                    crtaqTB.Text = loaded_cart.Quantity_Ordered.ToString();
                    priceTB.Text = loaded_cart.Total_Price.ToString();

                    removecBtn.IsEnabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
                refreshacBtn_Click(sender, e);
            }
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTableMed();
        }

        private void refreshacBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTB.Text = "";
            aqTB.Text = "";
            bqTB.Text = "";

            addcartBtn.IsEnabled = false;

            loaded_medicine = null;

            LoadTableMed();
            LoadTableCart();
            LoadDetailCart();
        }

        private void addcartBtn_Click(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();

            string bq = bqTB.Text.Trim();
            int quant;
            bool isInt = Int32.TryParse(bq, out quant);

            if(loaded_medicine == null)
            {
                MessageBox.Show("No Medicine To Cart.");

            }

            else 
            {
                if(!isInt)
                {
                    MessageBox.Show("Invalid Quantity to add.");
                }
                else
                {
                    bool validation = true;
                    if(quant < 1)
                    {
                        validation = false;
                        MessageBox.Show("Minimum purchase Quantity = 1");
                    }

                    if(quant > loaded_medicine.Quantity)
                    {
                        validation = false;
                        MessageBox.Show("Quantity Not Available");
                    }

                    if(validation)
                    {
                        cart.Cart_key = session.Cart_id;
                        cart.Medicine_id = loaded_medicine.ID;
                        cart.Quantity_Ordered = quant;
                        cart.Total_Price = loaded_medicine.Price * quant;
                        cart.Cart_by = session.ID;
                        cart.Medicine_obj = loaded_medicine;

                        CartsModel cm = new CartsModel();

                        bool result = cm.addCart(cart);

                        if(result)
                        {
                            MessageBox.Show("Product Added to Cart");
                            refreshacBtn_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong");
                        }
                    }

                }
            }

        }

        private void refreshcBtn_Click(object sender, RoutedEventArgs e)
        {
            crtnameTB.Text = "";
            crtaqTB.Text = "";
            priceTB.Text = "";

            removecBtn.IsEnabled = false;

            loaded_cart = null;

            LoadTableCart();
            LoadTableMed();
            LoadDetailCart();
        }

        private void removecBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loaded_cart == null)
            {
                MessageBox.Show("No item selected to remove.");
            }
            else
            {
                CartsModel cm = new CartsModel();

                bool result = cm.removeFromCart(loaded_cart);

                if(result)
                {
                    MessageBox.Show("Item Removed.");
                    refreshcBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something Went Wrong");
                }
            }
        }

        private void checkoutBtn_Click(object sender, RoutedEventArgs e)
        {
            TokenGenerator tg = new TokenGenerator();
            //session.Cart_id = tg.token(session.ID);

            if(order != null || order.Count != 0)
            {
                Order orderToPut = new Order();
                orderToPut.Cart_key_id = session.Cart_id;
                orderToPut.Order_status = 1;
                orderToPut.Delivery_man = session.ID;
                orderToPut.Order_by = session.ID;

                OrdersModel om = new OrdersModel();
                bool result = om.addOrder(orderToPut);

                if(result)
                {
                    MessageBox.Show("Order Placed.");

                    session.Cart_id = tg.token(session.ID);

                    refreshacBtn_Click(sender, e);
                    refreshcBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something went wrong.");
                }
            }
        }
    }
}
