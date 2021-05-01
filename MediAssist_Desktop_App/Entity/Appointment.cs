using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Appointment
    {
        int id;
        string date;
        string issue;
        int doctor_id;
        int consumer_id;
        int appointment_status;

        Login login_obj_doc;
        Login login_obj_cus;
        Appointment_Status appointment_status_obj;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Issue
        {
            get { return issue; }
            set { issue = value; }
        }

        public int Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }

        public int Consumer_id
        {
            get { return consumer_id; }
            set { consumer_id = value; }
        }

        public int Appointment_status
        {
            get { return appointment_status; }
            set { appointment_status = value; }
        }

        public Login Login_obj_doc
        {
            get { return login_obj_doc; }
            set { login_obj_doc = value; }
        }

        public Login Login_obj_cus
        {
            get { return login_obj_cus; }
            set { login_obj_cus = value; }
        }

        public Appointment_Status Appointment_status_obj
        {
            get { return appointment_status_obj; }
            set { appointment_status_obj = value; }
        }
    }
}
