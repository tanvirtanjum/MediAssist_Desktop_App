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

				user.Login_obj = lm.getInfo(Convert.ToInt32(user.Login_id));
				
			}
			else
			{
				db.closeConnection();
			}

			return user;
		}

		public bool updateProfile(Employee employee, string priv)
		{
			string query = "UPDATE employees SET name = '" + employee.Name + "', phone = '"+employee.Phone+ "', blood_group = '" + employee.Blood_group + "' WHERE id = '" + employee.ID + "';";

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

		public List<Employee> getTable()
		{
			List<Employee> table = new List<Employee>();

			string query = "SELECT * FROM employees;";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Employee employee = new Employee();

					employee.ID = dr.GetInt32(0);
					employee.Name = dr.GetString(1);
					employee.Salary = dr.GetDouble(2);
					employee.Blood_group = dr.GetString(3);
					employee.Phone = dr.GetString(4);
					employee.Login_id = dr.GetInt32(5);

					LoginsModel lm = new LoginsModel();

					employee.Login_obj = lm.getInfoOnOpenConnection(employee.Login_id);

					table.Add(employee);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public int insertEmployee(Employee employee, Login login, Email email)
		{
			LoginsModel lm = new LoginsModel();
			int login_id = lm.insertUser(login, email);

			employee.Login_id = login_id;

			Int32 id = 0;


			string query = "INSERT INTO employees OUTPUT INSERTED.id VALUES('" + employee.Name + "', '"+ employee.Salary + "', '" + employee.Blood_group + "', '" + employee.Phone + "', '"+ employee.Login_id + "');";

			if (login_id != 0)
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

		public bool updateEmployee(Employee employee, string priv)
		{
			string query = "UPDATE employees SET name = '" + employee.Name + "', salary = '" + employee.Salary + "', phone = '" + employee.Phone + "', blood_group = '" + employee.Blood_group + "' WHERE id = '" + employee.ID + "';";

			try
			{
				if (employee.Login_obj.Email_obj.Mail != priv)
				{
					EmailsModel em = new EmailsModel();

					bool mail = em.updateEmail(employee);

					if (mail)
					{
						LoginsModel lm = new LoginsModel();

						bool log = lm.changeRole(employee.Login_obj);

						if(log)
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
						return false;
					}
				}

				else
				{
					LoginsModel lm = new LoginsModel();

					bool log = lm.changeRole(employee.Login_obj);

					if (log)
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

			}

			catch (Exception ex)
			{
				return false;
			}

		}

	}
}
