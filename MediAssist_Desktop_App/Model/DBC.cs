using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace MediAssist_Desktop_App
{
    public class DBC
    {
       public DBC() { }
        public static string GetConnectionStrings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conString"].ToString();

            return connectionString;
        }

        public string sql;

        public static SqlConnection con = new SqlConnection();

        public SqlCommand cmd = new SqlCommand("", con);

        public static SqlDataReader rd;

        public DataTable dt;

        public SqlDataAdapter da;

        public void openConnection()
        {
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionStrings();
                    con.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to establish a connection.\nDescription: " + ex.Message.ToString(), "Database Connection(SQL SERVER)", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void closeConnection()
        {
            try
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong.");
            }
        }


        public void executeQuery(string query)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                _ = cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.");
            }

        }
    }
}
