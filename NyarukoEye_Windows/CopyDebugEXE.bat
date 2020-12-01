echo NyarukoEye
mkdir Build\Debug\
echo "copy core"
copy INI\bin\Debug\INI.dll Build\Debug\INI.dll
copy INI\bin\Debug\INI.pdb Build\Debug\INI.pdb
copy Shot\bin\Debug\Shot.dll Build\Debug\Shot.dll
copy Shot\bin\Debug\Shot.pdb Build\Debug\Shot.pdb
copy Enc\bin\Debug\Enc.dll Build\Debug\Enc.dll
copy Enc\bin\Debug\Enc.pdb Build\Debug\Enc.pdb
copy NetUL\bin\Debug\NetUL.dll Build\Debug\NetUL.dll
copy NetUL\bin\Debug\NetUL.pdb Build\Debug\NetUL.pdb
copy NetUL\bin\Debug\RestSharp.dll Build\Debug\RestSharp.dll
copy NetUL\bin\Debug\RestSharp.xml Build\Debug\RestSharp.xml
copy bin\Debug\NyarukoEye_Windows.exe Build\Debug\scrchk.exe
copy bin\Debug\NyarukoEye_Windows.pdb Build\Debug\scrchk.pdb
copy NELauncher\bin\Debug\NELauncher.exe Build\Debug\NELauncher.exe
copy NELauncher\bin\Debug\NELauncher.pdb Build\Debug\NELauncher.pdb
echo "copy tools"
copy KeyTool\bin\Debug\KeyTool.exe Build\Debug\KeyTool.exe
copy KeyTool\bin\Debug\KeyTool.pdb Build\Debug\KeyTool.pdb
copy ConfigEditer\bin\Debug\ConfigEditer.exe Build\Debug\ConfigEditer.exe
copy ConfigEditer\bin\Debug\ConfigEditer.pdb Build\Debug\ConfigEditer.pdb
copy ConfigEditerServer\bin\Release\ConfigEditerServer.exe Build\Debug\ConfigEditerServer.exe
copy ConfigEditerServer\bin\Release\ConfigEditerServer.pdb Build\Debug\ConfigEditerServer.pdb
copy NetTool\bin\Debug\NetTool.exe Build\Debug\NetTool.exe
copy NetTool\bin\Debug\NetTool.pdb Build\Debug\NetTool.pdb
copy Autorun\bin\Debug\Autorun.exe Build\Debug\Autorun.exe
copy Autorun\bin\Debug\Autorun.pdb Build\Debug\Autorun.pdb
copy Installer\bin\Debug\Installer.exe Build\Debug\Installer.exe
copy Installer\bin\Debug\Installer.pdb Build\Debug\Installer.pdb
echo "copy server"
copy ..\NyarukoEye_Server\nyarukoeyesev.exe Build\Debug\nyarukoeyesev.exe
pause