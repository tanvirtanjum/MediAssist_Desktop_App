using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class EmailsModel
    {
		DBC db = new DBC();

		public Email getInfo(int id)
		{
			Email info = null;

			string query = "SELECT * FROM emails WHERE id = " + id + ";";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				info = new Email();
				dr.Read();

				info.ID = dr.GetInt32(0);
				info.Mail = dr.GetString(1);
			}
			db.closeConnection();

			return info;
		}
	}
}
