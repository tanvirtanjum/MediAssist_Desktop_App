using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Access
    {
        int id;
        string approval;

        public Access() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Approval
        {
            get { return approval; }
            set { approval = value; }
        }
    }
}
