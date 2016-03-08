# Four ways to mount VHD

All projects use _diskpart_ Microsoft command line to mount/dismount VHD drives, and the files DisMountMyVHDs.txt and MountMyVHDs.txt.
Script and console solutions, can be launched at startup with Windows task scheduler (MyMountVHDTask.xml)

## By script

    DisMountMyVHDs.cmd
    MountMyVHDs.cmd

## By console application

    ConsoleApplication project

## By Windows service

    WindowsService project

## By WindowsForms Application

    WindowsFormsApplication project