using PersonalAccounting.ViewModel.Commands.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalAccounting.ViewModel.Commands.Commands
{
    public class TestCommand : BaseCommand, ITestCommand
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show("It Works!!");
        }
    }
}
