using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Dropdown;
using MCM.Abstractions.Settings.Base.Global;
using System.Runtime.CompilerServices;

namespace ColorBlindAccessibleUI
{
    public class MCMSettings : AttributeGlobalSettings<MCMSettings>
    {
        public override string Id => "ColorBlindAccessibleUI";

        public override string DisplayName => "Color Blind Accessible UI";

        public override string FolderName => "ColorBlindAccessibleUI";

        public override string FormatType => "json2";

        #region Trade Price Text Colors
        [SettingPropertyDropdown("Good Profit", Order = 2, RequireRestart = false, HintText = "Color of text when trading at a profit")]
        [SettingPropertyGroup("Trade Price Colors")]
        public DropdownDefault<CustomColor> TradePriceGood { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 4);

        [SettingPropertyDropdown("Very Good Profit", Order = 1, RequireRestart = false, HintText = "Color of text when trading at a high profit")]
        [SettingPropertyGroup("Trade Price Colors")]
        public DropdownDefault<CustomColor> TradePriceVeryGood { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 4);

        [SettingPropertyDropdown("Bad Loss", Order = 4, RequireRestart = false, HintText = "Color of text when trading at a loss")]
        [SettingPropertyGroup("Trade Price Colors")]
        public DropdownDefault<CustomColor> TradePriceBad { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 6);

        [SettingPropertyDropdown("Very Bad Loss", Order = 5, RequireRestart = false, HintText = "Color of text when trading at a big loss")]
        [SettingPropertyGroup("Trade Price Colors")]
        public DropdownDefault<CustomColor> TradePriceVeryBad { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 6);

        [SettingPropertyDropdown("Default", Order = 3, RequireRestart = false, HintText = "Default color of trade price")]
        [SettingPropertyGroup("Trade Price Colors")]
        public DropdownDefault<CustomColor> TradePriceNeutral { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 7);

        #endregion

        #region Casualty Log Background Colors
        [SettingPropertyDropdown("Friendly Kill Color", Order = 1, RequireRestart = false, HintText = "Color of the log when an enemy is killed or knocked unconscious")]
        [SettingPropertyGroup("Casualty Log Colors")]
        public DropdownDefault<CustomColor> CasualtyLogAlly { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 4);

        [SettingPropertyDropdown("Enemy Kill Color", Order = 2, RequireRestart = false, HintText = "Color of the log when an ally is killed or knocked unconscious")]
        [SettingPropertyGroup("Casualty Log Colors")]
        public DropdownDefault<CustomColor> CasualtyLogEnemy { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 6);

        #endregion

        #region Settlement and Party Nameplate Colors

        [SettingPropertyDropdown("Friendly Settlement", Order = 1, RequireRestart = false, HintText = "Background color of allied settlement names")]
        [SettingPropertyGroup("Settlement and Party Nameplates")]
        public DropdownDefault<CustomColor> FriendlyNameplateColor { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 4);

        [SettingPropertyDropdown("Enemy Settlement", Order = 3, RequireRestart = false, HintText = "Background color of enemy settlement names")]
        [SettingPropertyGroup("Settlement and Party Nameplates")]
        public DropdownDefault<CustomColor> EnemyNameplateColor { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 6);

        [SettingPropertyDropdown("Friendly Party", Order = 2, RequireRestart = false, HintText = "Color of allied party size")]
        [SettingPropertyGroup("Settlement and Party Nameplates")]
        public DropdownDefault<CustomColor> FriendlyPartyColor { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 4);

        [SettingPropertyDropdown("Enemy Party", Order = 4, RequireRestart = false, HintText = "Color of enemy party size")]
        [SettingPropertyGroup("Settlement and Party Nameplates")]
        public DropdownDefault<CustomColor> EnemyPartyColor { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 6);
        #endregion

        #region Various Indicators
        [SettingPropertyDropdown("Positive Indicator", Order = 1, RequireRestart = false, HintText = "Color of Positive Indicator for various UI Elements")]
        [SettingPropertyGroup("Various UI Indicators")]
        public DropdownDefault<CustomColor> PositiveIndicator { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 4);

        [SettingPropertyDropdown("Negative Indicator", Order = 2, RequireRestart = false, HintText = "Color of Negative Indicator for various UI Elements")]
        [SettingPropertyGroup("Various UI Indicators")]
        public DropdownDefault<CustomColor> NegativeIndicator { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 6);
        #endregion

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            ColorBlindAccessibleUI.UpdateColors();
        }
    }
}
