using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract
{
    public interface IUserService
    {
        AddUserResponseDto Register(User user);
        LoginUserResponseDto Login(User user);

    }
}
