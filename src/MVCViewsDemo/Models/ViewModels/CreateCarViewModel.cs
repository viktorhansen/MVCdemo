using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCViewsDemo.Models.ViewModels
{
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Make is required")]
        [Display(Name = "Make")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Number of doors is required")]
        [Range(3, 5, ErrorMessage = "Enter number of doors (3-5)")]
        public int Doors { get; set; }

        [Required(ErrorMessage = "Top speed is required")]
        [Range(1, 300, ErrorMessage = "A car can not be slower than 1km/h and not faster than 300km/h")]
        public int TopSpeed { get; set; }
    }
}
