using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class Medicine_TypesModel
    {
		DBC db = new DBC();
		public Medicine_Type getInfoOnOpenConnection(int id)
		{
			Medicine_Type type = null;

			string query = "SELECT * FROM medicine_types WHERE id = '" + id + "';";

			//db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				type = new Medicine_Type();
				dr.Read();

				type.ID = dr.GetInt32(0);
				type.TypeName = dr.GetString(1);
				
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
