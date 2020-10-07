using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL
{
    class Check
    {
        public static bool CheckMobilePhone(string phone)
        {
            
            bool check = true;
            if (phone != "")
            {
                if (phone.Length != 11 ||
                    !Regex.IsMatch(phone, @"1\d{10}"))
                {
                    check = false;
                }
            }
            return check;
        }

        public static bool CheckYear(string year)
        {
            bool check = true;
            if (year != "")
            {
                if (year.Length != 4 ||
                    !Regex.IsMatch(year, @"2\d{3}"))
                {
                    check = false;
                }
            }
            return check;
        }
    }
}
