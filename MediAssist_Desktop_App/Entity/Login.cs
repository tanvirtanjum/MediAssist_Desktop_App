using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Entity
{
    public class Login
    {
        int id;
        string username;
        string password;
        int role;
        int access;
        int reg_status;
        int email_id;

        int cart_id;

        Role role_obj;
        Access access_obj;
        Reg_status reg_Status_obj;
        Email email_obj;

        Consumers consumers_obj;

        public Login() { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        public int Access
        {
            get { return access; }
            set { access = value; }
        }

        public int Reg_status
        {
            get { return reg_status; }
            set { reg_status = value; }
        }

        public int Email_id
        {
            get { return email_id; }
            set { email_id = value; }
        }

        public int Cart_id
        {
            get { return cart_id; }
            set { cart_id = value; }
        }

        public Role Role_obj
        {
            get { return role_obj; }
            set { role_obj = value; }
        }

        public Access Access_obj
        {
            get { return access_obj; }
            set { access_obj = value; }
        }

        public Reg_status Reg_Status_obj
        {
            get { return reg_Status_obj; }
            set { reg_Status_obj = value; }
        }

        public Email Email_obj
        {
            get { return email_obj; }
            set { email_obj = value; }
        }

        public Consumers Consumers_obj
        {
            get { return consumers_obj; }
            set { consumers_obj = value; }
        }

    }
}
