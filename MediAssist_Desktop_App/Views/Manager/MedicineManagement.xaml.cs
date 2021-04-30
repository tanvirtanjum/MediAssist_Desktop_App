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

        List<Medicine> table = null;

        Medicine loaded_medicine = null;
        public MedicineManagement(Login user)
        {
            InitializeComponent();

            session = user;

            typeCB.Items.Add("---SELECT---");
            typeCB.Items.Add("TABLET");
            typeCB.Items.Add("CAPSULE");
            typeCB.Items.Add("LIQUID");
            typeCB.Items.Add("OINTMENT");
            typeCB.Items.Add("OTHER");
            typeCB.SelectedIndex = 0;

            availCB.Items.Add("---SELECT---");
            availCB.Items.Add("AVAILABLE");
            availCB.Items.Add("STOCK OUT");
            availCB.Items.Add("NOT FOR SALE");
            availCB.SelectedIndex = 0;

            sortCB.Items.Add("ALL MEDICINES");
            sortCB.Items.Add("AVAILABLE");
            sortCB.Items.Add("STOCK OUT");
            sortCB.Items.Add("NOT FOR SALE");
            sortCB.SelectedIndex = 0;

            LoadTable(sortCB.SelectedIndex);
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

        private void LoadTable(int id)
        {
            MedicinesModel mm = new MedicinesModel();

            table = mm.getTable(id);

            if (table == null) { MessageBox.Show("....!"); }

            else
            {
                medicinesDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i) + 1, i.Name, i.Distributer, Type = i.Type_obj.TypeName, i.Availability_obj.Status, i.Price });

            }
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = medicinesDG.Items.IndexOf(medicinesDG.SelectedItem);

                loaded_medicine = table[currentRowIndex];

                if (loaded_medicine != null)
                {
                    nameTB.Text = loaded_medicine.Name;
                    disTB.Text = loaded_medicine.Distributer;
                    typeCB.SelectedItem = loaded_medicine.Type_obj.TypeName;
                    priceTB.Text = loaded_medicine.Price.ToString();
                    quanTB.Text = loaded_medicine.Quantity.ToString();
                    availCB.SelectedItem = loaded_medicine.Availability_obj.Status;

                    updateBtn.Visibility = Visibility.Visible;
                    refreshBtn.Visibility = Visibility.Visible;

                    addBtn.Visibility = Visibility.Hidden;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
                refreshBtn_Click(sender, e);
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTB.Text;
            string dis = disTB.Text;
            int type = typeCB.SelectedIndex;
            string priceText = priceTB.Text.Trim();
            double price;
            bool isDouble = Double.TryParse(priceText, out price);
            string quantText = quanTB.Text.Trim();
            int quant;
            bool isInt = Int32.TryParse(quantText, out quant);
            int avail = availCB.SelectedIndex;

            bool validation = true;
            string msg = "Errors:";

            if (name.Trim().Length < 1)
            {
                validation = false;
                msg += "\nName Required.";
            }

            if (dis.Trim().Length < 1)
            {
                validation = false;
                msg += "\nDistributor Required.";
            }

            if (type < 1)
            {
                validation = false;
                msg += "\nType Required.";
            }

            if (!isDouble || price < 0.1)
            {
                validation = false;
                msg += "\nValid Price Required.";
            }

            if (!isInt || quant < 1)
            {
                validation = false;
                msg += "\nValid Quantity Required.";
            }

            if (avail < 1)
            {
                validation = false;
                msg += "\nValid Availability Required.";
            }

            if (!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Medicine medUpdate = new Medicine();

                medUpdate.ID = loaded_medicine.ID;
                medUpdate.Name = name;
                medUpdate.Distributer = dis;
                medUpdate.Type = type;
                medUpdate.Price = price;
                medUpdate.Quantity = quant;
                medUpdate.Availability = avail;

                MedicinesModel mm = new MedicinesModel();

                bool result = mm.updateMedicine(medUpdate);

                if (result)
                {
                    MessageBox.Show("Medicine Updated.");
                    refreshBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something Went Wrong.");
                }
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTB.Text;
            string dis = disTB.Text;
            int type = typeCB.SelectedIndex;
            string priceText = priceTB.Text.Trim();
            double price;
            bool isDouble = Double.TryParse(priceText, out price);
            string quantText = quanTB.Text.Trim();
            int quant;
            bool isInt = Int32.TryParse(quantText, out quant);
            int avail = availCB.SelectedIndex;

            bool validation = true;
            string msg = "Errors:";

            if(name.Trim().Length < 1)
            {
                validation = false;
                msg += "\nName Required.";
            }

            if (dis.Trim().Length < 1)
            {
                validation = false;
                msg += "\nDistributor Required.";
            }

            if(type < 1)
            {
                validation = false;
                msg += "\nType Required.";
            }

            if(!isDouble || price < 0.1)
            {
                validation = false;
                msg += "\nValid Price Required.";
            }

            if (!isInt || quant < 1)
            {
                validation = false;
                msg += "\nValid Quantity Required.";
            }

            if(avail < 1)
            {
                validation = false;
                msg += "\nValid Availability Required.";
            }

            if(!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Medicine medInsert = new Medicine();
                medInsert.Name = name;
                medInsert.Distributer = dis;
                medInsert.Type = type;
                medInsert.Price = price;
                medInsert.Quantity = quant;
                medInsert.Availability = avail;

                MedicinesModel mm = new MedicinesModel();

                bool result = mm.insertMedicine(medInsert);

                if(result)
                {
                    MessageBox.Show("Medicine Added.");
                    refreshBtn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Something Went Wrong.");
                }
            }
        }


        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTB.Text = "";
            disTB.Text = "";
            typeCB.SelectedIndex = 0;
            priceTB.Text = "";
            quanTB.Text = "";
            availCB.SelectedIndex = 0;

            updateBtn.Visibility = Visibility.Hidden;
            refreshBtn.Visibility = Visibility.Hidden;

            addBtn.Visibility = Visibility.Visible;

            LoadTable(sortCB.SelectedIndex);
        }

        private void sortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTable(sortCB.SelectedIndex);
        }
    }
}
