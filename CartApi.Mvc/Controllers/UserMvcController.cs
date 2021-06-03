using CartApi.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartApi.Models;
using System.Net.Http;

namespace CartApi.Mvc.Controllers
{
    public class UserMvcController : Controller
    {
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
            var a = new LoginViewModel() { LoginUserName = login.UserName, LoginPassword = login.Password };
            using (HttpClient httpClient=new HttpClient())
            {
                var posttask = httpClient.PostAsJsonAsync<LoginViewModel>("https://localhost:44386/api/user/login", a);
                posttask.Wait();
                if (posttask.Result.IsSuccessStatusCode)
                { 
                    Session["User"] = posttask.Result.Content.ReadAsAsync<UserViewModel>().Result;
                    return RedirectToAction("Index", "UserMvc");
                }
                return View(login);
            }
        }
        public ActionResult Register()
        { return View(); }
        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            var a = new RegisterViewModel() { RegisterUserName = register.UserName, RegisterPassword = register.Password };
            using (HttpClient client=new HttpClient())
            {
                var postregister = client.PostAsJsonAsync<RegisterViewModel>("https://localhost:44386/api/user/register", a);
                postregister.Wait();
            }
            return RedirectToAction("Login", "UserMvc");
        }
    }
}