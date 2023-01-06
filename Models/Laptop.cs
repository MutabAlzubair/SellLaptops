using sell_laptops.LMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sell_laptops.LMS.Models
{
    public class Laptop
    {
        [Key]
        public int ID { get; set; }
        

        [Display(Name= "Laptop image name")]
        [Required (ErrorMessage ="Name of image is required")]
        public int ImageCode { get; set; }
        

        [Display(Name = "Laptop/Item name")]
        [Required(ErrorMessage = "Name of Laptop is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 40 chars")] // V:32
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Choose category")]
        public LaptopCategory LaptopCategory { get; set; }
    }
}
