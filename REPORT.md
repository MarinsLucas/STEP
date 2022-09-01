===========STEP-REPORT=========
-Briefing
1) Open file from windows explorer
2) Load the information from the file
3) Create a graphic from the file
	- For creating the graphic, we need to set de range of data and study how to display it in a readable way
	- I need to create the axys
	- There will be two kinds of graphics (for while): the Linear and the G-G diagram.
		- For the g-g diagram, I need to set the null value in the center of the screen, and all the points around this center
4) Print the graphic in the screen
	5) Create the G-G graphic or the linear graphic of a axys of the movement 


Report 01/09:
	- I'm trying to improve the display of information in the screen by adding a proportional rate based in the interval of the values in the data file. 
	- doing this, we'll have a dinamyc graphic, with more flexibility: will be possible to have precise analisys or more global analisys. Just by filtering the data entered in the software
		- For the longitudinal radio, the program will calculate the interval (the difference between the lowerest and the highest value) and will divide that by the size of the screen. 
		- For the latitudinal radio, the program will do the same as the longitudinal radio (for the G-g diagram) or will linearly divide the space on the screen between the data to be displayed.

	- Probably I'll need to add a slider above the graphic, for zooming, and also for scrooling side to side, up and down.
	- I increased the data from the file to 1440 points (approximately the data that will be catched in one minute of test) and the software is working well... but not ideal. The slider is a must to turn this at least readable.