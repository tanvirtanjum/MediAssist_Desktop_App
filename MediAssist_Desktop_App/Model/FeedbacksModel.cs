using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    class FeedbacksModel
    {
		DBC db = new DBC();
		public List<Feedback> getTable()
		{
			List<Feedback> table = new List<Feedback>();

			string query = "SELECT * FROM feedbacks;";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Feedback feedback = new Feedback();

					feedback.ID = dr.GetInt32(0);
					feedback.Feedback_text = dr.GetString(1);
					feedback.Login_id = dr.GetInt32(2);

					LoginsModel lm = new LoginsModel();

					feedback.Login_obj = lm.getInfoOnOpenConnection(feedback.Login_id);

					table.Add(feedback);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}
	}
}
