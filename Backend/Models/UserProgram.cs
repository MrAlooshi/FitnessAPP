using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    // Dette er en "join-tabel" (many-to-many)
    // Den forbinder Users og Programs
    public class UserProgram
    {
        [Key]
        public int id { get; set; }

        // Hvilken bruger har dette program i sit bibliotek?
        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }
        public User? user { get; set; }

        // Hvilket program er det?
        [Required]
        [ForeignKey("Program")]
        public int programId { get; set; }
        public Program? program { get; set; }

        // WHEN WAS THIS ADDED!?!?!? så man kan se hvornår folk tilføjer program
        public DateTime addedAt { get; set; }

        public bool isDeleted { get; set; } = false; // Sæt standard til 'false'
    }
}

