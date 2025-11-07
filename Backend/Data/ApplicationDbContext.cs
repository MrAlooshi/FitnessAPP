using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // --- DbSets for alle modeller ---
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<WorkoutSet> WorkoutSets { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<MuscleGroup> MuscleGroups { get; set; } = null!;
        public DbSet<BodyPart> BodyParts { get; set; } = null!;
        public DbSet<Models.Program> Programs { get; set; } = null!;
        public DbSet<ProgramExercise> ProgramExercises { get; set; } = null!;
        public DbSet<UserProgram> UserPrograms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----- GLOBALE REGLER -----

            // Global query filter for soft delete
            // Automatisk filtrerer IsDeleted = false fra queries
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Workout>().HasQueryFilter(w => !w.IsDeleted);
            modelBuilder.Entity<WorkoutSet>().HasQueryFilter(ws => !ws.IsDeleted);
            modelBuilder.Entity<Exercise>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Models.Program>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProgramExercise>().HasQueryFilter(pe => !pe.IsDeleted);
            modelBuilder.Entity<UserProgram>().HasQueryFilter(up => !up.IsDeleted);

            // Konfigurer string IDs til at bruge varchar i stedet for text (bedre performance)
            ConfigureStringIds(modelBuilder);

            // ----- SPECIFIKKE REGLER -----

            // Denne ene linje finder og kører ALLE dine 
            // IEntityTypeConfiguration-filer i hele projektet.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        private void ConfigureStringIds(ModelBuilder modelBuilder)
        {
            // Alle string IDs skal være varchar med fast længde (UUID er 36 karakterer)
            // Dette giver bedre performance end text/varchar(max)
            var entitiesWithStringIds = new[]
            {
                typeof(User), typeof(Workout), typeof(WorkoutSet),
                typeof(Exercise), typeof(MuscleGroup), typeof(BodyPart),
                typeof(Models.Program), typeof(ProgramExercise), typeof(UserProgram)
            };

            foreach (var entityType in entitiesWithStringIds)
            {
                var entity = modelBuilder.Entity(entityType);
                var idProperty = entity.Property("Id");
                idProperty.HasMaxLength(36); // UUID standard længde
            }
        }

    }
}