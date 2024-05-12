# Quiz Application

This project is a simple quiz application developed in Unity, featuring multiple scenes and modes, dynamic score updates, and question results displayed in the exit screen. It utilizes CSV files for storing questions and supports three different modes: practical, interview, and theory.

## Scenes

### Menu
The Menu scene serves as the main entry point of the application. It provides two options one is play which is to navigate to different modes of the quiz: practical, interview, or theory and the other is exit.

### Mode Selection
Upon selecting a mode from the Menu scene, the Mode Selection scene allows the user to choose one of the available modes: practical, interview, or theory.

### QuizApp
The QuizApp scene is where the quiz takes place. It dynamically loads questions from CSV files based on the selected mode. Users can answer questions and receive immediate feedback on whether their answer is correct or incorrect. The score is updated dynamically as the user progresses through the quiz.

### ExitScreen
After completing the quiz, users are directed to the ExitScreen scene. Here, they can view their final score and see a detailed breakdown of their answers for each question, including the chosen answer and the correct answer.

## Features

- Utilizes CSV files for storing questions in each mode.
- Supports three modes: practical, interview, and theory.
- Score updates dynamically during the quiz.
- Provides feedback on whether each answer is correct or incorrect.
- Detailed question results displayed in the exit screen.


