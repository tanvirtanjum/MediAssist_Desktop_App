using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Feedback
    {
        int id;
        string feedback_text;
        int login_id;

        Login login_obj;
        public Feedback() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Feedback_text
        {
            get { return feedback_text; }
            set { feedback_text = value; }
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
