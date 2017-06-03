--------------------------------------
EECMT - Ego Engine Camera Modding Tool
--------------------------------------

by zissakos, April 2017


This is a generic Camera Modding Tool for (presumably) ALL Codemasters racing games using the EGO Engine (since Dirt 1).
It allows to edit any value for any camera on any car (or a selection thereof), all at once, instantly.
You can backup and restore all the camera files, and even easily package them for publishing them on the internet.


INSTALLATION
============
Run the tool from anywhere. Check the EECMT.ini if it contains a section for your game. 
The tool currently supports Dirt 1-3, Dirt Rally, Grid 2, Grid Autosport (these are the games I have).
Just copy a section of another game, name it accordingly (name does not matter) and modify it (basically the executable name).

Also, the car names can optionally be defined in EECMT_cars.ini. 
Just add a section for your game (section name in [] has to match the section name in EECMT.ini) 
and then one line for each car in the format "xxx = CARNAME" where xxx is the 3digit car folder name 
containing the cameras.xml file in the subfolder cars/models of the game.


USAGE
=====

1. Choose location of your game. 
2. Select cars and cameras you want to change
3. Enter the values you want to change. For numeric values you can even enter "+x" or "-x" to 
   have a relative change instead of an absolute target value! (especially useful for camera offsets)
4. Click Apply. Done.

Tips:
- For each parameter, the tool shows you the values that currently exist in all camera files in a tooltip
  (so you have a starting point for modding and maybe get an idea about the range of the parameter).
- You can open a car's camera xml file quickly by right-clicking on a car 
  (to find out which camera has which parameters).


HOW IT WORKS
============
After step 1 the tool tries to identify the game by searching all executable files defined in 
all sections in the EECMT.ini in the chosen folder. If one is found, the game (=section name in []) 
is found and shown in the window title. It then reads all camera files and if the game uses binaryXML 
(according to the parameter binaryXML = true/false in the ini) - it seems all games after Dirt 1 use binaryXML -
it converts them to plain XML and saves them as "cameras.xml.plain.xml".
That's why it can take up to 5 seconds to load all the cars & cameras.

As soon as you hit the APPLY button, the changes are made in the plainXML file and then 
it is being converted back to the binaryXML file that the game expects 
(that's why APPLY can take some seconds as well).

For this a binaryXML converter is needed. I have provided a pretty fast one in the 
subfolder EEXMLConverter, which is already set up in EECMT.ini.
You can change that anytime and use some other converter by editing EECMT.ini 
(path and command line parameters). The converter must take at least the two parameters <infile> and <outfile>.


BACKUP
======
As soon as you load a game for the first time, EECMT is going to ask you to make a backup.
This is a very good idea so you can restore it anytime, and also for packaging (see below).
Notice the buttons BACKUP and RESTORE in the upper right corner.
Backup files are created as "cameras.xml.backup" next to the original file.


PACKAGING
=========
Once you are done modding and want to publish your camera mod for others to download, 
you can hit the PACKAGE button. It will ask you to specify a folder, and then it will create 
two folders in that: MODDED_FILES and ORIGINAL_FILES. Inside them you will find the 
whole cars/models structure containing the cameras.xml files. You can then tell your users 
(in some readme file) to just extract the "MODDED_FILES\cars" folder into their game folder 
and overwrite any files. If they want to revert the changes, they can do the same with the 
ORIGINAL_FILES\cars folder. The files for that folder are taken from you backup files.
That's why it is important to make a backup as a first step, to make sure that these 
really are the original game files.
Add a readme file, zip the whole thing and publish it. 


VERSION HISTORY
===============
1.0 2017-04-18 
    * initial version