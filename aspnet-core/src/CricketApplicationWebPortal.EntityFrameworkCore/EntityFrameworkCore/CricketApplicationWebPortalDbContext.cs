using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CricketApplicationWebPortal.Authorization.Roles;
using CricketApplicationWebPortal.Authorization.Users;
using CricketApplicationWebPortal.MultiTenancy;
using CricketApplicationWebPortal.Models;

namespace CricketApplicationWebPortal.EntityFrameworkCore
{
    public class CricketApplicationWebPortalDbContext : AbpZeroDbContext<Tenant, Role, User, CricketApplicationWebPortalDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<BattingStyle> BattingStyles { get; set; }
        public DbSet<PlayerRole> PlayerRoles { get; set; }
        public DbSet<BowlingStyle> BowlingStyles { get; set; }
        public CricketApplicationWebPortalDbContext(DbContextOptions<CricketApplicationWebPortalDbContext> options)
            : base(options)
        {
        }
    }
}
