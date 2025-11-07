using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        
        [Required]
        public string Username { get; set; } = string.Empty; // Unikt navn til visning

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty; // Unik email til login
        
        // Bemærk: Selve "password" gemmes ikke her.
        // Det håndteres af ASP.NET Identity 

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } // Til "soft delete"

        // --- FORBINDELSER ---
        // En bruger kan have MANGE workouts
        public List<Workout> Workouts { get; set; } = [];

        // En bruger kan have MANGE workout sets
        // (Dette giver en direkte vej, selvom de også hænger på en Workout)
        public List<WorkoutSet> WorkoutSets { get; set; } = [];

        // En bruger kan have oprettet MANGE programmer
        public List<Program> CreatedPrograms { get; set; } = [];

        // En bruger kan have MANGE programmer i sit bibliotek (inkl. delte)
        public List<UserProgram> UserPrograms { get; set; } = [];
    }
}