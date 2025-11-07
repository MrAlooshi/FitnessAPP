using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class UserProgramConfiguration : IEntityTypeConfiguration<UserProgram>
    {
        public void Configure(EntityTypeBuilder<UserProgram> builder)
        {
            // Indexes på foreign keys for bedre join performance
            builder.HasIndex(up => up.UserId);
            builder.HasIndex(up => up.ProgramId);

            // Composite unique index (en bruger kan ikke have samme program to gange)
            builder.HasIndex(up => new { up.UserId, up.ProgramId })
                .IsUnique();

            // Når en Program slettes, skal UserPrograms også slettes
            builder.HasOne(up => up.Program)
                .WithMany(p => p.UserPrograms)
                .HasForeignKey(up => up.ProgramId)
                .OnDelete(DeleteBehavior.Cascade);

            // Når en User slettes, skal UserPrograms også slettes
            builder.HasOne(up => up.User)
                .WithMany(u => u.UserPrograms)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

