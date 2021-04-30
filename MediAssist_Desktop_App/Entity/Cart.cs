using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Cart
    {
        int id;
        int cart_key;
        int medicine_id;
        int quantity;
        double total_price;
        int cart_by;

        Medicine medicine_obj;
        Login login_obj;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Cart_key
        {
            get { return cart_key; }
            set { cart_key = value; }
        }

        public int Medicine_id
        {
            get { return medicine_id; }
            set { medicine_id = value; }
        }

        public int Quantity_Ordered
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Total_Price
        {
            get { return total_price; }
            set { total_price = value; }
        }

        public int Cart_by
        {
            get { return cart_by; }
            set { cart_by = value; }
        }

        public Medicine Medicine_obj
        {
            get { return medicine_obj; }
            set { medicine_obj = value; }
        }

        public Login Login_obj
        {
            get { return login_obj; }
            set { login_obj = value; }
        }
    }
}
