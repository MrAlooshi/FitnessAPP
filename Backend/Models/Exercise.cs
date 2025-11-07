using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public class Exercise
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty; // Fx "Bænkpres", "Squat"

        // Beskrivelse af, hvordan øvelsen udføres
        public string? description { get; set; } 

        [Required]
        [ForeignKey("MuscleGroup")]
        public int muscleGroupId { get; set; }
      
       
        public MuscleGroup? muscleGroup { get; set; }   // Navigation property til muskelgruppen

       
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; } //Ved ikke hvis de er nødvendige, men doesnt hurt
        public bool isDeleted { get; set; }

        // En øvelse kan være i MANGE programmer
        public List<ProgramExercise> programExercises { get; set; } = [];
    }
}