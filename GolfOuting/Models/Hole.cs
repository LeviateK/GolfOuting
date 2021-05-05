using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class Hole
    {
        [Display(Name = "Hole ID")]
        public int HoleID { get; set; }

        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Hole Number")]
        public int HoleNumber { get; set; }

        [Display(Name = "Par")]
        public int Par { get; set; }

        [Display(Name = "Men's Yardage")]
        public int MenYardage { get; set; }

        [Display(Name = "Women's Yardage")]
        public int WomenYardage { get; set; }

        // Linked Models
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        public ICollection<HoleScore> HoleScores { get; set; }

    }
}
