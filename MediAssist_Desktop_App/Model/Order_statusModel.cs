using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class Order_statusModel
    {
		DBC db = new DBC();

		public Order_status getInfo(int id)
		{
			Order_status info = null;

			string query = "SELECT * FROM order_status WHERE id = " + id + ";";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Order_status();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Stat = dr.GetString(1);
			}
			db.closeConnection();

			return info;
		}

		public Order_status getInfoOnOpenConnection(int id)
		{
			Order_status info = null;

			string query = "SELECT * FROM order_status WHERE id = " + id + ";";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Order_status();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Stat = dr.GetString(1);
			}
			//db.closeConnection();

			return info;
		}
	}
}
