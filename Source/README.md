## Extract Icons from Exe

 - Install IconView from https://www.botproductions.com/iconview/download.html
 - Find exe, then right click and go to Properties > Icons, save

## Extract Icons from SHELL32.dll

 - Install IconView from https://www.botproductions.com/iconview/download.html
 - Open %SystemRoot%\System32, right click SHELL32.dll and go to Properties > Icons, save

## Add new Helper Project

 - Add a new "Windows Forms App (.NET Framework)" with the name WindowsTaskbarHelpers_XYZ 
(it must be the older .net 4.8 type, otherwise seperate dll is created which is annoying)
 - Delete App.config
 - In project preferences in Release Mode, set Build Output to the "..\..\Apps\" folder and under Output Advanced set to None