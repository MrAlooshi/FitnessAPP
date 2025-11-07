using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        
        [Required]
        public string username { get; set; } = string.Empty; // Unikt navn til visning

        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty; // Unik email til login
        
        // Selve password gemmes ikke her
        // Det håndteres af ASP.NET Identity 

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool isDeleted { get; set; } // Til "soft delete"

        // --- FORBINDELSER ---
        // En bruger kan have MANGE workouts
        public List<Workout> workouts { get; set; } = [];

        // En bruger kan have MANGE workout sets
        public List<WorkoutSet> workoutSets { get; set; } = [];

        // En bruger kan have oprettet MANGE programmer
        public List<Program> createdPrograms { get; set; } = [];

        // En bruger kan have MANGE programmer i sit bibliotek (inkl. delte)
        public List<UserProgram> userPrograms { get; set; } = [];
    }
}