﻿using Leave_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Areas.Contracts
{
    public interface ILeaveAllocationRepository: IRepositoryBase<LeaveAllocation>
    {
    }
}
