using System.ComponentModel.DataAnnotations;

namespace DotNetCore_Api.Models.RequestModels
{
    public class AddProductRequestDto
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MinLength(15)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int MarkaId { get; set; }
        [Required]
        public int KategoriId { get; set; }
    }
}