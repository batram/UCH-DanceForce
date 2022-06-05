# Dance Force Mod
This is an `Ultimate Chicken Horse` `BepInEx` mod that allows the host to force select a level.
Pressing `R` (dance key) for 1 second while the first player on host stands on a level starts it directly.

Bonus feature: Lets you party on your own.


## Build with dotnet
1. Download the source code of the mod (or use git):
      - https://github.com/batram/UCH-DanceForce/archive/refs/heads/main.zip

2. Extract the folder at a location of your choice (the source code should not be in the `BepInEx` plugins folder)

3. Install dotnet (SDK x64):
      - https://dotnet.microsoft.com/en-us/download

4. Make sure you have BepInEx installed:
      - Download [BepInEx](https://github.com/BepInEx/BepInEx/releases) for your platform (UCH is a x64 program)
      - Put all the contents from the `BepInEx_x64` zip file into your `Ultimate Chicken Horse` folder found via `Steam -> Manage -> Browse Local Files`.

5. Click on the `build.bat` file in the source code folder `UCH-DanceForce-main` you extracted 

## Config and Issues
1. UCH installation path
      - If Ultimate Chicken Horse is not installed at the default steam location, 
  the correct path to the installation needs to be set in `DanceForce.csproj`.
      - You can edit the `DanceForce.csproj` file with any Text editor (e.g. notepad, notepad++). 
      - Replace the file path between `<UCHfolder>` and `</UCHfolder>` with your correct Ultimate Chicken Horse game folder.

            <PropertyGroup>
              <UCHfolder>C:\Program Files (x86)\Steam\steamapps\common\Ultimate Chicken Horse\</UCHfolder>
            </PropertyGroup>
      
      - If the path is wrong you see the following errors during the build:

            ...
            warning MSB3245: Could not resolve this reference. Could not locate the assembly "Assembly-CSharp"
            warning MSB3245: Could not resolve this reference. Could not locate the assembly "UnityEngine"
            ...
            error CS0246: The type or namespace name 'UnityEngine' could not be found
            ...

2. Missing BepInEx
      - If the build errors only metion `BepInEx` and `0Harmony`, check that BepInEx is installed in your game folder
      - Example Errors (no other `MSB3245` warnings):

            warning MSB3245: Could not resolve this reference. Could not locate the assembly "BepInEx"
            warning MSB3245: Could not resolve this reference. Could not locate the assembly "0Harmony"
            ...
            error CS0246: The type or namespace name 'BepInEx' could not be found
            ...
              
      - correct folder structure:

            -> Ultimate Chicken Horse
                   -> BepInEx
                        -> core
                              -> 0Harmony.dll
                              -> ...
                   -> UltimateChickenHorse_Data
                   -> doorstop_config.ini
                   -> ...
                   -> UltimateChickenHorse.exe
                   -> ...
                   -> winhttp.dll


## Credits
- [Clever Endeavour Games](https://www.cleverendeavourgames.com/)
- [BepInEx](https://github.com/BepInEx/BepInEx) team
- [Harmony](https://github.com/pardeike/Harmony) by Andreas Pardeike
