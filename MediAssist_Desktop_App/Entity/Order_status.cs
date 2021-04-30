using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Order_status
    {
        int id;
        string status;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Stat
        {
            get { return status; }
            set { status = value; }
        }
    }
}
