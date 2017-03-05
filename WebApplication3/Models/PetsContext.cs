using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication3.Models
{
    public class PetsContext: DbContext
    {
        public PetsContext():base("PetsContext")
        {
            Database.SetInitializer<PetsContext>(null);
        }

        public DbSet<Pets> Pets { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}