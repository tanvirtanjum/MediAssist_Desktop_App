using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class AccessModel
    {
		DBC db = new DBC();

		public Access getInfo(int id)
		{
			Access info = null;

			string query = "SELECT * FROM access WHERE id = " + id + ";";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Access();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Approval = dr.GetString(1);
			}
			db.closeConnection();

			return info;
		}

		public Access getInfoOnOpenConnection(int id)
		{
			Access info = null;

			string query = "SELECT * FROM access WHERE id = " + id + ";";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Access();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Approval = dr.GetString(1);
			}
			//db.closeConnection();

			return info;
		}
	}
}
