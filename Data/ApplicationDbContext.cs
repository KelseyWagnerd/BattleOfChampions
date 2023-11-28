using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BattleOfChampions.Models;

namespace BattleOfChampions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach(var relationship in builder.Model.GetEntityTypes().SelectMany(f => f.GetReferencingForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }
        public DbSet<BattleOfChampions.Models.Champion> Champion { get; set; }
        public DbSet<BattleOfChampions.Models.Equipment> Equipment { get; set; }
    }
}