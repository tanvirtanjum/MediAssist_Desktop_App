using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Medicine
    {
        int id;
        string name;
        string distributer;
        int type;
        double price;
        int quantity;
        int availability;

        Medicine_Type type_obj;
        Availability availability_obj;

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

        public string Distributer
        {
            get { return distributer; }
            set { distributer = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public Medicine_Type Type_obj
        {
            get { return type_obj; }
            set { type_obj = value; }
        }

        public Availability Availability_obj
        {
            get { return availability_obj; }
            set { availability_obj = value; }
        }
    }
}
