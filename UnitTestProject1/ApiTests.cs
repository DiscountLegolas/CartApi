using CartApi.Models;
using CartApi.Mvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Drawing;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void RegularExpressionTest()
        {
            Regex regex = new Regex(@"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$");
            Assert.IsTrue(regex.IsMatch("Ozgur1998"));
            Regex password = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%_*#?&-])[A-Za-z\d@$!%*_#?&-]{8,}$");
            Assert.IsTrue(password.IsMatch("1998-_8b"));
        }
        [TestMethod]
        public void RegisterErrorTest()
        {
            var a = new RegisterViewModel() { RegisterUserName = "Ozgur1998", RegisterPassword = "1998-_8b" };
            using (HttpClient client = new HttpClient())
            {
                var postregister = client.PostAsJsonAsync<RegisterViewModel>("https://localhost:44386/api/user/register", a);
                postregister.Wait();
                if (postregister.Result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Console.WriteLine("Created");
                }
                else if (postregister.Result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var error = "Aynı Kullanıcı Adına Sahip Başka Bir Kullanıcı Var";
                    Assert.AreEqual(error, postregister.Result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    var HataSebep = "Bilinmeyen Bir Hata Oluştu Lütfen Tekrar Deneyin";
                    Console.WriteLine(HataSebep);
                }
            }
        }
        [TestMethod]
        public void LoginTest()
        {
            var a = new LoginViewModel() { LoginUserName = "Ozgur19913328", LoginPassword = "1998-_8b" };
            using (HttpClient client=new HttpClient())
            {
                var postlogin = client.PostAsJsonAsync<LoginViewModel>("https://localhost:44386/api/user/login", a).Result;
                var f = postlogin.Content.ReadAsStringAsync().Result;
                Console.WriteLine(f);
            }
        }
        [TestMethod]
        public void CartTest()
        {
            HttpClient client = new HttpClient();
            var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", "faff"},
                   {"password", "Pass"},
               };
            var token = client.PostAsync("https://localhost:44386/token", new FormUrlEncodedContent(form)).Result.Content.ReadAsAsync<Token>().Result;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            var getcart = client.PostAsJsonAsync("https://localhost:44386/api/Cart/AddItem", new AddProductToCartVM() { UserId=1,ProductId=1}).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(getcart);
        }
        [TestMethod]
        public void ProductsTest()
        {
            HttpClient client = new HttpClient();
            var a = client.GetAsync("https://localhost:44386/api/products");
            a.Wait();
            var response = a.Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
            var list = response.Content.ReadAsAsync<IList<ProductViewModel>>().Result;
            Assert.IsTrue(list.Count > 0);
            foreach (var item in list)
            {
                var url= "https://localhost:44386/api/products/"+item.ProductId;
                var indivudualresponse = client.GetAsync(url).Result;
                var obj = indivudualresponse.Content.ReadAsAsync<ProductViewModel>().Result;
                Assert.IsNotNull(obj);
            }
        }
        [TestMethod]
        public void ÖneriTest()
        {
            HttpClient client = new HttpClient();
            var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", "faff"},
                   {"password", "Pass"},
               };
            var token = client.PostAsync("https://localhost:44386/token", new FormUrlEncodedContent(form)).Result.Content.ReadAsAsync<Token>().Result;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            var getrepo = client.GetAsync("https://localhost:44386/api/Cart/Recomendations/1").Result.Content.ReadAsAsync<List<ProductViewModel>>().Result;
            Assert.IsTrue(getrepo.Count > 0);
        }
        [TestMethod]
        public void AddProductTest()
        {
            var httpclient = new HttpClient();
            AddProductViewModel add = new AddProductViewModel() { Name = "UnitTest", Description = "Desc", KategoriId = 1, MarkaId = 1, Price = 30.435 };
            var a=httpclient.PostAsJsonAsync("https://localhost:44386/api/products", add);
            a.Wait();
            Assert.IsTrue(a.Result.IsSuccessStatusCode);
        }
        public void UpdateProductTest()
        {

        }
    }
}
