TailTool
========

Find todays logs and open them with your preferred tail.exe


Usage:

      tailtool.exe
      -f=<log search path> 
      -a=<csv of anti words> Any fragments of these words will be ignored. useful for -a=trace to ignore trace files
      -h, -?, --help


Set the path to your preferred tailer.exe in app.config. 


  
    <add key="Tailer.SearchPaths" value="C:\DevTools\wintail\WinTail.exe;C:\apps\baretail.exe" />
  

