import 'dart:async';
import 'package:fitnessapp_frontend/constants/constants.dart';
import 'package:fitnessapp_frontend/database/database.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatefulWidget {
  const MainApp({super.key});

  @override
  State<MainApp> createState() => _MainAppState();
}

class ExerciseWithMuscles {
  Exercise exercise;
  List<Muscle> muscles;

  ExerciseWithMuscles({required this.exercise, required this.muscles});
}

class _MainAppState extends State<MainApp> {
  final double defaultSpacing = 40;
  List<Muscle> selectedMuscles = [];
  String selectedExerciseName = "Unnamed";
  final TextEditingController _exerciseNameController = TextEditingController();
  final Database db = Database();
  late final List<Muscle> allMuscles;

  late final List<ExerciseWithMuscles> allExerciseWithMuscles;

  @override
  void initState() {
    super.initState();
    // db.deleteAllExercises();
    _loadMuscles();
    _loadExercises();
  }

  Future<void> _loadMuscles() async {
    final muscles = await db.select(db.muscles).get();

    setState(() {
      allMuscles = muscles;
    });
  }

  Future<void> _loadExercises() async {
    // final exercises = await db.select(db.exercises).get();
    final exerciseMuscleRelations = await db.select(db.exerciseMuscles).get();
    final List<ExerciseWithMuscles> exercisesWithMuscles = [];
    print("this happened real");
    print(exerciseMuscleRelations.length);
    for(ExerciseMuscle exerciseMuscle in exerciseMuscleRelations) { 
      print("Vind");
      
      Exercise? exercise = await (
        db.select(db.exercises)..where((obj) => obj.id.equals(exerciseMuscle.exerciseId))
      ).getSingleOrNull();

      if(exercise == null) {
        continue;
      }

      List<Muscle> muscles = await(
        db.select(db.muscles)..where((obj) => obj.id.equals(exerciseMuscle.muscleId))
      ).get();

      exercisesWithMuscles.add(ExerciseWithMuscles(exercise: exercise, muscles: muscles));
    }

    setState(() {
      allExerciseWithMuscles = exercisesWithMuscles;
    });
  }

  int currentPageIndex = 0;

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: Constants.darkTheme,
      home: Scaffold(
        bottomNavigationBar: NavigationBar(
          onDestinationSelected: (int index) {
            setState(() {
              currentPageIndex = index;
            });
          },
          selectedIndex: currentPageIndex,
          destinations: [
            NavigationDestination(icon: Icon(Icons.add), label: "Add exercises"),
            NavigationDestination(icon: Icon(Icons.view_stream), label: "View exercises")
          ]
        ),
        body: <Widget>[
          _buildAddMuscleGroup(), 
          _buildViewExercises(),
        ][currentPageIndex]
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
        for (Muscle muscle in allMuscles)
          Row(
            children: [
              ElevatedButton(
                onPressed: () {
                  setState(() {
                    !selectedMuscles.contains(muscle)
                        ? selectedMuscles.add(muscle)
                        : selectedMuscles.remove(muscle);
                  });
                },
                child: Text(muscle.name),
              ),
              if (selectedMuscles.contains(muscle)) Icon(Icons.check),
            ],
          ),
        selectedMuscles.isEmpty
            ? ElevatedButton(onPressed: null, child: Text("Add"))
            : ElevatedButton(
                onPressed: () async {
                  print(selectedExerciseName);
                  print(selectedMuscles);
                  await db.addExercise(selectedExerciseName, selectedMuscles.map((element) => element.name).toList());
                  final exercises = await db.select(db.exercises).get();

                  final addedExercises = exercises.where(
                    (obj) => obj.name == selectedExerciseName
                  );

                  for(var exercise in addedExercises) {
                    print(exercise.name + " " + exercise.id.toString());
                  }

                  if(addedExercises.length > 1) {
                    throw Exception("Found ${addedExercises.length} exercises with the same name");
                  }
                  final addedExercise = addedExercises.first;

                  allExerciseWithMuscles.add(ExerciseWithMuscles(exercise: addedExercise, muscles: selectedMuscles));

                  setState(() {
                    _exerciseNameController.text = "";
                    selectedExerciseName = "Unnamed";
                    selectedMuscles = [];
                  });
                },
                child: Text("Add"),
              ),
      ],
    );
  }
// allExerciseWithMuscles
  Widget _buildViewExercises() {
    String _getTrainedMuscleGroups(ExerciseWithMuscles exerciseWithMuscles) {
      String muscles = "";

      for (Muscle muscle in exerciseWithMuscles.muscles) {
        muscles += muscle.name.toLowerCase();
        muscles += ", ";
      }
      return muscles;
    }

    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      spacing: defaultSpacing / 2,
      children: [
        Text("View exercise:"),
        for (ExerciseWithMuscles exerciseWithMuscles in allExerciseWithMuscles)
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            spacing: defaultSpacing / 2,
            children: [
              Text(
                '${exerciseWithMuscles.exercise.name} trains: ${_getTrainedMuscleGroups(exerciseWithMuscles)}',
              ),
            ],
          ),
      ],
    );
  }
}
