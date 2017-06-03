del /q release\*
cd bin\Debug\
"%ProgramFiles%\7-zip\7z" a "..\..\release\EECMT v%1%.zip" EECMT.exe
"%ProgramFiles%\7-zip\7z" a "..\..\release\EECMT v%1%.zip" EECMT.ini
"%ProgramFiles%\7-zip\7z" a "..\..\release\EECMT v%1%.zip" EECMT_cars.ini
"%ProgramFiles%\7-zip\7z" a "..\..\release\EECMT v%1%.zip" readme.txt
"%ProgramFiles%\7-zip\7z" a "..\..\release\EECMT v%1%.zip" EEXMLConverter\
pause
