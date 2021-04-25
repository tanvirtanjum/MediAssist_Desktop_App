using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    class Reg_StatusModel
    {
		DBC db = new DBC();

		public Reg_status getInfo(int id)
		{
			Reg_status info = null;

			string query = "SELECT * FROM reg_status WHERE id = " + id + ";";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Reg_status();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Status = dr.GetString(1);
			}
			db.closeConnection();

			return info;
		}
	}
}
