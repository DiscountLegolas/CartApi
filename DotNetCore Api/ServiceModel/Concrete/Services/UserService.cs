using DotNetCore_Api.EfCore.Models;
using DotNetCore_Api.Models.ResponseModels;
using DotNetCore_Api.Repotutories.Abstract;
using DotNetCore_Api.ServiceModel.Abstract;
using DotNetCore_Api.ServiceModel.Abstract.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Api.ServiceModel.Concrete
{
    public class UserService:IUserService
    {
        private IFavoriteRepo _favoriteRepo;
        private ICategoryRepository _categoryRepository;
        private ICartRepository _cartrepository;
        private IProductRepo _productrepo;
        private IUserRepo _userRepo;
        public UserService(ICartRepository cartrepository,IProductRepo productRepo,IUserRepo userRepo,ICategoryRepository categoryRepository,IFavoriteRepo favoriteRepo)
        {
            _favoriteRepo = favoriteRepo;
            _categoryRepository = categoryRepository;
            _userRepo = userRepo;
            _productrepo = productRepo;
            _cartrepository = cartrepository;
        }

        public List<Product> AddandRemoveFavori(int userıd, int productıd)
        {
            return _favoriteRepo.AddandRemoveFavori(userıd, productıd);
        }
        public List<Product> FilterProductList(List<Filter> filters, int categoryıd)
        {
            var prodocuts = _categoryRepository.GetKategoriProducts(categoryıd);
            return prodocuts.ToList();
        }

        public List<Product> GetFavoris(int userıd)
        {
            throw new NotImplementedException();
        }

        public List<Kategori> GetRecomendedCategories(int userıd)
        {
            var recomended = _categoryRepository.GetUsersMostUsedKategoris(userıd);
            return recomended.ToList();
        }
        public LoginUserResponseDto Login(User user)
        {
            LoginUserResponseDto responseDto = new LoginUserResponseDto();
            try
            {
                var a= _userRepo.LoginUser(user);
                if (a.HasValue)
                {
                    user.UserId = a.Value;
                    responseDto.User = user;
                    return responseDto;
                }
                else
                {
                    responseDto.Message = "Credentials False";
                    return responseDto;
                }
            }
            catch (Exception e)
            {
                responseDto.Message = e.Message;
                return responseDto;
            }
        }

        public AddUserResponseDto Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
