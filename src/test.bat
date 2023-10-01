set filter=""
set env="dev"

IF DEFINED %1 SET env=%1
IF DEFINED %2 SET filter=%2

dotnet test --filter %filter% -e env=%env%

reports.bat