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

namespace MediAssist_Desktop_App.Views.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorDash.xaml
    /// </summary>
    public partial class DoctorDash : Window
    {
        Login session = null;
        public DoctorDash(Login user)
        {
            session = user;

            InitializeComponent();
        }
    }
}
