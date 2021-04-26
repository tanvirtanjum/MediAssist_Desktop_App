using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class EmployeesModel
    {
		DBC db = new DBC();

		public Employee getEmployee(int login_id)
		{
			Employee user = null;

			string query = "SELECT * FROM employees WHERE login_id = '" + login_id + "';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				user = new Employee();
				dr.Read();

				user.ID = dr.GetInt32(0);
				user.Name = dr.GetString(1);
				user.Salary = dr.GetDouble(2);
				user.Blood_group = dr.GetString(3);
				user.Phone = dr.GetString(4);
				user.Login_id = dr.GetInt32(5);
				db.closeConnection();

				LoginsModel lm = new LoginsModel();

				user.Login_obj = lm.getInfo(Convert.ToInt32(user.ID));
				
			}
			else
			{
				db.closeConnection();
			}

			return user;
		}

		public bool updateProfile(Employee employee, string priv)
		{
			string query = "UPDATE employees SET name = '" + employee.Name + "', phone = '"+employee.Phone+ "', blood_group = '" + employee.Blood_group + "' WHERE id = '" + employee.Login_obj.Email_obj.ID + "';";

			try
			{
				if(employee.Login_obj.Email_obj.Mail != priv)
                {
					EmailsModel em = new EmailsModel();

					bool mail = em.updateEmail(employee);

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
