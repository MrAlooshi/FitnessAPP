using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models {

    public class WorkoutSet {

        [Key]
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        [ForeignKey("Exercise")]
        public string ExerciseId { get; set; } = string.Empty;
        
        public int Reps { get; set; }
        public double Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
         
        // gemmer "Id" fra den Workout, den hører til
        [Required]
        [ForeignKey("Workout")]
        public string WorkoutId { get; set; } = string.Empty;

        // Navigation properties
        public User? User { get; set; }
        public Exercise? Exercise { get; set; }
        
        //Navigation property (tilbage til "forælderen")
        // Dette hjælper EF med at forstå forbindelsen.
        public Workout? Workout { get; set; }

    }
}