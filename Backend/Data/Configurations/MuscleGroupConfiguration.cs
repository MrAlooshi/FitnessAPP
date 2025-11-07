using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class MuscleGroupConfiguration : IEntityTypeConfiguration<MuscleGroup>
    {
        public void Configure(EntityTypeBuilder<MuscleGroup> builder)
        {
            builder.ToTable("MuscleGroups");
            
            // Index på foreign key for bedre join performance
            builder.HasIndex(mg => mg.bodyPartId);
        }
    }
}

