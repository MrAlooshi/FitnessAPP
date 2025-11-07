using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.ToTable("Workouts");
            
            // Index på foreign key for bedre join performance
            builder.HasIndex(w => w.userId);

            // Når en User slettes, skal deres Workouts også slettes
            builder.HasOne(w => w.user)
                .WithMany(u => u.workouts)
                .HasForeignKey(w => w.userId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

