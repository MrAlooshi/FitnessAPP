using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class BodyPart
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        [Required]
        public string Name { get; set; } = string.Empty; // Fx "Chest", "Back", "Legs", "Arms", "Shoulders"

        // --- FORBINDELSE ---
        // Et body part kan have MANGE muskelgrupper
        // Fx "Chest" -> "Upper Pecs", "Lower Pecs"
        public List<MuscleGroup> MuscleGroups { get; set; } = [];
    }
}

