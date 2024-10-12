using System.ComponentModel.DataAnnotations.Schema;

namespace Merawo.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column(TypeName = "money")]
        public double Cost { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public int BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public int PurchaseId { get; set; }
        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
    }
}
