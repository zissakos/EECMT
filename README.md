# EECMT - EgoEngine Camera Modding Tool

This is a generic Camera Modding Tool for (presumably) ALL Codemasters racing games using the EGO Engine (since Dirt 1).
It allows to edit any value for any camera on any car (or a selection thereof), all at once, instantly.
You can backup and restore all the camera files, and even easily package them for publishing them on the internet.

VIDEO: http://www.youtube.com/watch?v=lXR386xL3I8

![Screenshot](https://rawgit.com/zissakos/EECMT/master/EECMT.png)

## INSTALLATION
You can either run the tool from anywhere and chose the game folder with the button "Change" (or paste it and hit "Reload")
OR you can copy all files inside a game folder and start the tool, then it will try to autodetect the game (by searching for all the exe files difined in EECMT.ini).
Check the EECMT.ini if it contains a section for your game. The tool currently supports Dirt 1-3, Dirt Rally, Grid 2, Grid Autosport (these are the games I have).Just copy a section of another game, name it accordingly (name does not matter) and modify it (basically the executable name). 
Also, the car names can optionally be defined in EECMT_cars.ini. 

## USAGE
1. Choose location of your game. 
2. Select cars and cameras you want to change
3. Enter the values you want to change. For numeric values you can even enter "+x" or "-x" to 
   have a relative change instead of an absolute target value! (especially useful for camera offsets)
4. Click Apply. Done.

### Tips:
- For each parameter, the tool shows you the values that currently exist in all camera files in a tooltip
  (so you have a starting point for modding and maybe get an idea about the range of the parameter).
- You can open a car's camera xml file quickly by right-clicking on a car 
  (to find out which camera has which parameters).

## PACKAGING
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
