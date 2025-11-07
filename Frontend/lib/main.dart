import 'package:fitnessapp_frontend/constants/constants.dart';
import 'package:fitnessapp_frontend/models/exercise.dart';
import 'package:fitnessapp_frontend/models/muscle_group.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatefulWidget {
  const MainApp({super.key});

  @override
  State<MainApp> createState() => _MainAppState();
}

class _MainAppState extends State<MainApp> {
  final double defaultSpacing = 40;
  List<MuscleGroup> selectedMuscleGroups = [];
  String selectedExerciseName = "Unnamed";
  final List<Exercise> createdExercises = [];
  final TextEditingController _exerciseNameController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: Constants.darkTheme,
      home: Scaffold(
        body: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          spacing: defaultSpacing,
          children: [_buildAddMuscleGroup(), _buildViewExercises()],
        ),
      ),
    );
  }

  Widget _buildAddMuscleGroup() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text("Create an exercise"),
        SizedBox(
          width: 100,
          child: TextField(
            controller: _exerciseNameController,
            onChanged: (userInput) {
              selectedExerciseName = userInput;
            },
          ),
        ),
        for (MuscleGroup muscleGroup in Constants.muscleGroups)
          Row(
            children: [
              ElevatedButton(
                onPressed: () {
                  setState(() {
                    !selectedMuscleGroups.contains(muscleGroup)
                        ? selectedMuscleGroups.add(muscleGroup)
                        : selectedMuscleGroups.remove(muscleGroup);
                  });
                },
                child: Text(muscleGroup.name),
              ),
              if (selectedMuscleGroups.contains(muscleGroup)) Icon(Icons.check),
            ],
          ),
        selectedMuscleGroups.isEmpty
            ? ElevatedButton(onPressed: null, child: Text("Add"))
            : ElevatedButton(
                onPressed: () {
                  print(selectedExerciseName);
                  print(selectedMuscleGroups);
                  setState(() {
                    createdExercises.add(
                      Exercise(
                        name: selectedExerciseName,
                        muscleGroups: selectedMuscleGroups,
                      ),
                    );
                    _exerciseNameController.text = "";
                    selectedExerciseName = "Unnamed";
                    selectedMuscleGroups = [];
                  });
                },
                child: Text("Add"),
              ),
      ],
    );
  }

  Widget _buildViewExercises() {
    String _getTrainedMuscleGroups(Exercise exercise) {
      String muscles = "";

      for (MuscleGroup muscleGroup in exercise.muscleGroups) {
        muscles += muscleGroup.name.toLowerCase();
        muscles += ", ";
      }
      return muscles;
    }

    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      spacing: defaultSpacing / 2,
      children: [
        Text("View exercise:"),
        for (Exercise exercise in createdExercises)
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            spacing: defaultSpacing / 2,
            children: [
              Text(
                '${exercise.name} trains: ${_getTrainedMuscleGroups(exercise)}',
              ),
            ],
          ),
      ],
    );
  }
}
