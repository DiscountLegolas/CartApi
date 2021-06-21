using System.ComponentModel.DataAnnotations;

namespace DotNetCore_Api.Models
{
    public class UpdateProductRequestDto
    {
        [Required]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MarkaId { get; set; }
        public int KategoriId { get; set; }
    }
}