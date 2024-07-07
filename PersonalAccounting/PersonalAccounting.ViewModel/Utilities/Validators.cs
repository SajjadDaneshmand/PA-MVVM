using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PersonalAccounting.ViewModel.Utilities
{
    public static class Validators
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length < 8)
                return false;

            if (
                !phoneNumber.StartsWith("09") &&
                !phoneNumber.StartsWith("051") &&
                !phoneNumber.StartsWith("3")
                )
            {
                return false;
            }

            foreach (char c in phoneNumber)
               if (!char.IsDigit(c)) 
                    return false;
            
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            var pattern = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*" +
                "@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            return Regex.IsMatch(email, pattern);

        }
    }
}
