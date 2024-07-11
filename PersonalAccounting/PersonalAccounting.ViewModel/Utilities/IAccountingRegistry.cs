using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Utilities
{
    public interface IAccountingRegistry
    {
        string RegisteryName { get; }
        bool IsRegistryExist { get; set; }
        bool Write(string key, string value);
        string Get(string key);
    }
}
