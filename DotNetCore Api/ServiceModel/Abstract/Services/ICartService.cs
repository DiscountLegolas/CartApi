using DotNetCore_Api.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Abstract.Services
{
    public interface ICartService
    {
        CartResponseDto DecreaseQuantity(int userıd, int productıd);
        CartResponseDto GetCart(int userıd);
        CartResponseDto AddProductToCart(int userıd, int productıd);
        CartResponseDto RemoveProductFromCart(int userıd, int productıd);

    }
}
