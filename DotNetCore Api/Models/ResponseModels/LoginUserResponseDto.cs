using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.Models.ResponseModels
{
    public class LoginUserResponseDto
    {
        public string Message { get; set; }
        public User User { get; set; }
    }
}
