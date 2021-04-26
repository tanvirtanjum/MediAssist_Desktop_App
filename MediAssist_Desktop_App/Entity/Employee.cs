using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Employee
    {
        int id;
        string name;
        double salary;
        string blood_group;
        string phone;
        int login_id;

        Login login_obj;

        public Employee() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Blood_group
        {
            get { return blood_group; }
            set { blood_group = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public int Login_id
        {
            get { return login_id; }
            set { login_id = value; }
        }

        public Login Login_obj
        {
            get { return login_obj; }
            set { login_obj = value; }
        }
    }
}
