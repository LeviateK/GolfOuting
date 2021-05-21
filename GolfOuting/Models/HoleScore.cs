using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class HoleScore
    {
        public int HoleScoreID { get; set; }
        public int OutingTeamID { get; set; }
        public int HoleID { get; set; }
        public int Score { get; set; }
        
        // Linked Models
        [ForeignKey("OutingTeamID")]
        public virtual OutingTeam OutingTeam { get; set; }

        [ForeignKey("HoleID")]
        public virtual Hole Hole { get; set; }



    }
}
