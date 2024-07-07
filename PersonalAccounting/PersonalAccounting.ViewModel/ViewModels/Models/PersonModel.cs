using PersonalAccounting.ViewModel.ViewModels.IModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.Models
{
    public class PersonModel : BaseViewModel, IPersonModel
    {
        public int CustomerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FullName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
