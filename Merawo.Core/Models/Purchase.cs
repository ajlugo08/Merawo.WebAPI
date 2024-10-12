using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merawo.Core.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Detail { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
    }
}
