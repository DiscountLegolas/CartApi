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

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HttpClient client = new HttpClient();
            var a = client.GetAsync("https://localhost:44386/api/products").Result.Content.ReadAsAsync<IList<ProductViewModel>>();
            Assert.IsTrue(a.Result.Count > 0);
        }
    }
}
