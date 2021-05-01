using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class Appointment_StatusModel
    {
		DBC db = new DBC();
		public Appointment_Status getInfoOnOpenConnection(int id)
		{
			Appointment_Status type = null;

			string query = "SELECT * FROM appointment_status WHERE id = '" + id + "';";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				type = new Appointment_Status();
				dr.Read();

				type.ID = dr.GetInt32(0);
				type.Status = dr.GetString(1);

				//db.closeConnection();

			}
			else
			{
				//db.closeConnection();
			}

			return type;
		}
	}
}
