# Silent BT Awake

Silent BT Awake is a lightweight Windows utility that keeps your computer’s Bluetooth connection "awake" in the background.  
Addresses multiple second playback delay introduced in windows 11. Seems to solve 90% of the delay problems but issue may still persist.

## Things to try before:
0. Check if you have multiple bluetooth devices. Go to Bluetooth devices -> device and printer settings. If you have multiple and one has warning, disable it.
1. go to your headphones settings and disable hands free telephony
2. go to system sound, disable hands free microphone and speakers for your headphones.
3. Go to windows update -> advanced -> optional updates, check there is bluetooth driver update.
   
## Quick Install
0. You may need to download .NET runtime from [.NET Framework runtime](https://dotnet.microsoft.com/en-us/download/dotnet-framework)
1. **Download the latest release or build from scratch in Visual Studio** from [GitHub Releases](https://github.com/nunuvin/silent_bt_awake/releases).
2. **Extract the ZIP** and run `SilentBTAwake.exe`.
3. The app will appear as an icon in your system tray and keep Bluetooth awake automatically.

4. To start with Windows, add a shortcut to `SilentBTAwake.exe` in your Startup folder (`Win + R → shell:startup`).


## Antivirus detections
Some heuristics seem to mark this (ML false positives). You can reach out to AV vendor so they can fix the heuristics. Also you can whitelist this application in AV.
PS VirusTotal is your friend


