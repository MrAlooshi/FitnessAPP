using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models {

    public class WorkoutSet {

        [Key]
        public int id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }
        
        [Required]
        [ForeignKey("Exercise")]
        public int exerciseId { get; set; }
        
        public int reps { get; set; }
        public double weight { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool isDeleted { get; set; }
         
        // gemmer "Id" fra den Workout, den hører til
        [Required]
        [ForeignKey("Workout")]
        public int workoutId { get; set; }

        // Navigation properties
        public User? user { get; set; }
        public Exercise? exercise { get; set; }
        
        //Navigation property (tilbage til "forælderen")
        // Dette hjælper EF med at forstå forbindelsen.
        public Workout? workout { get; set; }

    }
}