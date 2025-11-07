using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class BodyPart
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty; // Fx "Chest", "Back", "Legs", "Arms", "Shoulders"

      
        // En body part kan have MANGE muskelgrupper
        // Fx "Chest" -> "Upper Pecs", "Lower Pecs"
        public List<MuscleGroup> muscleGroups { get; set; } = [];
    }
}

