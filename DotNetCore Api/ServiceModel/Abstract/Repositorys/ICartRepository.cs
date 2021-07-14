using DotNetCore_Api.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract.Repositorys
{
    public interface ICartRepository
    {
        Cart GetCartInfo(int userıd);
        Cart AddToCart(int userid, int productıd);
        Cart RemoveFromCart(int userıd, int productıd);
        Cart DecreaseQuantity(int userıd, int productıd);
    }
}
