using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class NotesModel
    {
		DBC db = new DBC();

		public List<Note> getTable(int id)
		{
			List<Note> table = new List<Note>();

			string query = "SELECT * FROM notes WHERE owner_id = '" + id + "';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while(dr.Read())				
                {
					Note note = new Note();

					note.ID = dr.GetInt32(0);
					note.Subject = dr.GetString(1);
					note.Text = dr.GetString(2);
					note.Owner_id = dr.GetInt32(3);

					LoginsModel lm = new LoginsModel();

					note.Owner_obj = lm.getInfoOnOpenConnection(id);

					table.Add(note);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public bool AddNote(Note note)
		{
			string query = "INSERT INTO notes VALUES('"+note.Subject+ "', '" + note.Text + "', '" + note.Owner_id + "'); ";

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

		public bool UpdateNote(Note note)
		{
			string query = "UPDATE notes SET subject = '" + note.Subject + "', text = '" + note.Text + "' WHERE id = '" + note.ID + "' AND owner_id='" + note.Owner_id + "';";

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

		public bool DeleteNote(Note note)
		{
			string query = "DELETE FROM notes WHERE id = '" + note.ID + "' AND owner_id='" + note.Owner_id + "';";

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
