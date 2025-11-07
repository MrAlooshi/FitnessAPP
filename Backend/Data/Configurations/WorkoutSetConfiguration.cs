using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class WorkoutSetConfiguration : IEntityTypeConfiguration<WorkoutSet>
    {
        public void Configure(EntityTypeBuilder<WorkoutSet> builder)
        {
            builder.ToTable("WorkoutSets");
            
            // Indexes på foreign keys for bedre join performance
            builder.HasIndex(ws => ws.userId);
            builder.HasIndex(ws => ws.workoutId);
            builder.HasIndex(ws => ws.exerciseId);

            // Når en Workout slettes, skal WorkoutSets også slettes
            builder.HasOne(ws => ws.workout)
                .WithMany(w => w.workoutSets)
                .HasForeignKey(ws => ws.workoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

