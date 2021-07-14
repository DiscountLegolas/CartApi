namespace DotNetCore_Api.EfCore.Models
{
    public class Seçenek
    {
        public int SeçenekId { get; set; }
        public string Yazı { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}