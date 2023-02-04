===========STEP-REPORT=========
-Briefing
1) Open file from windows explorer
2) Load the information from the file
3) Create a graphic from the file
	- For creating the graphic, we need to set de range of data and study how to display it in a readable way
	- I need to create the axis
	- There will be two kinds of graphics (for while): the Linear and the G-G diagram.
		- For the g-g diagram, I need to set the null value in the center of the screen, and all the points around this center
4) Print the graphic in the screen
	5) Create the G-G graphic or the linear graphic of a axis of the movement 


#Report 01/09:
	- I'm trying to improve the display of information in the screen by adding a proportional rate based in the interval of the values in the data file. 
	- doing this, we'll have a dinamyc graphic, with more flexibility: will be possible to have precise analisys or more global analisys. Just by filtering the data entered in the software
		- For the longitudinal radio, the program will calculate the interval (the difference between the lowerest and the highest value) and will divide that by the size of the screen. 
		- For the latitudinal radio, the program will do the same as the longitudinal radio (for the G-g diagram) or will linearly divide the space on the screen between the data to be displayed.

	- Probably I'll need to add a slider above the graphic, for zooming, and also for scrooling side to side, up and down.
	- I increased the data from the file to 1440 points (approximately the data that will be catched in one minute of test) and the software is working well... but not ideal. The slider is a must to turn this at least readable.
	
#Report 21/11:
	- Lots of thing happened since the last report, I'll try to list some of them:
		- change language for the program: C# to python (python is much simpler for ploting the graphic, probably I will need to build a interface in near future - but it'snt the priority by now)
		- I got a data set from internet to test the plot, but the data set was created in a ventilator - so the data is not related to our propuse.
		- I built the arduino system required and did some tests (in my car on the UF campus - and some in the highway)
			- The tests were successful, some of then I wrote on .txt and .csv (are in the repository)
			- Problems: I don't know wich sensitivity I used
				- I forgot to do a test with sensor in standby (for measure the flutuation caused by the sensitivity)
	- What's working right now:
		- The graphic plotation: axis X, Y and Z (individualy), axis XYZ (together), diagramGG
		
	- What it'snt working:
		- The graphic plotation: track estimation
	
	- What are the nexts steps:
		- Gravity compensation (there is a github repo about this)
		- Axy rotation (I need to understand the sensor behaviour / car position)

#Report 06/12
	- I'll try to use euler angles for gravity compensation:
		- I need to multiply the vector gravity (0,0,GRAVITY) by the rotation matriz.
		- So, I need to calculate angles for all positions, simply by adding Xi for i = 0...n


#Report 03/02 
	- For calculate the zero velocity update, I need to calculate the tangent between a point and other... but my samples has problems about with the time registration.
	- Also, I need unterstand where is the "zero" for each 
		- I can do that by calculanting the avarage acceleration measured
		
		