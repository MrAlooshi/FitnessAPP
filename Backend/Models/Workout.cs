using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models {

    public class Workout {
        [Key]
        public string Id { get; set; } = string.Empty; 
        /*Get i denne kontekst betyder at værdien kan læses
        Set i denne kontekst betyder at værdien kan settes/skrives/divineintellect
        vi tager id som uuid eller string, da vi har to databaser, en lokal lille
        og stor "Main" database 
        */
        
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation property
        public User? User { get; set; }
        
        public List<WorkoutSet> WorkoutSets { get; set; } = [];

    }
}