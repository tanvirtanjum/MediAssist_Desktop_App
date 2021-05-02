using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediAssist_Desktop_App.Sealed_Class
{
    public class TokenGenerator
    {
        DateTime todaysDate = DateTime.Now;

        public int token(int id)
        {
            string cart_id_gen = "";
            cart_id_gen += id;
            cart_id_gen += todaysDate.Day;
            cart_id_gen += todaysDate.Month;
            //cart_id_gen += todaysDate.Year;
            cart_id_gen += todaysDate.Hour;
            cart_id_gen += todaysDate.Minute;
            cart_id_gen += todaysDate.Second;

            int cart_id;
            bool isInt = Int32.TryParse(cart_id_gen, out cart_id);

            return cart_id;
        }
        
    }
}
