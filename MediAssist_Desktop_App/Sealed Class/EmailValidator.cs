using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Sealed_Class
{
    public sealed class EmailValidator
    {
        public EmailValidator() { }
        public bool ValidateEmail(string mail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(mail);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
