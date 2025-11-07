using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class BodyPartConfiguration : IEntityTypeConfiguration<BodyPart>
    {
        public void Configure(EntityTypeBuilder<BodyPart> builder)
        {
            // BodyPart er en simpel reference tabel, ingen specifik konfiguration nødvendig
        }
    }
}

