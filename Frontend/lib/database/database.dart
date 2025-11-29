import 'package:drift/drift.dart';
import 'package:drift_flutter/drift_flutter.dart';
import 'package:path_provider/path_provider.dart';
import 'package:flutter/material.dart' hide Table;

// to build this part: dart run build_runner build
part 'database.g.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: FutureBuilder(
        future: _initDatabase(),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Scaffold(
              body: Center(child: CircularProgressIndicator()),
            );
          } else if (snapshot.hasError) {
            return Scaffold(
              body: Center(child: TextFormField(initialValue: '${snapshot.error}',)),
            );
          } else {
            return const Scaffold(
              body: Center(child: Text('db is ready')),
            );
          }
        },
      ),
    );
  }

  Future<void> _initDatabase() async {
    final db = Database();
    // await db.addExercise("Bicep curls", ["Vindmuscle", "Biceps"]);
    // await db.addExercise("Bench press", ["Chest", "Triceps", "Front Delts"]);


    final exerciseMuscles = await db.select(db.exerciseMuscles).get();
    // print(exerciseMuscles.length);
    
    final muscles = await db.select(db.muscles).get();
    
    final exercises = await db.select(db.exercises).get();

    for(var exerciseMuscle in exerciseMuscles) {
      print("muscleId:" + exerciseMuscle.muscleId.toString());
      // print("\n");
      print("exerciseId:" + exerciseMuscle.exerciseId.toString());
    }
  }
}

class Exercises extends Table {
  IntColumn get id => integer().autoIncrement()();
  TextColumn get name => text().withDefault(Constant("Unnamed"))();
}

class Muscles extends Table {
  IntColumn get id => integer().autoIncrement()();
  TextColumn get name => text().withDefault(Constant("Unnamed"))();
}

class ExerciseMuscles extends Table {
  IntColumn get exerciseId => integer().references(Exercises, #id)();
  IntColumn get muscleId => integer().references(Muscles, #id)();
}

@DriftDatabase(tables: [Exercises, Muscles, ExerciseMuscles])
class Database extends _$Database {
  Database([QueryExecutor? executor]) : super(executor ?? _openConnection());

  Future<bool> addExercise(String exerciseName, List<String> muscleNames) async {
    List<Muscle> selectResults = [];
  
    for(String muscleName in muscleNames) {
      var muscles = await (this.select(this.muscles)..where((muscle) => muscle.name.equals(muscleName))).get();
      if(muscles.isEmpty) {
        throw Exception("$muscleName is not in the muscles table.");
        // continue;
      }

      if(muscles.length > 1) {
        String exceptionMessage = "";
        for(Muscle muscle in muscles) {
          exceptionMessage += "name: ${muscle.name}";
          exceptionMessage += "id: ${muscle.id.toString()}\n";
        }
        throw Exception("Two muscles have the same name \n$exceptionMessage");
      }

      selectResults.add(
        muscles.elementAt(0)
      );
    }

    if(selectResults.isEmpty) {
      return false;
    }

    final transactionResult = await this.transaction(() async {
      final int exerciseId = await this.into(this.exercises).insert(ExercisesCompanion(
        name: Value(exerciseName)
      ));

      for(Muscle muscle in selectResults) {
        await this.into(this.exerciseMuscles).insert(ExerciseMusclesCompanion(
          exerciseId: Value(exerciseId),
          muscleId: Value(muscle.id)
        ));
      }

      // // This version is better, but I don't want to use it
      // await db.batch((batch) {
      //   batch.insertAll(
      //     db.exerciseMuscles, 
      //     selectResults.map(((muscle) => ExerciseMusclesCompanion.insert(
      //       exerciseId: exerciseId, 
      //       muscleId: muscle.id
      //     )))
      //   );
      // });
    });

    if(transactionResult != null) {
      return true;
    }
    return false;
  }


  @override
  int get schemaVersion => 1;

  static QueryExecutor _openConnection() {
    return driftDatabase(
      name: "my_database",
      native: const DriftNativeOptions(
        databaseDirectory: getApplicationSupportDirectory
      ),
      web: DriftWebOptions(
        sqlite3Wasm: Uri.parse('sqlite3.wasm'),
        driftWorker: Uri.parse('drift_worker.js'),
        onResult: (result) {
          if (result.missingFeatures.isNotEmpty) {
            debugPrint(
              'Using ${result.chosenImplementation} due to unsupported '
              'browser features: ${result.missingFeatures}',
            );
          }
        }
      ),
    );
  }

  @override
  MigrationStrategy get migration {
    return MigrationStrategy(
      onCreate: (m) async {
        await m.createAll();

        await batch((batch) {
          batch.insertAll(
            this.muscles, 
              [
                // Chest
                MusclesCompanion(name: Value("Chest")),
                
                // Back
                MusclesCompanion(name: Value("Upper Back")),
                MusclesCompanion(name: Value("Lats")),
                MusclesCompanion(name: Value("Lower Back")),
                
                // Shoulders
                MusclesCompanion(name: Value("Front Delts")),
                MusclesCompanion(name: Value("Side Delts")),
                MusclesCompanion(name: Value("Rear Delts")),
                MusclesCompanion(name: Value("Traps")),
                
                // Arms
                MusclesCompanion(name: Value("Biceps")),
                MusclesCompanion(name: Value("Triceps")),
                MusclesCompanion(name: Value("Forearms")),
                
                // Legs
                MusclesCompanion(name: Value("Quadriceps")),
                MusclesCompanion(name: Value("Hamstrings")),
                MusclesCompanion(name: Value("Glutes")),
                MusclesCompanion(name: Value("Calves")),
                
                // Core
                MusclesCompanion(name: Value("Abs")),
                MusclesCompanion(name: Value("Obliques"))
              ]
            );
          },
        );
      },
    );
  }
}