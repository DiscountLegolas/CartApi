using CartApi.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartApi.Models;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace CartApi.Mvc.Controllers
{
    public class CartMvcController:Controller
    {
        public ActionResult AddItemToCart(int id)
        {
            HttpClient client = new HttpClient();
            UserViewModel user = (UserViewModel)Session["User"];
            var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", user.UserName},
                   {"password", user.Password},
               };
            var token = client.PostAsync("https://localhost:44386/token", new FormUrlEncodedContent(form)).Result.Content.ReadAsAsync<Token>().Result;
            using (HttpClient httpClient=new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
                AddProductToCartVM add = new AddProductToCartVM() { ProductId = id, UserId = user.UserId };
                var f = httpClient.PostAsJsonAsync<AddProductToCartVM>("https://localhost:44386/api/Cart/AddItem", add);
                f.Wait();
            }
            return RedirectToAction("Index", "UserMvc");
        }
    }
}