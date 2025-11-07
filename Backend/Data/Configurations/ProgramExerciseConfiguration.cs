using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class ProgramExerciseConfiguration : IEntityTypeConfiguration<ProgramExercise>
    {
        public void Configure(EntityTypeBuilder<ProgramExercise> builder)
        {
            // Indexes på foreign keys for bedre join performance
            builder.HasIndex(pe => pe.ProgramId);
            builder.HasIndex(pe => pe.ExerciseId);

            // Når en Program slettes, skal ProgramExercises også slettes
            builder.HasOne(pe => pe.Program)
                .WithMany(p => p.ProgramExercises)
                .HasForeignKey(pe => pe.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

