using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Medicine_Type
    {
        int id;
        string name;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string TypeName
        {
            get { return name; }
            set { name = value; }
        }
    }
}
