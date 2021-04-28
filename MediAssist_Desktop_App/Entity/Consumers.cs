using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Consumers
    {
        int id;
        string name;
        string occupation;
        string blood_group;
        string phone;
        int login_id;

        Login login_obj;

        public Consumers() { }

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

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
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
