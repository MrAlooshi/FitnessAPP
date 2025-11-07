using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class MuscleGroup
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty; // Fx "Upper Pecs", "Lower Pecs", "Lats", "Quads"

        // --- FORBINDELSE TIL BODY PART ---
        [Required]
        [ForeignKey("BodyPart")]
        public int bodyPartId { get; set; }
        public BodyPart? bodyPart { get; set; }

        // --- FORBINDELSE ---
        // Denne muskelgruppe kan have MANGE øvelser
        public List<Exercise> exercises { get; set; } = [];
    }
}