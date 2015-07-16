TailTool
========

Find the most recent logs (usually today's logs) and open them with your preferred tail.exe


Usage:

      tailtool.exe
      -f=<log search path> 
      -a=<csv of anti words> Any fragments of these words will be ignored. useful for -a=trace to ignore trace files
      -x=<csv or filename patterns> A comma or semicolon separated list of filename patterns to match (eg. *.log,*.txt)
      -s Force all log files to be passed as a single argument to your tail tool (eg. if it supports files in tabs)
      -h, -?, --help

Default filename extension to match is *.log if not specified.

Set the path to your preferred tailer.exe in app.config. 


  
    <add key="Tailer.SearchPaths" value="C:\DevTools\wintail\WinTail.exe;C:\apps\baretail.exe" />
  

