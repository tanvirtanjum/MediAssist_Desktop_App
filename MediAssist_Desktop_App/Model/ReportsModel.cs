using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    class ReportsModel
    {
        DBC db = new DBC();

		public List<Report> getTableForDoctor(int id)
		{
			List<Report> table = new List<Report>();

			string query = "SELECT * FROM reports WHERE prescribe_by = '" + id + "' ORDER BY prescribe_for;"; ;


			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Report report = new Report();

					report.ID = dr.GetInt32(0);
					report.Subject = dr.GetString(1);
					report.Report_txt = dr.GetString(2);
					report.Prescribe_by = dr.GetInt32(3);
					report.Prescribe_for = dr.GetInt32(4);

					LoginsModel lm = new LoginsModel();

					report.Login_obj_doc = lm.getInfoOnOpenConnection(report.Prescribe_by);
					report.Login_obj_cus = lm.getInfoOnOpenConnection(report.Prescribe_for);


					table.Add(report);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public List<Report> getTableForConsumer(int id)
		{
			List<Report> table = new List<Report>();

			string query = "SELECT * FROM reports WHERE prescribe_for = '" + id + "' ORDER BY prescribe_by;"; ;


			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Report report = new Report();

					report.ID = dr.GetInt32(0);
					report.Subject = dr.GetString(1);
					report.Report_txt = dr.GetString(2);
					report.Prescribe_by = dr.GetInt32(3);
					report.Prescribe_for = dr.GetInt32(4);

					LoginsModel lm = new LoginsModel();

					report.Login_obj_doc = lm.getInfoOnOpenConnection(report.Prescribe_by);
					report.Login_obj_cus = lm.getInfoOnOpenConnection(report.Prescribe_for);


					table.Add(report);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public bool addReport(Report report)
		{
			

			string query = "INSERT INTO reports VALUES('" + report.Subject + "', '" + report.Report_txt + "', '" + report.Prescribe_by + "', '" + report.Prescribe_for + "');";

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

		public bool updateReport(Report report)
		{


			string query = "UPDATE reports SET subject = '" + report.Subject + "', report = '" + report.Report_txt + "' WHERE id = '"+report.ID+"';";

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

		public bool DeleteReport(int id)
		{
			string query = "DELETE FROM reports WHERE id = '" + id + "';";

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
