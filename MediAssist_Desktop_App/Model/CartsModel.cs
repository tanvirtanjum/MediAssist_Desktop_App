using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class CartsModel
    {
        DBC db = new DBC();

		public List<Cart> getCartsForOrder(int cart_key)
		{
			List<Cart> table = new List<Cart>();

			string query = "SELECT * FROM carts WHERE cart_key = '"+ cart_key + "';";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Cart cart = new Cart();

					cart.ID = dr.GetInt32(0);
					cart.Cart_key = dr.GetInt32(1);
					cart.Medicine_id = dr.GetInt32(2);
					cart.Quantity_Ordered = dr.GetInt32(3);
					cart.Total_Price = dr.GetDouble(4);
					cart.Cart_by = dr.GetInt32(5);

					LoginsModel lm = new LoginsModel();
					MedicinesModel mm = new MedicinesModel();

					cart.Login_obj = lm.getInfoOnOpenConnection(cart.Cart_by);
					cart.Medicine_obj = mm.getInfoOnOpenConnection(cart.Medicine_id);

					table.Add(cart);
				}
			}

			else
			{
				//db.closeConnection();
			}

			//db.closeConnection();

			return table;
		}

		public List<Cart> getCarts(int cart_key)
		{
			List<Cart> table = new List<Cart>();

			string query = "SELECT * FROM carts WHERE cart_key = '" + cart_key + "';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Cart cart = new Cart();

					cart.ID = dr.GetInt32(0);
					cart.Cart_key = dr.GetInt32(1);
					cart.Medicine_id = dr.GetInt32(2);
					cart.Quantity_Ordered = dr.GetInt32(3);
					cart.Total_Price = dr.GetDouble(4);
					cart.Cart_by = dr.GetInt32(5);

					LoginsModel lm = new LoginsModel();
					MedicinesModel mm = new MedicinesModel();

					cart.Login_obj = lm.getInfoOnOpenConnection(cart.Cart_by);
					cart.Medicine_obj = mm.getInfoOnOpenConnection(cart.Medicine_id);

					table.Add(cart);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public bool addCart(Cart cart)
		{
			

			string query = "INSERT INTO carts VALUES('" + cart.Cart_key + "', '" + cart.Medicine_id + "', '" + cart.Quantity_Ordered + "', '" + cart.Total_Price + "', '" + cart.Cart_by + "');";

			try
			{
				db.openConnection();
				db.executeQuery(query);
				db.closeConnection();

				MedicinesModel mm = new MedicinesModel();

				mm.updateMedicineQuant(cart.Medicine_id, cart.Medicine_obj.Quantity - cart.Quantity_Ordered);

				return true;
			}

			catch (Exception ex)
			{
				return false;
			}
		}

		public bool removeFromCart(Cart cart)
		{

			string query = "DELETE FROM carts WHERE id = '" + cart.ID + "';";

			try
			{
				db.openConnection();
				db.executeQuery(query);
				db.closeConnection();

				MedicinesModel mm = new MedicinesModel();

				mm.updateMedicineQuant(cart.Medicine_id, cart.Medicine_obj.Quantity + cart.Quantity_Ordered);


				return true;
			}

			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
