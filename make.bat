set path=C:\Program Files\Microsoft Visual Studio 8\Common7\IDE;C:\Program Files\Microsoft Visual Studio 8\VC\BIN;C:\Program Files\Microsoft Visual Studio 8\Common7\Tools;C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\bin;C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727;C:\Program Files\Microsoft Visual Studio 8\VC\VCPackages;C:\program files\texmf\miktex\bin;C:\WINDOWS\system32;C:\WINDOWS;C:\WINDOWS\System32\Wbem;C:\Program Files\Executive Software\Diskeeper\;C:\Program Files\Subversion\bin;c:\Program Files\Java\jdk1.5.0_06\bin\
mkdir "bin"

pushd .
cd src\BindingListView
msbuild /p:Configuration=Release;OutDir=..\..\bin\
popd

