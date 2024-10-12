using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Merawo.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string DocumentNumber { get; set; }
        [Column(TypeName = "varchar(30)")]
        public Document DocumentType { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
