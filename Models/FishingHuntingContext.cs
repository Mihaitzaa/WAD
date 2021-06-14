using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingHunting.Models
{
    public class FishingHuntingContext : IdentityDbContext<IdentityUser>
    {
        public FishingHuntingContext(DbContextOptions<FishingHuntingContext> options)
           : base(options)
        {

        }
        public DbSet<Hunting> Hunting { get; set; }
        public DbSet<HuntingPlace> HuntingPlace { get; set; }
        public DbSet<Fishing> Fishing { get; set; }
        public DbSet<FishingPlace> FishingPlace { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
    }
}
