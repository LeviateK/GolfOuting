using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class TeamPlayer
    {
        public int TeamPlayerID { get; set; }
        public int TeamID { get; set; }
        public int PlayerID { get; set; }

        // Linked Models
        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }

        [ForeignKey("PlayerID")]
        public virtual Player Player { get; set; }
    }
}
