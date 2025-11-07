using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class ProgramConfiguration : IEntityTypeConfiguration<Models.Program>
    {
        public void Configure(EntityTypeBuilder<Models.Program> builder)
        {
            builder.ToTable("Programs");
            
            // Index på foreign key for bedre join performance
            builder.HasIndex(p => p.creatorUserId);
        }
    }
}

