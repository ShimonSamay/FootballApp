using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FootballAppEF.Models
{
    public partial class FootballTeamDB : DbContext
    {
        public FootballTeamDB()
            : base("name=FootballTeamDB")
        {
        }
        public virtual DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
