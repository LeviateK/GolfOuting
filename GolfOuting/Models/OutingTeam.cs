using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class OutingTeam
    {
        public int OutingTeamID { get; set; }
        public int OutingID { get; set; }
        public int TeamID { get; set; }

        // Linked Models
        [ForeignKey("OutingID")]
        public virtual Outing Outing { get; set; }

        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }

        [ForeignKey("OutingTeamID")]
        public virtual HoleScore HoleScore { get; set; }
    }
}
