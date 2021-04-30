using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Order
    {
        int id;
        int cart_key;
        int order_status;
        int delivery_man;
        int order_by;

        List<Cart> items;
        Login login_obj_emp;
        Login login_obj_cus;
        Order_status order_status_obj;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Cart_key_id
        {
            get { return cart_key; }
            set { cart_key = value; }
        }

        public int Order_status
        {
            get { return order_status; }
            set { order_status = value; }
        }

        public int Delivery_man
        {
            get { return delivery_man; }
            set { delivery_man = value; }
        }

        public int Order_by
        {
            get { return order_by; }
            set { order_by = value; }
        }

        public List<Cart> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Login Login_obj_emp
        {
            get { return login_obj_emp; }
            set { login_obj_emp = value; }
        }

        public Login Login_obj_cus
        {
            get { return login_obj_cus; }
            set { login_obj_cus = value; }
        }

        public Order_status Order_status_obj
        {
            get { return order_status_obj; }
            set { order_status_obj = value; }
        }
    }
}
