sc.exe create HostedService BinPath=$PSScriptRoot\HostedService.exe;
sc.exe start HostedService

#Для удаления файла
#sc.exe stop HostedService
#sc.exe delete HostedService