using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Program
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        [Required]
        public string Name { get; set; } = string.Empty; // Fx "Min Pull Day", "Push Day"
        
        public string? Description { get; set; } // Valgfri beskrivelse

        // Hvem har oprettet programmet 
        [Required]
        [ForeignKey("CreatorUser")]
        public string CreatorUserId { get; set; } = string.Empty;
        public User? CreatorUser { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // --- FORBINDELSER ---
        // Et program har MANGE øvelses-linjer
        public List<ProgramExercise> ProgramExercises { get; set; } = [];
        
        // Et program kan være i MANGE brugeres biblioteker
        public List<UserProgram> UserPrograms { get; set; } = [];
    }
}

