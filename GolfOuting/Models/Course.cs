using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        // Linked Models
        [ForeignKey("CourseID")]
        public virtual Outing Outing { get; set; }

        public ICollection<Hole> Holes { get; set; }
    }
}
