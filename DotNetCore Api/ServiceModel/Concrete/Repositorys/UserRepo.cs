using DotNetCore_Api.EfCore;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.ServiceModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete
{
    public class UserRepo : IUserRepo
    {
        private readonly CartDbcontext _context;
        public UserRepo(CartDbcontext context)
        {
            _context = context;
        }
        public Nullable<int> LoginUser(User user)
        {
            Nullable<int> userid = null;
            if (_context.Users.Any(x=>x.Username==user.Username&&x.Password==user.Password))
            {
                userid = _context.Users.First(x => x.Username == user.Username && x.Password == user.Password).UserId;
                return userid;
            }
            else
            {
                return userid;
            }
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
