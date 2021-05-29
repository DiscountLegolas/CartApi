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
            _repo.Register(register);
            return Ok();
        }
        [Route("api/user/login")]
        [HttpPost]
        public IHttpActionResult PostLogin(LoginViewModel login)
        {
            var user = _repo.GetUser(login);
            if (user==null)
            {
                return Ok<string>("Cant Find");
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
