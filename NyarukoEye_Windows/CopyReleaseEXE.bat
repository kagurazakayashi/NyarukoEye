echo NyarukoEye
mkdir Build\Release\
echo "copy core"
copy INI\bin\Release\INI.dll Build\Release\INI.dll
copy Shot\bin\Release\Shot.dll Build\Release\Shot.dll
copy Enc\bin\Release\Enc.dll Build\Release\Enc.dll
copy NetUL\bin\Release\NetUL.dll Build\Release\NetUL.dll
copy NetUL\bin\Release\RestSharp.dll Build\Release\RestSharp.dll
copy bin\Release\NyarukoEye_Windows.exe Build\Release\scrchk.exe
copy NELauncher\bin\Release\NELauncher.exe Build\Release\NELauncher.exe
echo "copy tools"
copy KeyTool\bin\Release\KeyTool.exe Build\Release\KeyTool.exe
copy ConfigEditer\bin\Release\ConfigEditer.exe Build\Release\ConfigEditer.exe
copy ConfigEditerServer\bin\Release\ConfigEditerServer.exe Build\Release\ConfigEditerServer.exe
copy NetTool\bin\Release\NetTool.exe Build\Release\NetTool.exe
copy Autorun\bin\Release\Autorun.exe Build\Release\Autorun.exe
copy Installer\bin\Release\Installer.exe Build\Release\Installer.exe
echo "copy server"
copy ..\NyarukoEye_Server\nyarukoeyesev.exe Build\Release\nyarukoeyesev.exe
pause