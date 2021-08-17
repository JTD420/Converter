@echo off
mkdir C:\Tools\Converted_Files\Furni_Icons
copy C:\Tools\DownloadHabbo\hof_furni\icons\*.* C:\Tools\Converted_Files\Furni_Icons\*.*
cd c:\Tools\Convert
npm run start