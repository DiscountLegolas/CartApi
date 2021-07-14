using AutoMapper;
using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models.Resources;
using DotNetCore_Api.Models.ResponseModels;
using DotNetCore_Api.ServiceModel.Abstract.Repositorys;
using DotNetCore_Api.ServiceModel.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete.Services
{
    public class CartService : ICartService
    {
        private IMapper _mapper;
        private ICartRepository _repository;
        public CartService(ICartRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public CartResponseDto AddProductToCart(int userıd, int productıd)
        {
            var cart = _repository.AddToCart(userıd, productıd);
            var cartresponse = TurnCartToResponse(cart);
            return cartresponse;
        }

        public CartResponseDto DecreaseQuantity(int userıd, int productıd)
        {
            return TurnCartToResponse(_repository.DecreaseQuantity(userıd, productıd));
        }

        public CartResponseDto GetCart(int userıd)
        {
            var cart = _repository.GetCartInfo(userıd);
            var cartresponse = TurnCartToResponse(cart);
            return cartresponse;
        }

        public CartResponseDto RemoveProductFromCart(int userıd, int productıd)
        {
            var cart = _repository.RemoveFromCart(userıd, productıd);
            var cartresponse = TurnCartToResponse(cart);
            return cartresponse;
        }
        private CartResponseDto TurnCartToResponse(Cart cart)
        {
            double totalprice = 0;
            var products = new List<Product>();
            cart.ProductIncarts.ToList().ForEach(x =>
            {
                products.Add(x.Product);
                totalprice = totalprice + x.Quantity * x.Product.Price;
            });
            CartResponseDto cartResponse = new CartResponseDto() { TotalPrice = totalprice };
            cartResponse.Products = _mapper.Map<List<Product>, IList<ProductDto>>(products);
            return cartResponse;
        }
    }
}
