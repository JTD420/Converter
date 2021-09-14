@echo off
mkdir D:\Tools\Converted_Files\Furni_Icons
copy D:\Tools\DownloadHabbo\hof_furni\icons\*.* C:\Tools\Converted_Files\Furni_Icons\*.*
cd D:\Tools\Convert
npm run start
