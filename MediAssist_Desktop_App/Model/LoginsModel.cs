using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class LoginsModel
    {
		DBC db = new DBC();

		public Login getUser(string username, string password)
        {
			Login user = null;

			string query = "SELECT * FROM logins WHERE username = '"+username+"' AND password = '"+ password +"';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				user = new Login();
				dr.Read();

				user.ID = dr.GetInt32(0);
				user.Username = dr.GetString(1);
				user.Password = dr.GetString(2);
				user.Role = dr.GetInt32(3);
				user.Access = dr.GetInt32(4);
				user.Reg_status = dr.GetInt32(5);
				user.Email_id = dr.GetInt32(6);
				db.closeConnection();

				AccessModel am = new AccessModel();
				RolesModel rm = new RolesModel();
				Reg_StatusModel rsm = new Reg_StatusModel();
				EmailsModel em = new EmailsModel();

				user.Access_obj = am.getInfo(Convert.ToInt32(user.Access));
				user.Role_obj = rm.getInfo(Convert.ToInt32(user.Role));
				user.Reg_Status_obj = rsm.getInfo(Convert.ToInt32(user.Reg_status));
				user.Email_obj = em.getInfo(Convert.ToInt32(user.Email_id));
			}
			else
            {
				db.closeConnection();
			}

			return user;
        }

		public Login getInfo(int id)
		{
			Login user = null;

			string query = "SELECT * FROM logins WHERE id = '" + id + "';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				user = new Login();
				dr.Read();

				user.ID = dr.GetInt32(0);
				user.Username = dr.GetString(1);
				user.Password = dr.GetString(2);
				user.Role = dr.GetInt32(3);
				user.Access = dr.GetInt32(4);
				user.Reg_status = dr.GetInt32(5);
				user.Email_id = dr.GetInt32(6);
				db.closeConnection();

				AccessModel am = new AccessModel();
				RolesModel rm = new RolesModel();
				Reg_StatusModel rsm = new Reg_StatusModel();
				EmailsModel em = new EmailsModel();

				user.Access_obj = am.getInfo(Convert.ToInt32(user.Access));
				user.Role_obj = rm.getInfo(Convert.ToInt32(user.Role));
				user.Reg_Status_obj = rsm.getInfo(Convert.ToInt32(user.Reg_status));
				user.Email_obj = em.getInfo(Convert.ToInt32(user.Email_id));
			}
			else
			{
				db.closeConnection();
			}

			return user;
		}

		public Login getInfoOnOpenConnection(int id)
		{
			Login user = null;

			string query = "SELECT * FROM logins WHERE id = '" + id + "';";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				user = new Login();
				dr.Read();

				user.ID = dr.GetInt32(0);
				user.Username = dr.GetString(1);
				user.Password = dr.GetString(2);
				user.Role = dr.GetInt32(3);
				user.Access = dr.GetInt32(4);
				user.Reg_status = dr.GetInt32(5);
				user.Email_id = dr.GetInt32(6);
				//db.closeConnection();

				AccessModel am = new AccessModel();
				RolesModel rm = new RolesModel();
				Reg_StatusModel rsm = new Reg_StatusModel();
				EmailsModel em = new EmailsModel();

				user.Access_obj = am.getInfoOnOpenConnection(Convert.ToInt32(user.Access));
				user.Role_obj = rm.getInfoOnOpenConnection(Convert.ToInt32(user.Role));
				user.Reg_Status_obj = rsm.getInfoOnOpenConnection(Convert.ToInt32(user.Reg_status));
				user.Email_obj = em.getInfoOnOpenConnection(Convert.ToInt32(user.Email_id));
			}
			else
			{
				//db.closeConnection();
			}

			return user;
		}

		public bool changePassword(string password, int id)
		{
			string query = "UPDATE logins SET password = '" + password + "' WHERE id='" + id + "';";

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
