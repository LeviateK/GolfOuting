using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GolfOuting.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        // Linked Tables
        //[ForeignKey("PlayerID")]
        //public virtual TeamPlayer TeamPlayer { get; set; }

        //[ForeignKey("PlayerID")]
        //public virtual SkillShot SkillShot { get; set; }
    }
}
