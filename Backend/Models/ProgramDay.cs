using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    /// <summary>
	/// A program day has a list of exercises.
	/// </summary>
    public class ProgramDay
    {
        [Key]
        public int id { get; set; }

        public List<Exercise> exercises = [];
        // [Required]
        // public string name { get; set; } = string.Empty; // Fx "Min Pull Day", "Push Day"
        
        // public string? description { get; set; } // Valgfri beskrivelse

        // // Hvem har oprettet programmet 
        // [Required]
        // [ForeignKey("CreatorUser")]
        // public int creatorUserId { get; set; }
        // public User? creatorUser { get; set; }

        // public DateTime createdAt { get; set; }
        // public DateTime updatedAt { get; set; }
        // public bool isDeleted { get; set; }

        // // --- FORBINDELSER ---
        // // Et program har MANGE øvelser
        // public List<ProgramExercise> programExercises { get; set; } = [];
        
        // // Et program kan være i MANGE brugeres biblioteker
        // public List<UserProgram> userPrograms { get; set; } = [];
    }
}

