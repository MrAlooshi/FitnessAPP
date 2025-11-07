using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class WorkoutSetConfiguration : IEntityTypeConfiguration<WorkoutSet>
    {
        public void Configure(EntityTypeBuilder<WorkoutSet> builder)
        {
            // Indexes på foreign keys for bedre join performance
            builder.HasIndex(ws => ws.UserId);
            builder.HasIndex(ws => ws.WorkoutId);
            builder.HasIndex(ws => ws.ExerciseId);

            // Når en Workout slettes, skal WorkoutSets også slettes
            builder.HasOne(ws => ws.Workout)
                .WithMany(w => w.WorkoutSets)
                .HasForeignKey(ws => ws.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

