using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MediAssist_Desktop_App.Entity;

namespace MediAssist_Desktop_App.Model
{
    public class MedicinesModel
    {
        DBC db = new DBC();

		public List<Medicine> getTable(int id)
		{
			List<Medicine> table = new List<Medicine>();

			string query = "";

			if (id != 0)
            {
				query = "SELECT * FROM medicines WHERE availability ='" + id + "';";
			}
			else
            {
				query = "SELECT * FROM medicines;";
			}
			 

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Medicine medicine = new Medicine();

					medicine.ID = dr.GetInt32(0);
					medicine.Name = dr.GetString(1);
					medicine.Distributer = dr.GetString(2);
					medicine.Type = dr.GetInt32(3);
					medicine.Price = dr.GetDouble(4);
					medicine.Quantity = dr.GetInt32(5);
					medicine.Availability = dr.GetInt32(6);

					Medicine_TypesModel mtm = new Medicine_TypesModel();
					AvailabilityModel am = new AvailabilityModel();

					medicine.Type_obj = mtm.getInfoOnOpenConnection(medicine.Type);
					medicine.Availability_obj = am.getInfoOnOpenConnection(medicine.Availability);

					table.Add(medicine);
				}
			}

			else
			{
				db.closeConnection();
			}

			db.closeConnection();

			return table;
		}

		public bool insertMedicine(Medicine medicine)
		{

			string query = "INSERT INTO medicines VALUES('" + medicine.Name + "', '" + medicine.Distributer + "', '" + medicine.Type + "', '" + medicine.Price + "', '" + medicine.Quantity + "', '" + medicine.Availability + "');";

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

		public bool updateMedicine(Medicine medicine)
		{

			string query = "UPDATE medicines SET name = '" + medicine.Name + "', distributor = '" + medicine.Distributer + "', type = '" + medicine.Type + "', price = '" + medicine.Price + "', quantity = '" + medicine.Quantity + "', availability = '" + medicine.Availability + "' WHERE id = '"+medicine.ID+"';";

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

		public void updateMedicineQuant(int id, int quantity)
		{

			string query = "UPDATE medicines SET quantity = '" + quantity + "' WHERE id = '" + id + "';";

			try
			{
				db.openConnection();
				db.executeQuery(query);
				db.closeConnection();

				//return true;
			}

			catch (Exception ex)
			{
				//return false;
				MessageBox.Show("Something Went Wrong.");
			}
		}

		public Medicine getInfoOnOpenConnection(int id)
		{
			Medicine medicine = null;

			string query = "SELECT * FROM medicines WHERE id = '"+id+"';";

			db.openConnection();
			db.executeQuery(query);

			var dr = db.cmd.ExecuteReader();


			if (dr.HasRows)
			{
				dr.Read();
				medicine = new Medicine();

				medicine.ID = dr.GetInt32(0);
				medicine.Name = dr.GetString(1);
				medicine.Distributer = dr.GetString(2);
				medicine.Type = dr.GetInt32(3);
				medicine.Price = dr.GetDouble(4);
				medicine.Quantity = dr.GetInt32(5);
				medicine.Availability = dr.GetInt32(6);

				Medicine_TypesModel mtm = new Medicine_TypesModel();
				AvailabilityModel am = new AvailabilityModel();

				medicine.Type_obj = mtm.getInfoOnOpenConnection(medicine.Type);
				medicine.Availability_obj = am.getInfoOnOpenConnection(medicine.Availability);
			}
			else
			{
				//db.closeConnection();
			}

			return medicine;
		}
	}
}
