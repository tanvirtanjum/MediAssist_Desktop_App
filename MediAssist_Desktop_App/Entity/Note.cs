using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Note
    {
        int id;
        string subject;
        string text;
        int owner_id;

        Login owner_obj;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int Owner_id
        {
            get { return owner_id; }
            set { owner_id = value; }
        }

        public Login Owner_obj
        {
            get { return owner_obj; }
            set { owner_obj = value; }
        }
    }
}
