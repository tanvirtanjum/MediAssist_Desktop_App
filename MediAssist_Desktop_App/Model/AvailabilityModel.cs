using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class AvailabilityModel
    {
		DBC db = new DBC();
		public Availability getInfoOnOpenConnection(int id)
		{
			Availability type = null;

			string query = "SELECT * FROM availability WHERE id = '" + id + "';";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				type = new Availability();
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
