using CartApi.Models;
using CartApi.Mvc.DataAccess.InterFaces;
using CartApi.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CartApi.Mvc.DataAccess.Concrete
{
    public class UserService : IUserService
    {
        public HttpResponseMessage Login(UserLogin login)
        {
            var a = new LoginViewModel() { LoginUserName = login.UserName, LoginPassword = login.Password };
            using (HttpClient httpClient = new HttpClient())
            {
                var posttask = httpClient.PostAsJsonAsync<LoginViewModel>("https://localhost:44386/api/user/login", a);
                posttask.Wait();
                return posttask.Result;
            }
        }
    }
}