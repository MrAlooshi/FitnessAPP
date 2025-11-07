import 'package:fitnessapp_frontend/models/muscle_group.dart';

class Exercise {
  String name;
  String? description;
  int? dbId;
  late final List<MuscleGroup> muscleGroups;

  Exercise({
    required this.name,
    this.description,
    this.dbId,
    required this.muscleGroups,
  });

  //   [Key]
  // public int id { get; set; }

  // [Required]
  // public string name { get; set; } = string.Empty; // Fx "Bænkpres", "Squat"

  // // Beskrivelse af, hvordan øvelsen udføres
  // public string? description { get; set; }

  // [Required]
  // [ForeignKey("MuscleGroup")]
  // public int muscleGroupId { get; set; }

  // public MuscleGroup? muscleGroup { get; set; }   // Navigation property til muskelgruppen

  // public DateTime createdAt { get; set; }
  // public DateTime updatedAt { get; set; } //Ved ikke hvis de er nødvendige, men doesnt hurt
  // public bool isDeleted { get; set; }

  // // En øvelse kan være i MANGE programmer
  // public List<ProgramExercise> programExercises { get; set; } = [];
}
