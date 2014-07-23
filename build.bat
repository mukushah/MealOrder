C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild .\build.xml /t:CompileTest
del testResults.trx
"c:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\MSTest.exe" /testcontainer:.\TestOrder\bin\Debug\TestOrder.dll /resultsfile:testResults.trx