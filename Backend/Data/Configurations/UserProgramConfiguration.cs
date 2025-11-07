using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class UserProgramConfiguration : IEntityTypeConfiguration<UserProgram>
    {
        public void Configure(EntityTypeBuilder<UserProgram> builder)
        {
            builder.ToTable("UserPrograms");
            
            // Indexes på foreign keys for bedre join performance
            builder.HasIndex(up => up.userId);
            builder.HasIndex(up => up.programId);

            // Unique index (en bruger kan ikke have samme program to gange)
            builder.HasIndex(up => new { up.userId, up.programId })
                .IsUnique();

            // Når et Program slettes, skal UserPrograms også slettes
            builder.HasOne(up => up.program)
                .WithMany(p => p.userPrograms)
                .HasForeignKey(up => up.programId)
                .OnDelete(DeleteBehavior.Cascade);

            // Når en User slettes, skal UserPrograms også slettes
            builder.HasOne(up => up.user)
                .WithMany(u => u.userPrograms)
                .HasForeignKey(up => up.userId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

