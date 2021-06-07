using CartApi.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartApi.Models;
using System.Net.Http;
using ServiceStack.Redis;
using System.Web.Security;
using CartApi.Mvc.DataAccess.InterFaces;
using System.Text.RegularExpressions;

namespace CartApi.Mvc.Controllers
{
    public class UserMvcController : Controller
    {
        private IUserService _service;
        public UserMvcController(IUserService service)
        {
            _service = service;
        }
        // GET: UserMvc
        public ActionResult Index()
        {
            Products products = new Products();
            HttpClient client = new HttpClient();
            var a = client.GetAsync("https://localhost:44386/api/products").Result.Content.ReadAsAsync<IList<ProductViewModel>>();
            products.Ürünler = a.Result.ToList();
            return View(products);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin login)
        {
            var response = _service.Login(login);
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    FormsAuthentication.SetAuthCookie(login.UserName,false);
                    var user = response.Content.ReadAsAsync<UserViewModel>().Result;
                    HttpCookie cookie = new HttpCookie("user", user.UserId.ToString());
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "UserMvc");
                case System.Net.HttpStatusCode.NotFound:
                    var error = response.Content.ReadAsStringAsync().Result;
                    ViewBag.Error = error;
                    return View(login);
                default:
                    ViewBag.Error = "Bilinmeyen Hata Oluştu";
                    return View(login);
            }
        }
        public ActionResult Register()
        { return View(); }
        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var a = new RegisterViewModel() { RegisterUserName = register.UserName, RegisterPassword = register.Password };
                using (HttpClient client = new HttpClient())
                {
                    var postregister = client.PostAsJsonAsync<RegisterViewModel>("https://localhost:44386/api/user/register", a);
                    postregister.Wait();
                    if (postregister.Result.StatusCode==System.Net.HttpStatusCode.Created)
                    {
                        return RedirectToAction("Login", "UserMvc");
                    }
                    else if(postregister.Result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        var error = postregister.Result.Content.ReadAsStringAsync().Result;
                        ViewBag.HataSebep = error;
                        return View(register);
                    }
                    else
                    {
                        ViewBag.HataSebep = "Bilinmeyen Bir Hata Oluştu Lütfen Tekrar Deneyin";
                        return View(register);
                    }
                }
            }
            else
            {
                return View(register);
            }
        }
    }
}