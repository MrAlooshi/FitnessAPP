using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models {

    public class Workout {
        [Key]
        public int id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }
        
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool isDeleted { get; set; }

        // Navigation property
        public User? user { get; set; }
        
        public List<WorkoutSet> workoutSets { get; set; } = [];

    }
}