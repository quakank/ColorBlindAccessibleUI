![Color Blind Accessible UI Title](cbauiTitle.png)
#

A Mount & Blade: Bannerlord Mod for providing configurable color options to aid those with color vision deficiencies. With a wide range of built in color options and the ability define and select your own custom color, Color Blind Accessible UI strives to provide support for all CVD needs.

## Features
- Mod Configuration Menu support for configuring colors in game
- 28 built in color options (Color names generated via [Color-Name.com](https://www.color-name.com/))
- Custom color definition
- Configurable UI Elements:
  - Casualty logs (Ally/Enemy kills)
  - Trade Prices (Profits/Losses)
  - Settlement Nameplates for Allied and Enemy settlements
  - Party and Army size numbers on the world map (Ally/Enemy)
  - Standard Information Messages (XP gain, Daily gold changes, etc)
  - Event Notification Messages (Prisoner news, Army creation, Marriages, NPC Lost, etc)
  - Formation popup icons in battle scenes (Ally/Enemy/Player)
  - Various Positive/Negative indicators (Item stat differences, cost differences, etc)
  
## Installation
This mod requires you to have the Harmony and Mod Configuration Menu (and its requirements) mods installed. Always ensure you have the latest versions:
- Harmony ([GitHub](https://github.com/BUTR/Bannerlord.Harmony)/[NexusMods](https://www.nexusmods.com/mountandblade2bannerlord/mods/2006))
- Mod Configuration Menu ([GitHub](https://github.com/Aragas/Bannerlord.MBOptionScreen)/[NexusMods](https://www.nexusmods.com/mountandblade2bannerlord/mods/612))
- ButterLib ([GitHub](https://github.com/BUTR/Bannerlord.ButterLib)/[NexusMods](https://www.nexusmods.com/mountandblade2bannerlord/mods/2018))
- UIExtenderEx ([GitHub](https://github.com/BUTR/Bannerlord.UIExtenderEx)/[NexusMods](https://www.nexusmods.com/mountandblade2bannerlord/mods/2102))

Once installed, ensure your mod load order is as follows:
- Harmony
- ButterLib
- UIExtenderEx
- Mod Configuration Menu
- All Bannerlord Native Modules
- ColorBlindAccessibleUI (does not have to be before or after any additional mods)

## Custom Color Configuration
If the provided colors are not sufficient for your needs or you simply want something different, you can add your own custom colors via the provided configuration file.
- Navigate to "Mount & Blade II Bannerlord/Modules/ColorBlindAccessibleUI/bin/Win64_Shipping_Client"
- Open the `customColors.json` file in your prefered editor
- Note the structure of the existing colors in the file that I've already included as an example
- Place a comma after the last `}` curly bracket and begin a new line with the following:
```
{
  "name": "",
  "hexcode": ""
}
 ```
- Put the name of your new color within the apostrophes in the name field and the hexcode of the color within the apostrophes in the hexcode field
 - You can use a variety of online color pickers such as [this](https://htmlcolorcodes.com/color-picker/) to get the hexcode of a color
- Save the file
- Start Bannerlord
- The new color should now be present in the drop down options in the Mod Config Menu

