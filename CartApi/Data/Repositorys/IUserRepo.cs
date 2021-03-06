using CartApi.Data.Models;
using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApi.Data.Repositorys
{
    public interface IUserRepo
    {
        UserViewModel GetUser(LoginViewModel login);
        bool Register(RegisterViewModel register);
    }
    public class UserRepo : IUserRepo
    {
        public UserViewModel GetUser(LoginViewModel login)
        {
            UserViewModel user = null;
            using (var context=new CartContext())
            {
                if (context.Users.Any(x => x.Username == login.LoginUserName && x.Password == login.LoginPassword))
                {
                    var a = context.Users.Single(x => x.Username == login.LoginUserName && x.Password == login.LoginPassword);
                    user = new UserViewModel()
                    {
                        UserId = a.UserId,
                        UserName = a.Username,
                        Password = a.Password
                    };
                }
            }
            return user;
        }

        public bool Register(RegisterViewModel register)
        {
            Random random = new Random();
            using (CartContext context = new CartContext())
            {
                if (!context.Users.Any(x => x.Username == register.RegisterUserName))
                {
                    Cart cart = new Cart() { CartId = random.Next() };
                    context.Carts.Add(cart);
                    User user = new User() { UserId = cart.CartId, Username = register.RegisterUserName, Password = register.RegisterPassword };
                    context.Users.Add(user);
                    context.SaveChanges();
                    context.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
