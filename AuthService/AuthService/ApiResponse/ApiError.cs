﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.ApiResponse
{
    public class ApiError
    {
        public string Message { get; set; }
        public ApiError(string message)
         => Message = message;

    }
}
