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


namespace MediAssist_Desktop_App.Views.Doctor
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        Login session = null;

        List<Note> table = null;

        Note loaded_note = null;
        public NotesWindow(Login user)
        {
            InitializeComponent();

            session = user;

            LoadTable();
        }

        private void LoadTable()
        {
            NotesModel nm = new NotesModel();

            table = nm.getTable(session.ID);

            if(table == null){}

            else
            {
                int Sl = 0;
                notesDG.ItemsSource = table.Select(i => new { Sl = table.IndexOf(i)+1, i.ID, i.Subject });
            }          
        }

        private void load_data(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var currentRowIndex = notesDG.Items.IndexOf(notesDG.CurrentItem);

                loaded_note = table[currentRowIndex];

                subjectTB.Text = loaded_note.Subject;
                textTA.Text = loaded_note.Text;


                addBtn.Visibility = Visibility.Hidden;

                updateBtn.Visibility = Visibility.Visible;
                printBtn.Visibility = Visibility.Visible;
                deleteBtn.Visibility = Visibility.Visible;
                refreshBtn.Visibility = Visibility.Visible;
            }

            catch (Exception ex)
            {
                MessageBox.Show("NO DATA.");
            }
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutUser au = new AboutUser(session);
            au.Show();
            this.Close();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DoctorDash dd = new DoctorDash(session);
            dd.Show();
            this.Close();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            session = null;
            LoginView lv = new LoginView();
            lv.Show();
            this.Close();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            addBtn.Visibility = Visibility.Visible;

            updateBtn.Visibility = Visibility.Hidden;
            printBtn.Visibility = Visibility.Hidden;
            deleteBtn.Visibility = Visibility.Hidden;
            refreshBtn.Visibility = Visibility.Hidden;

            loaded_note = null;

            subjectTB.Text = "";
            textTA.Text = "";

            LoadTable();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string subject = subjectTB.Text;
            string text = textTA.Text;

            bool validation = true;

            string msg = "Requied: ";

            if (subject.Trim().Length < 1)
            {
                validation = false;
                msg += "\nSubject.";
            }

            if (text.Trim().Length < 1)
            {
                validation = false;
                msg += "\nText.";
            }

            if (!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Note noteUpdate = new Note();
                noteUpdate.ID = loaded_note.ID;
                noteUpdate.Subject = subject;
                noteUpdate.Text = text;
                noteUpdate.Owner_id = session.ID;

                NotesModel nm = new NotesModel();

                bool update = nm.UpdateNote(noteUpdate);

                if (update)
                {
                    MessageBox.Show("Note Updated.");
                    LoadTable();
                    refreshBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Something Went Wrong.");
                    LoadTable();
                }
            }

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Note noteDelete = loaded_note;

            NotesModel nm = new NotesModel();

            bool delete = nm.DeleteNote(noteDelete);

            if (delete)
            {
                MessageBox.Show("Note Deleted.");
                LoadTable();
                refreshBtn_Click(sender, e);
            }

            else
            {
                MessageBox.Show("Something Went Wrong.");
                LoadTable();
            }
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveToTxt s2t = new SaveToTxt();
            s2t.SaveNote(loaded_note);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string subject = subjectTB.Text;
            string text = textTA.Text;

            bool validation = true;

            string msg = "Requied: ";

            if(subject.Trim().Length <1)
            {
                validation = false;
                msg += "\nSubject.";
            }

            if (text.Trim().Length < 1)
            {
                validation = false;
                msg += "\nText.";
            }

            if(!validation)
            {
                MessageBox.Show(msg);
            }

            else
            {
                Note noteInsert = new Note();
                noteInsert.Subject = subject;
                noteInsert.Text = text;
                noteInsert.Owner_id = session.ID;

                NotesModel nm = new NotesModel();

                bool insert = nm.AddNote(noteInsert);

                if(insert)
                {
                    MessageBox.Show("New Note Added.");
                    LoadTable();
                    refreshBtn_Click(sender, e);
                }

                else
                {
                    MessageBox.Show("Something Went Wrong.");
                    LoadTable();
                }
            }

        }
    }
}
