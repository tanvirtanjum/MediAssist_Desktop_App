using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class OrdersModel
    {
		DBC db = new DBC();

		public List<Order> getPendings()
		{
			List<Order> table = new List<Order>();

			string query = "SELECT * FROM orders WHERE order_status = '1';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Order order = new Order();

					order.ID = dr.GetInt32(0);
					order.Cart_key_id = dr.GetInt32(1);
					order.Order_status = dr.GetInt32(2);
					order.Delivery_man = dr.GetInt32(3);
					order.Order_by = dr.GetInt32(4);


					LoginsModel lm = new LoginsModel();
					Order_statusModel osm = new Order_statusModel();
					CartsModel cm = new CartsModel();

					order.Login_obj_emp = lm.getInfoOnOpenConnection(order.Delivery_man);
					order.Login_obj_cus = lm.getInfoOnOpenConnection(order.Order_by);

					order.Order_status_obj = osm.getInfoOnOpenConnection(order.Order_status);

					order.Items = cm.getCartsForOrder(order.Cart_key_id);

					table.Add(order);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public List<Order> getOrders()
		{
			List<Order> table = new List<Order>();

			string query = "SELECT * FROM orders WHERE order_status != '1' ORDER BY order_status;";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Order order = new Order();

					order.ID = dr.GetInt32(0);
					order.Cart_key_id = dr.GetInt32(1);
					order.Order_status = dr.GetInt32(2);
					order.Delivery_man = dr.GetInt32(3);
					order.Order_by = dr.GetInt32(4);


					LoginsModel lm = new LoginsModel();
					Order_statusModel osm = new Order_statusModel();
					CartsModel cm = new CartsModel();

					order.Login_obj_emp = lm.getInfoOnOpenConnection(order.Delivery_man);
					order.Login_obj_cus = lm.getInfoOnOpenConnection(order.Order_by);

					order.Order_status_obj = osm.getInfoOnOpenConnection(order.Order_status);

					order.Items = cm.getCartsForOrder(order.Cart_key_id);

					table.Add(order);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public bool UpdateOrderStatus(Order order)
		{
			string query = "UPDATE orders SET order_status = '" + order.Order_status + "', delivery_man = '" + order.Delivery_man + "' WHERE id = '" + order.ID + "';";

			try
			{
				db.openConnection();
				db.executeQuery(query);
				db.closeConnection();

				return true;
			}

			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
