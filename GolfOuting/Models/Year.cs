using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class Year
    {
        [Display(Name = "Year ID")]
        public int YearID { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Year")]
        public int YearValue { get; set; }
    }
}
