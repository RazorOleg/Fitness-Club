using System.Data.Entity;

namespace DataBase
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("FitnessClubDB") 
        {
            //Database.SetInitializer<FitnessContext>(new DropCreateDatabaseAlways<FitnessContext>());
            Configuration.LazyLoadingEnabled = false; 
        }
        public DbSet<ClubEntity> Clubs { get; set; }
        public DbSet<ClubPassEntity> ClubsPass { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WorkoutEntity> Workouts { get; set; }

        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubEntity>()
                .HasMany(c => c.ClubPasses)
                .WithRequired(o => o.Club);
            modelBuilder.Entity<ClubEntity>()
                .HasMany(c => c.Workouts)
                .WithRequired(o => o.Club);
            modelBuilder.Entity<ClubPassEntity>()
                .HasMany(c => c.Clients)
                .WithOptional(o => o.ClubPass);
            modelBuilder.Entity<WorkoutEntity>()
                .HasMany(c => c.Clients)
                .WithOptional(o => o.Workout);
        }
    }
}
