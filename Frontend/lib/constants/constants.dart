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
}