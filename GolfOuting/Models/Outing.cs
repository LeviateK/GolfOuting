using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace GolfOuting.Models
{
    public class Outing
    {
        [Display(Name = "Outing ID")]
        public int OutingID { get; set; }

        [Required(ErrorMessage = "Outing Name is Required")]
        [Display(Name = "Outing Name")]
        public string OutingName { get; set; }

        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Year ID")]
        public int YearID { get; set; }

        // Linked Models
        [ForeignKey("YearID")]
        public virtual Year Year { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }

        public List<OutingTeam> OutingTeams { get; set; }



    }
}
