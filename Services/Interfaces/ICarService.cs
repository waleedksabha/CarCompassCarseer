﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICarService
    {
        Task<ResponseResult<dynamic>> GetAllMakes(string format);
    }
}