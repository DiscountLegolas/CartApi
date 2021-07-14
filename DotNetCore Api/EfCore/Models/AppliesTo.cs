namespace DotNetCore_Api.EfCore.Models
{
    public class AppliesTo
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public int FilterId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Filter Filter { get; set; }
    }
}