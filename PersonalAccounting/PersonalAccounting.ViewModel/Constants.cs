using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAccounting.ViewModel.Utilities;

namespace PersonalAccounting.ViewModel
{
    public static class Constants
    {
        public static string START_DATE_REGISTRY_KEY = "StartDate";
        public static string CONNECTION_STRING = ConnectionStringBuilder.CreateString(".\\SQLSERVER2005", "Accounting_DB", "sa", "arta0@");
    }
}
