using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class ConsumersModel
    {
		DBC db = new DBC();

		public Consumers getConsumer(int login_id)
		{
			Consumers user = null;

			string query = "SELECT * FROM consumers WHERE login_id = '" + login_id + "';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				user = new Consumers();
				dr.Read();

				user.ID = dr.GetInt32(0);
				user.Name = dr.GetString(1);
				user.Occupation = dr.GetString(2);
				user.Blood_group = dr.GetString(3);
				user.Phone = dr.GetString(4);
				user.Login_id = dr.GetInt32(5);
				db.closeConnection();

				LoginsModel lm = new LoginsModel();

				user.Login_obj = lm.getInfo(Convert.ToInt32(user.Login_id));

			}
			else
			{
				db.closeConnection();
			}

			return user;
		}

		public bool updateProfile(Consumers consumer, string priv)
		{
			string query = "UPDATE consumers SET name = '" + consumer.Name + "', phone = '" + consumer.Phone + "', blood_group = '" + consumer.Blood_group + "' WHERE id = '" + consumer.ID + "';";

			try
			{
				if (consumer.Login_obj.Email_obj.Mail != priv)
				{
					EmailsModel em = new EmailsModel();

					bool mail = em.updateEmailConsumer(consumer);

					if (mail)
					{
						db.openConnection();
						db.executeQuery(query);
						db.closeConnection();

						return true;
					}

					else
					{
						return false;
					}
				}

				else
				{
					db.openConnection();
					db.executeQuery(query);
					db.closeConnection();

					return true;
				}

			}

			catch (Exception ex)
			{
				return false;
			}

		}
	}
}
