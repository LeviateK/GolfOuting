using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GolfOuting.Data
{
    public class GolfOutingContext : DbContext
    {
        public GolfOutingContext(DbContextOptions<GolfOutingContext> options)
            : base(options)
        {

        }
        #region DataTables

        public DbSet<GolfOuting.Models.Outing> Outing { get; set; }
        public DbSet<GolfOuting.Models.Year> Year { get; set; }
        public DbSet<GolfOuting.Models.Course> Course { get; set; }
        public DbSet<GolfOuting.Models.Hole> Hole { get; set; }
        public DbSet<GolfOuting.Models.HoleScore> HoleScore { get; set; }
        public DbSet<GolfOuting.Models.SkillShot> SkillShot { get; set; }
        public DbSet<GolfOuting.Models.OutingTeam> OutingTeam { get; set; }
        public DbSet<GolfOuting.Models.Team> Team { get; set; }
        public DbSet<GolfOuting.Models.TeamPlayer> TeamPlayer { get; set; }
        public DbSet<GolfOuting.Models.Player> Player { get; set; }


        #endregion

    }
}
