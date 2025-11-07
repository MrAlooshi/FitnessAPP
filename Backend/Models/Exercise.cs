using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public class Exercise
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        [Required]
        public string Name { get; set; } = string.Empty; // Fx "Bænkpres", "Squat"

        // Beskrivelse af, hvordan øvelsen udføres
        public string? Description { get; set; } 

        [Required]
        [ForeignKey("MuscleGroup")]
        public string MuscleGroupId { get; set; } = string.Empty;
        // Navigation property til muskelgruppen
        // En øvelse har et primært fokus på én muskelgruppe
        public MuscleGroup? MuscleGroup { get; set; }

        // Disse er vigtige, så app'en ved, om den skal downloade
        // nye/opdaterede øvelser fra serveren.
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // En øvelse kan være i MANGE programmer
        public List<ProgramExercise> ProgramExercises { get; set; } = [];
    }
}