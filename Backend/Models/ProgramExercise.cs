using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class ProgramExercise
    {
        [Key]
        public int id { get; set; }

        // Hvilket program hører den til?
        [Required]
        [ForeignKey("Program")]
        public int programId { get; set; }
        public Program? program { get; set; }

        // Hvilken øvelse er det?
        [Required]
        [ForeignKey("Exercise")]
        public int exerciseId { get; set; }
        public Exercise? exercise { get; set; }

        // Mål for sæt og reps (vi bruger string til reps, så man kan skrive "8-10")
        public int targetSets { get; set; }
        
        [Required]
        public string targetReps { get; set; } = string.Empty;

        // Sørger for at øvelserne vises i den rigtige rækkefølge
        public int sortOrder { get; set; }

        public bool isDeleted { get; set; } = false; // Sæt standard til 'false'
    }
}

