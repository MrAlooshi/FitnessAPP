using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class ProgramExerciseConfiguration : IEntityTypeConfiguration<ProgramExercise>
    {
        public void Configure(EntityTypeBuilder<ProgramExercise> builder)
        {
            builder.ToTable("ProgramExercises");
            
            // Indexes på foreign keys for bedre join performance
            builder.HasIndex(pe => pe.programId);
            builder.HasIndex(pe => pe.exerciseId);

            // Når en Program slettes, skal ProgramExercises også slettes
            builder.HasOne(pe => pe.program)
                .WithMany(p => p.programExercises)
                .HasForeignKey(pe => pe.programId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

