TailTool
========

Find today's logs and open them with your preferred tail.exe


Usage:

      tailtool.exe
      -f=<log search path> 
      -a=<csv of anti words> Any fragments of these words will be ignored. useful for -a=trace to ignore trace files
      -s Force all log files to be passed as a single argument to your tail tool (eg. if it supports files in tabs)
      -h, -?, --help


Set the path to your preferred tailer.exe in app.config. 


  
    <add key="Tailer.SearchPaths" value="C:\DevTools\wintail\WinTail.exe;C:\apps\baretail.exe" />
  

