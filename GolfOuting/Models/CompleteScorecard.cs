using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class CompleteScorecard
    {
        public string TeamName { get; set; }
        public bool InSkins { get; set; }
        public int Hole1Score { get; set; }
        public int Hole2Score { get; set; }
        public int Hole3Score { get; set; }
        public int Hole4Score { get; set; }
        public int Hole5Score { get; set; }
        public int Hole6Score { get; set; }
        public int Hole7Score { get; set; }
        public int Hole8Score { get; set; }
        public int Hole9Score { get; set; }
        public int Hole10Score { get; set; }
        public int Hole11Score { get; set; }
        public int Hole12Score { get; set; }
        public int Hole13Score { get; set; }
        public int Hole14Score { get; set; }
        public int Hole15Score { get; set; }
        public int Hole16Score { get; set; }
        public int Hole17Score { get; set; }
        public int Hole18Score { get; set; }
        public bool Hole1Skin { get; set; }
        public bool Hole2Skin { get; set; }
        public bool Hole3Skin { get; set; }
        public bool Hole4Skin { get; set; }
        public bool Hole5Skin { get; set; }
        public bool Hole6Skin { get; set; }
        public bool Hole7Skin { get; set; }
        public bool Hole8Skin { get; set; }
        public bool Hole9Skin { get; set; }
        public bool Hole10Skin { get; set; }
        public bool Hole11Skin { get; set; }
        public bool Hole12Skin { get; set; }
        public bool Hole13Skin { get; set; }
        public bool Hole14Skin { get; set; }
        public bool Hole15Skin { get; set; }
        public bool Hole16Skin { get; set; }
        public bool Hole17Skin { get; set; }
        public bool Hole18Skin { get; set; }       

        public int RoundScore { get; set; }

    }
}
