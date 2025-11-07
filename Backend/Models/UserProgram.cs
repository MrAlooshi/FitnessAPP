using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    // Dette er en "join-tabel" (many-to-many)
    // Den forbinder Users og Programs
    public class UserProgram
    {
        [Key]
        public string Id { get; set; } = string.Empty; // UUID som string

        // Hvilken bruger har dette program i sit bibliotek?
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }

        // Hvilket program er det?
        [Required]
        [ForeignKey("Program")]
        public string ProgramId { get; set; } = string.Empty;
        public Program? Program { get; set; }

        // Hvornår tilføjede de det?
        public DateTime AddedAt { get; set; }

        public bool IsDeleted { get; set; } = false; // Sæt standard til 'false'
    }
}

