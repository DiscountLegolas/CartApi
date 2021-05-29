using System.Collections.Generic;

namespace CartApi.Models
{
    public class CartViewModel
    {
        public double TotalPrice
        {
            get;
            set;
        }
        public List<ProductViewModel> ProductsInCart { get;set; }
    }
}