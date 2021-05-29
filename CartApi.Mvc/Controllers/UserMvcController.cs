using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CartApi.Mvc.Controllers
{
    public class UserMvcController : Controller
    {
        // GET: UserMvc
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
    }
}