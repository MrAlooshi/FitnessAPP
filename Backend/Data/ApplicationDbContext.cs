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
        public DbSet<User> users { get; set; } = null!;
        public DbSet<Workout> workouts { get; set; } = null!;
        public DbSet<WorkoutSet> workoutSets { get; set; } = null!;
        public DbSet<Exercise> exercises { get; set; } = null!;
        public DbSet<MuscleGroup> muscleGroups { get; set; } = null!;
        public DbSet<BodyPart> bodyParts { get; set; } = null!;
        public DbSet<Models.Program> programs { get; set; } = null!;
        public DbSet<ProgramExercise> programExercises { get; set; } = null!;
        public DbSet<UserProgram> userPrograms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----- GLOBALE REGLER -----

            // Global query filter for soft delete
            // Automatisk filtrerer IsDeleted = false fra queries
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.isDeleted);
            modelBuilder.Entity<Workout>().HasQueryFilter(w => !w.isDeleted);
            modelBuilder.Entity<WorkoutSet>().HasQueryFilter(ws => !ws.isDeleted);
            modelBuilder.Entity<Exercise>().HasQueryFilter(e => !e.isDeleted);
            modelBuilder.Entity<Models.Program>().HasQueryFilter(p => !p.isDeleted);
            modelBuilder.Entity<ProgramExercise>().HasQueryFilter(pe => !pe.isDeleted);
            modelBuilder.Entity<UserProgram>().HasQueryFilter(up => !up.isDeleted);

            // ----- SPECIFIKKE REGLER -----

            // Denne ene linje finder og kører ALLE dine 
            // IEntityTypeConfiguration-filer i hele projektet.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}