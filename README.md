#STEP (Suspension Telemetry Program) v1.0
STEP is a program for create graphics of telemetry data colected from arduino system that will be installed in a Formula SAE car.
The objective of this project is study the suspension system thecnical features, its weakness and limits. With all this data collected, we'll know how to improve the suspension in our actual project or in the future projects.

##Arduino System
The Arduino setup for this project will be really simple to decrease the cost and also to avoid adding unecessary weight and complexity to the electrical/eletronic system of the car.
We'll use the Arduino Uno R3 for running the code and the Arduino Accelerometer and Giroscopy MPU6050. This configuration will delivery data with a great precision if we put the sensor in the car's center of mass.
The MPU6050 also have a temperature sensor, maybe in the future we'll use this for mantain control of the temperature near the engine (behind the firewall).

##Data registration
MPU6050 module has a really high default sensitivity, and this is one cause of instability. For reduce this, I'll need to reduce this sensitivity, or find a way to treat this oscilation in the program (STEP). 
The second option it more interesting, because we'll have more control of the analisys of the test without affecting the precision of the test.

##What is Escuderia UFJF?
Escuderia UFJF is a Formula SAE team based in Juiz de Fora (MG) - Brazil. The team represents the Federal University of Juiz de Fora (Universidade Federal de Juiz de Fora) in the nacional FSAE scenery.
We are in the way to build our second car (the first to compete), and the goal this year is to improve our tecnical knowledge about the aplication of out project and improve our car for the next national championship.


