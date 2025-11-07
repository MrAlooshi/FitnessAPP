using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class MuscleGroup
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        [Required]
        public string Name { get; set; } = string.Empty; // Fx "Upper Pecs", "Lower Pecs", "Lats", "Quads"

        // --- FORBINDELSE TIL BODY PART ---
        [Required]
        [ForeignKey("BodyPart")]
        public string BodyPartId { get; set; } = string.Empty;
        public BodyPart? BodyPart { get; set; }

        // --- FORBINDELSE ---
        // Denne muskelgruppe kan have MANGE øvelser
        public List<Exercise> Exercises { get; set; } = [];
    }
}