using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Role
    {
        int id;
        string designation;

        public Role() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
    }
}
