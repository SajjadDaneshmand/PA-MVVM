﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Commands.ICommands
{
    public interface ICreateTransactionCommand
    {
        void Execute(object parameter);
    }
}
