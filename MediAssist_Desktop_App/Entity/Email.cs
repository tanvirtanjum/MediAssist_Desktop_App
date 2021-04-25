using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Email
    {
        int id;
        string mail;

        public Email() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
    }
}
