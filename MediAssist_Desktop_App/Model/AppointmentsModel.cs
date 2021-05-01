using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class AppointmentsModel
    {
		DBC db = new DBC();
		public List<Appointment> getTableForDoctor(int id, int status)
		{
			List<Appointment> table = new List<Appointment>();

			string query;

			if (status == 0)
            {
				query = "SELECT * FROM appointments WHERE doctor_id = '" + id + "' ORDER BY appointment_status;";
			}

			else
            {
				query = "SELECT * FROM appointments WHERE doctor_id = '" + id + "' AND appointment_status = '"+status+"';";

			}

			

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Appointment appointment = new Appointment();

					appointment.ID = dr.GetInt32(0);
					appointment.Date = dr.GetString(1);
					appointment.Issue = dr.GetString(2);
					appointment.Doctor_id = dr.GetInt32(3);
					appointment.Consumer_id = dr.GetInt32(4);
					appointment.Appointment_status = dr.GetInt32(5);


					LoginsModel lm = new LoginsModel();
					Appointment_StatusModel asm = new Appointment_StatusModel();

					appointment.Login_obj_doc = lm.getInfoOnOpenConnection(appointment.Doctor_id);
					appointment.Login_obj_cus = lm.getInfoOnOpenConnection(appointment.Consumer_id);

					appointment.Appointment_status_obj = asm.getInfoOnOpenConnection(appointment.Appointment_status);

					table.Add(appointment);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public bool changeStatus(Appointment appointment)
		{
			string query = "UPDATE appointments SET appointment_status = '" + appointment.Appointment_status + "', date = '"+appointment.Date+"' WHERE id = '" + appointment.ID + "';";

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
