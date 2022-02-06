using System.ComponentModel.DataAnnotations;

namespace shopapp.webui.Models
{
    public class ___Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Ürün ismi için 10-60 arası karakter girmelisiniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fiyat girmelisiniz.")] [Range(1, 10000)] public double? Price { get; set; }//required görmesi için nullable yaptık nullable olmasa oto 0 yapıyor çünkü
        public string Description { get; set; }
        [Required] public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        [Required] public int? CategoryId { get; set; }//required görmesi için nullable yaptık nullable olmasa oto 0 yapıyor çünkü
    }
}