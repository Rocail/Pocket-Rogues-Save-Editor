# Save Editor

A simple Pocket Rogues save editor

![image description](screenshot.png)


It is really simple to use :

First, open your game, go to Settings and click "Save (Local)" on the bottom of the screen"

Then, open the Save Editor and load your save file. On PC, it is located in "$GameFolder/Pocket Rogues_Data/PocketRogues Saves" (Usually somthing like "C:\Program Files (x86)\Steam\steamapps\common\Pocket Rogues\Pocket Rogues_Data\PocketRogues Saves")

Once it is loaded, change the values you want and press "Save".

Go back to your game, go to Settings and click "Load (Local)" on the bottom of the screen.

If anything, feel free to open an issue. I may look at it one day.

## How to build an .exe file from the source code

Install Visual Studio 2022

Open a powershell in the project's root folder

Run the following command :
```
msbuild /restore /t:Publish /p:TargetFramework=net7.0-windows10.0.19041.0 /p:configuration=release /p:PublishSingleFile=true /p:WindowsPackageType=None /p:RuntimeIdentifier=win10-x64 /p:PublishReadyToRun=false
```

If it doesn't work because msbuild is missing, try to locate your MSBuild binaries folder (usually something like "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin") and add it to your path, then re-open your powershell