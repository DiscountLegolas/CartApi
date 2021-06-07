using CartApi.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CartApi.Mvc.DataAccess.InterFaces
{
    public interface IUserService
    {
        HttpResponseMessage Login(UserLogin login);
    }
}
