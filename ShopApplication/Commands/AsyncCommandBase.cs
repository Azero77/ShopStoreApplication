﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Commands
{
    public class AsyncCommandBase : CommandBase
    {
        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
