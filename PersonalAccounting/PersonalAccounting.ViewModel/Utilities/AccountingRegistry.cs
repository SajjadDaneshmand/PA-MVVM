using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Utilities
{
    public class AccountingRegistry : IAccountingRegistry
    {
        private readonly string _registryName = "SOFTWARE\\PA";
        private RegistryKey _registryKey;
        private bool _isRegistryExist = true;

        public bool IsRegistryExist
        {
            get => _isRegistryExist;
            set
            {
                _isRegistryExist = value;
            }
        }
        public string RegisteryName => _registryName;

        public AccountingRegistry()
        {

            _registryKey = Registry.CurrentUser.OpenSubKey(_registryName);
            if (_registryKey == null)
            {
                _registryKey = Registry.CurrentUser.CreateSubKey(_registryName);
                IsRegistryExist = false;
            }
        }

        public string Get(string key)
        {
            return _registryKey.GetValue(key, null).ToString();
        }


        public bool Write(string key, string value)
        {
            _registryKey.SetValue(key, value);
            return true;
        }
    }
}
