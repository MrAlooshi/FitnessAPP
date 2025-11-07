using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class ProgramExercise
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        // Hvilket program hører denne linje til?
        [Required]
        [ForeignKey("Program")]
        public string ProgramId { get; set; } = string.Empty;
        public Program? Program { get; set; }

        // Hvilken øvelse er det?
        [Required]
        [ForeignKey("Exercise")]
        public string ExerciseId { get; set; } = string.Empty;
        public Exercise? Exercise { get; set; }

        // Mål for sæt og reps (vi bruger string til reps, så man kan skrive "8-10")
        public int TargetSets { get; set; }
        
        [Required]
        public string TargetReps { get; set; } = string.Empty;

        // Sørger for at øvelserne vises i den rigtige rækkefølge
        public int SortOrder { get; set; }

        public bool IsDeleted { get; set; } = false; // Sæt standard til 'false'
    }
}

