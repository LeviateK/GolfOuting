using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int PairingOrder { get; set; }
        public bool Skins { get; set; }
        public bool Mulligans { get; set; }


        public List<TeamPlayer> TeamPlayers { get; set;}

        public List<OutingTeam> OutingTeams { get; set; }
    }
}
