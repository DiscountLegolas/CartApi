﻿using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.ResponseModels
{
    public class AddUserResponseDto
    {
        public bool Success { get; set; }
        public User AddedUser { get; set; }
    }
}