using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.IModels
{
    public interface IPersonModel: IBaseViewModel
    {
        int CustomerId { get; set; }
        string FullName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }
    }
}
