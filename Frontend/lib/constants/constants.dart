import 'package:fitnessapp_frontend/models/muscle_group.dart';
import 'package:flutter/material.dart';

class Constants {
  static final ThemeData darkTheme = ThemeData(
    colorScheme: const ColorScheme(
      brightness: Brightness.dark,
      primary: Color(0xFFBB86FC), // Purple
      onPrimary: Colors.black,
      secondary: Color(0xFF03DAC6), // Teal accent
      onSecondary: Colors.black,
      error: Color(0xFFCF6679),
      onError: Colors.black,
      surface: Color(0xFF1E1E1E),
      onSurface: Colors.white,
    ),
    scaffoldBackgroundColor: const Color(0xFF121212),
    textTheme: const TextTheme(bodyMedium: TextStyle(color: Colors.white)),
  );

  // static const List<MuscleGroup> muscleGroups = [
  //   MuscleGroup(name: "Biceps", dbId: 0),
  //   MuscleGroup(name: "Triceps", dbId: 1),
  //   MuscleGroup(name: "Delts", dbId: 2),
  //   MuscleGroup(name: "Chest", dbId: 3),
  // ];

  static const List<MuscleGroup> muscleGroups = [
    MuscleGroup(name: "Biceps", dbId: 0),
    MuscleGroup(name: "Triceps", dbId: 1),
    MuscleGroup(name: "Delts", dbId: 2),
    MuscleGroup(name: "Chest", dbId: 3),

    MuscleGroup(name: "Upper Chest", dbId: 4),
    MuscleGroup(name: "Lower Chest", dbId: 5),

    MuscleGroup(name: "Front Delts", dbId: 6),
    MuscleGroup(name: "Side Delts", dbId: 7),
    MuscleGroup(name: "Rear Delts", dbId: 8),

    MuscleGroup(name: "Upper Back", dbId: 9),
    MuscleGroup(name: "Lats", dbId: 10),
    MuscleGroup(name: "Lower Back", dbId: 11),

    MuscleGroup(name: "Traps", dbId: 12),

    MuscleGroup(name: "Abs", dbId: 13),
    MuscleGroup(name: "Obliques", dbId: 14),

    MuscleGroup(name: "Glutes", dbId: 15),
    MuscleGroup(name: "Quads", dbId: 16),
    MuscleGroup(name: "Hamstrings", dbId: 17),
    MuscleGroup(name: "Calves", dbId: 18),

    MuscleGroup(name: "Forearms", dbId: 19),
  ];
}