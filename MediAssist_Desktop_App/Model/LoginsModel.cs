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

		public bool activateUser(int id)
		{
			string query = "UPDATE logins SET access = '1' WHERE id='" + id + "';";

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

		public bool deactivateUser(int id)
		{
			string query = "UPDATE logins SET access = '2' WHERE id='" + id + "';";

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

		public int insertUser(Login login, Email email)
		{
			EmailsModel em = new EmailsModel();
			int email_id = em.insertEmail(email);

			login.Email_id = email_id;

			Int32 id = 0;


			string query = "INSERT INTO logins OUTPUT INSERTED.id VALUES('" + login.Username + "', '1234', '"+login.Role+"', '1', '2', '"+login.Email_id+"');";

			if (email_id != 0)
			{
				try
				{
					db.openConnection();
					id = (Int32)db.executeScaler(query);
					db.closeConnection();

					return id;
				}

				catch (Exception ex)
				{
					return id;
				}
			}

			else
			{
				return id;
			}
		}

		public bool changeRole(Login login)
		{
			string query = "UPDATE logins SET role = '" + login.Role + "' WHERE id='" + login.ID + "';";

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
