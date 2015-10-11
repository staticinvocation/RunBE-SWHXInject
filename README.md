# SWHXInject

SWHXInject is a simple Windows DLL injector that uses SetWindowHookEx to load a DLL into a remote process.
Current supported remote processes include *ArmA 2: Operation Arrowhead*, *DayZ Standalone*, and *ArmA 3*.
No other games are supported at this time, but feel free to make relevant changes to support it yourself.

## For Users

This software is meant to be used as part of the RunBE software package.
RunBE is a Windows kernel driver that disables certain functionality that may hinder this method of injection from working,
for example, BattlEye's BEDaisy driver that filters DLL files that are loaded into processes it protects.

### Quick-Start

**Note: Only specific DLL files work with SWHXInject. Contact the vendor of the DLL file for compatibility details.**

1. Download binaries of SWHXInject and RunBE and place them in the same folder (preferably on a USB drive).
2. Run SWHXInject.exe.
3. Drag the DLL you wish to inject onto the marked pane on SWHXInject.
4. If the DLL requires it, enter the exported name of the function that contains the hook callback (ask the vendor of the DLL for details).
4. Wait for the confirmation message box to appear.
5. Launch the target game and enjoy.

## For Developers

To add SWHXInject support to your binary, you must make some basic changes to your binary.
Firstly, you need to make a new exported function.

    bool runonce = false;
    extern "C" __declspec(dllexport) int HookEvent(int code, WPARAM wParam, LPARAM lParam) {
        if(!runonce) {
             runonce = true;
             // do DLLMain stuff in here
        }
        return(CallNextHookEx(NULL, code, wParam, lParam));
    }
    
*Note: `HookEvent` can be renamed to anything you want, you just have to specificy the hook function name in SWHX. This is recommended to avoid detection.*

This function will become your new DLLMain.  The other DLLMain really shouldn't do anything except return true.


## License

Copyright (C) 2015 Platinum Digital Group LLC

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

**We strictly enforce our copyright.
Before using any of our code, please familiarize yourself with the GNU General Public License.**
