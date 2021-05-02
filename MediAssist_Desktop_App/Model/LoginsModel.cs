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

		public List<Login> getTable()
		{
			List<Login> table = new List<Login>();
			try
            {
				

				string query = "SELECT * FROM logins WHERE reg_status = '1';";

				db.openConnection();
				db.executeQuery(query);

				var dr = db.cmd.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Login consumer = new Login();

						consumer.ID = dr.GetInt32(0);
						consumer.Username = dr.GetString(1);
						consumer.Password = dr.GetString(2);
						consumer.Role = dr.GetInt32(3);
						consumer.Access = dr.GetInt32(4);
						consumer.Reg_status = dr.GetInt32(5);
						consumer.Email_id = dr.GetInt32(6);

						ConsumersModel cm = new ConsumersModel();

						consumer.Consumers_obj = cm.getConsumerOnOpenConnection(consumer.ID);

						table.Add(consumer);
					}
				}

				else
				{
					db.closeConnection();
				}

				db.closeConnection();
			}

			catch(Exception ex)
            {

            }
			return table;
		}

		public List<Login> getDel()
		{
			List<Login> table = new List<Login>();
			try
			{


				string query = "SELECT * FROM logins WHERE role = '4' AND access = '1';";

				db.openConnection();
				db.executeQuery(query);

				var dr = db.cmd.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Login deliveryman = new Login();

						deliveryman.ID = dr.GetInt32(0);
						deliveryman.Username = dr.GetString(1);
						deliveryman.Password = dr.GetString(2);
						deliveryman.Role = dr.GetInt32(3);
						deliveryman.Access = dr.GetInt32(4);
						deliveryman.Reg_status = dr.GetInt32(5);
						deliveryman.Email_id = dr.GetInt32(6);

						table.Add(deliveryman);
					}
				}

				else
				{
					db.closeConnection();
				}

				db.closeConnection();
			}

			catch (Exception ex)
			{

			}
			return table;
		}

		public List<Login> getDoc()
		{
			List<Login> table = new List<Login>();
			try
			{


				string query = "SELECT * FROM logins WHERE role = '3' AND access = '1';";

				db.openConnection();
				db.executeQuery(query);

				var dr = db.cmd.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Login doctor = new Login();

						doctor.ID = dr.GetInt32(0);
						doctor.Username = dr.GetString(1);
						doctor.Password = dr.GetString(2);
						doctor.Role = dr.GetInt32(3);
						doctor.Access = dr.GetInt32(4);
						doctor.Reg_status = dr.GetInt32(5);
						doctor.Email_id = dr.GetInt32(6);

						EmailsModel em = new EmailsModel();

						doctor.Email_obj = em.getInfoOnOpenConnection(doctor.Email_id);

						table.Add(doctor);
					}
				}

				else
				{
					db.closeConnection();
				}

				db.closeConnection();
			}

			catch (Exception ex)
			{

			}
			return table;
		}

		public List<Login> getCus()
		{
			List<Login> table = new List<Login>();
			try
			{


				string query = "SELECT * FROM logins WHERE role = '5' AND access = '1' AND reg_status = '2';";

				db.openConnection();
				db.executeQuery(query);

				var dr = db.cmd.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Login consumer = new Login();

						consumer.ID = dr.GetInt32(0);
						consumer.Username = dr.GetString(1);
						consumer.Password = dr.GetString(2);
						consumer.Role = dr.GetInt32(3);
						consumer.Access = dr.GetInt32(4);
						consumer.Reg_status = dr.GetInt32(5);
						consumer.Email_id = dr.GetInt32(6);

						EmailsModel em = new EmailsModel();

						consumer.Email_obj = em.getInfoOnOpenConnection(consumer.Email_id);

						table.Add(consumer);
					}
				}

				else
				{
					db.closeConnection();
				}

				db.closeConnection();
			}

			catch (Exception ex)
			{

			}
			return table;
		}


		public bool acccptAllConsumers()
		{
			string query = "UPDATE logins SET reg_status = '2' WHERE reg_status = '1';";

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

		public bool acccptConsumer(int id)
		{
			string query = "UPDATE logins SET reg_status = '2' WHERE reg_status = '1' AND id = '"+id+"';";

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

		public bool rejectUser(Login login)
		{
			string query = "DELETE FROM logins WHERE id = '" + login.ID + "';";

			try
			{

				ConsumersModel cm = new ConsumersModel();
				bool delC = cm.rejectConsumer(login.ID);


				if (delC)
                {
					db.openConnection();
					db.executeQuery(query);
					db.closeConnection();
				}
				else
                {
					return false;
                }

				EmailsModel em = new EmailsModel();
				bool del = em.rejectMail(login.Email_id);


				return del;
			}

			catch (Exception ex)
			{
				return false;
			}

		}

	}
}
