using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Report
    {
        int id;
        string report_txt;
        int prescribe_by;
        int prescribe_for;

        Login login_obj_doc;
        Login login_obj_cus;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Report_txt
        {
            get { return report_txt; }
            set { report_txt = value; }
        }

        public int Prescribe_by
        {
            get { return prescribe_by; }
            set { prescribe_by = value; }
        }

        public int Prescribe_for
        {
            get { return prescribe_for; }
            set { prescribe_for = value; }
        }

        public Login Login_obj_doc
        {
            get { return login_obj_doc; }
            set { login_obj_doc = value; }
        }

        public Login Login_obj_cus
        {
            get { return login_obj_cus; }
            set { login_obj_cus = value; }
        }
    }
}
