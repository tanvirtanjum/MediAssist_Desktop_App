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

		public Email checkEmail(string email)
		{
			Email info = null;

			string query = "SELECT * FROM emails WHERE mail LIKE '" + email + "';";

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

		public bool updateEmail(Employee employee)
		{
			Email has = this.checkEmail(employee.Login_obj.Email_obj.Mail.ToString());


			string query = "UPDATE emails SET mail = '" + employee.Login_obj.Email_obj.Mail.ToString() + "' WHERE id='" + employee.Login_obj.Email_obj.ID + "';";

			if (has == null)
			{
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

			else
			{
				return false;
			}


		}
	}
}
