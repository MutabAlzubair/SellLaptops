using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sell_laptops.LMS.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ID { get; set; }

        public Laptop Laptop { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartID { get; set; }


    }
}
