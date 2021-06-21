using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract.Repositorys
{
    public interface ICartRepository
    {
        IList<Product> GetProductsInCart(int cartid);

    }
}
