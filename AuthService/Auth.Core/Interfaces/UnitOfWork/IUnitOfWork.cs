﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();  
    }
}
