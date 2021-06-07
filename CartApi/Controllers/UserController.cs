using CartApi.Data.Repositorys;
using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CartApi.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepo _repo;
        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }
        [Route("api/user/register")]
        [HttpPost]
        public IHttpActionResult PostRegister(RegisterViewModel register)
        {
            try
            {
                var a=_repo.Register(register);
                if (a)
                {
                    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.Created);
                    return ResponseMessage(message);
                }
                else
                {
                    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Aynı Kullanıcı Adına Sahip Başka Bir Kullanıcı Var") };
                    return ResponseMessage(message);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [Route("api/user/login")]
        [HttpPost]
        public IHttpActionResult PostLogin(LoginViewModel login)
        {
            var user = _repo.GetUser(login);
            if (user==null)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("Kullanıcı Bulunamadı") };
                return ResponseMessage(message);
            }
            else
            {
                return Json(user);
            }
        }
    }
}
