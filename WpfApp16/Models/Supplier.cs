﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp16.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string ?Name { get; set; }
        public string ?Phone { get; set; }
        public string? Email { get; set; }

    }
}
