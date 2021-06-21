using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract
{
    public interface IUserRepo
    {
        void RegisterUser(User user);
        Nullable<int> LoginUser(User user);
    }
}
