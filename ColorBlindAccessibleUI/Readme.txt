COLOR BLIND ACCESSIBLE UI - version 1.3.4
Built on Bannerlord 1.0.2 Main Release

This mod provides configurable color options for a variety of UI elements.
Currently configurable UI Elements:
- Casualty logs, Ally/Enemy kills
- Trade prices, Very Good profit, Good profit, neutral, Loss, Bad Loss
- Settlement nameplates for Allied and Enemy settlements
- Party and Army size numbers on the world map, Ally/Enemy
- Various Positive/Negative indicators such as differences in stats on equipment in Trade/Inventory screen
- Standard information messages (XP Gain, Daily Gold Change, etc)
- Event notification messages (Prisoner taken/escaped, Army creation, Marriage, NPC Lost, etc)
- Formation popup icons in battle scenes (Ally, Enemy, Player)

This mod comes packaged with 28 defined color options but provides the ability to define your own
colors for use in the mod. Color names generated via https://www.color-name.com/


INSTALLATION
Unpack the downloaded 7z file to your Modules folder
Unpacking .7z files - https://www.nexusmods.com/mountandblade2bannerlord/articles/423

This mod requires:
Harmony - https://www.nexusmods.com/mountandblade2bannerlord/mods/2006
Mod Configuration Menu - https://www.nexusmods.com/mountandblade2bannerlord/mods/612
ButterLib - https://www.nexusmods.com/mountandblade2bannerlord/mods/2018
UIExtenderEx - https://www.nexusmods.com/mountandblade2bannerlord/mods/2102

Please make sure you have downloaded and installed the correct versions of these mods for your
version of Bannerlord.

Load order should be as follows:
- Harmony
- ButterLib
- UIExtenderEx
- Mod Configuration Menu
- Native
- Sandbox Core
- Sandbox
- StoryMode
- CustomBattle
- ColorBlindAccessibleUI (does not have to be the top of any other mods you have, as long as it follows the TaleWorlds  modules)


USAGE
Usage:
- Once you've installed the mod and its requirements, ordered them properly and ensured they are all enabled, start the game.
- You'll likely see a warning screen about mismatched versions. This is generally okay as some of these mods don't update every single release. Simply click Confirm and continue loading.
- In the Main Menu you should see a Mod Options button, Click it to enter the Mod Config Menu
- Select Color Blind Accessible UI in the left panel
- You will be provided with several sections of options you may now configure. Each option provides a dropdown box to select the color you'd like to set for that UI element. If the dropdown extends below the visible screen, simply use the arrows to the left or right of the dropdown box to navigate through the selections.
- Once you've set your preferences, Click Done
- Load or Start a new game and enjoy your new settings.


CUSTOM COLOR CONFIGURATION
If the provided colors are not sufficient for your needs, or you simply want something different, you can add your own custom colors.
- Navigate to "Mount & Blade II Bannerlord/Modules/ColorBlindAccessibleUI/bin/Win64_Shipping_Client"
- You will see a file named customColors.json, open it in your preferred file editor
- Note the structure of the existing colors in the file as I've included them as an example
- Place a comma after the last } curly bracket and then begin a new line with the following:
﻿{
﻿﻿"name": "",
﻿﻿"hexcode": ""
﻿}
- Put the name of your new color within the apostrophes in the name field and the hexcode of the color within the apostrophes in the hexcode field
﻿- You can use a variety of online color pickers such as https://htmlcolorcodes.com/color-picker/ to get a hexcode for the color you want
- Save the file.
- Start Bannerlord
- In the Mod Options configuration window for Color Blind Accessible UI you should now see your custom color added to the dropdown lists, labeled using the name you provided