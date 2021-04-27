using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
	class RolesModel
	{
		DBC db = new DBC();

		public Role getInfo(int id)
		{
			Role info = null;

			string query = "SELECT * FROM roles WHERE id = " + id + ";";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Role();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Designation = dr.GetString(1);
			}
			db.closeConnection();

			return info;
		}

		public Role getInfoOnOpenConnection(int id)
		{
			Role info = null;

			string query = "SELECT * FROM roles WHERE id = " + id + ";";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Role();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Designation = dr.GetString(1);
			}
			//db.closeConnection();

			return info;
		}
	}
}
