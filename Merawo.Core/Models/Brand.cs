using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merawo.Core.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string SellingCountry { get; set; }
        public List<Product> Products { get; set; }
    }
}
