# Four ways to mount VHD

Projects script, console and service use _diskpart_ Microsoft command line to mount/dismount VHD drives, and the files DisMountMyVHDs.txt and MountMyVHDs.txt.
Script and console solutions, can be launched at startup with Windows task scheduler (MyMountVHDTask.xml)

## By script

    DisMountMyVHDs.cmd
    MountMyVHDs.cmd

## By console application

    ConsoleApplication project

## By Windows service

    WindowsService project

## By WindowsForms Application

    WindowsFormsApplication project using Win32 API. Can be run in console mode with -attach -detach options.
    You can use WindowsFormsApplication-Attach.lnk and WindowsFormsApplication-Detach.lnk links