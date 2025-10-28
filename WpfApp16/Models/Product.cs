using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp16.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public Supplier? Supplier { get; set; }

    }
}
