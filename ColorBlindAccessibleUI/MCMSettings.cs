using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using MCM.UI.Dropdown;
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

        #region Information Messages
        [SettingPropertyDropdown("Information Messages", Order = 1, RequireRestart = false, HintText = "Information messages such as Daily Gold change and XP Gained")]
        [SettingPropertyGroup("Information Messages")]
        public DropdownDefault<CustomColor> InfoMessages { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 7);
        #endregion

        #region Notifications
        [SettingPropertyDropdown("Default Notifications", Order = 1, RequireRestart = false, HintText = "Default notification color")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> DefaultNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 9);

        [SettingPropertyDropdown("Positive Player Faction Notifications", Order = 1, RequireRestart = false, HintText = "Positive events that are related to your faction")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerFactionPositiveNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 10);

        [SettingPropertyDropdown("Positive Player Clan Notifications", Order = 1, RequireRestart = false, HintText = "Positive events that are related to your clan")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerClanPositiveNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 11);

        [SettingPropertyDropdown("Negative Player Faction Notifications", Order = 1, RequireRestart = false, HintText = "Negative events that are related to your faction")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerFactionNegativeNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 12);

        [SettingPropertyDropdown("Negative Player Clan Notifications", Order = 1, RequireRestart = false, HintText = "Negative events that are related to your clan")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerClanNegativeNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 13);

        [SettingPropertyDropdown("Civilian Notifications", Order = 1, RequireRestart = false, HintText = "Civilian event notifications")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> CivilianNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 14);

        [SettingPropertyDropdown("Civilian Player Clan Notifications", Order = 1, RequireRestart = false, HintText = "Civilian events related to your clan")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerClanCivilianNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 15);

        [SettingPropertyDropdown("Civilian Player Faction Notifications", Order = 1, RequireRestart = false, HintText = "Civilian events related to your faction")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerFactionCivilianNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 16);

        [SettingPropertyDropdown("Neutral Notifications", Order = 1, RequireRestart = false, HintText = "Neutral event notifications - such as captured/released/escaped from non-player factions")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> NeutralNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 17);

        [SettingPropertyDropdown("Indirect Positive Player Faction Notifications", Order = 1, RequireRestart = false, HintText = "Positive indirect events related to your faction")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerFactionIndirectPositiveNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 18);

        [SettingPropertyDropdown("Indirect Negative Player Faction Notifications", Order = 1, RequireRestart = false, HintText = "Negative indirect events related to your faction")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerFactionIndirectNegativeNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 19);

        [SettingPropertyDropdown("Political Player Clan Notifications", Order = 1, RequireRestart = false, HintText = "Political events related to your clan")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerClanPoliticalNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 20);

        [SettingPropertyDropdown("Political Player Faction Notifications", Order = 1, RequireRestart = false, HintText = "Political events related to your faction")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PlayerFactionPoliticalNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 21);

        [SettingPropertyDropdown("Political Notifications", Order = 1, RequireRestart = false, HintText = "General political event notifications for non-player factions and clans")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> PoliticalNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 22);

        [SettingPropertyDropdown("Untyped Notifications", Order = 1, RequireRestart = false, HintText = "Untyped notifications")]
        [SettingPropertyGroup("Notification Colors")]
        public DropdownDefault<CustomColor> NoneNotification { get; set; } = new DropdownDefault<CustomColor>(CustomColor.ColorList, 23);
        #endregion

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            ColorBlindAccessibleUI.UpdateColors();
        }
    }
}
