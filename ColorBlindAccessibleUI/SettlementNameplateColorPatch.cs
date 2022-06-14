using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Nameplate;

namespace ColorBlindAccessibleUI
{
	[HarmonyPatch(typeof(SettlementNameplateWidget), "SetNameplateRelationType")]
	internal class SettlementNameplateColorPatch
	{
		private static bool Prefix(SettlementNameplateItemWidget ____currentNameplate, int type)
		{
			switch (type)
			{
				case 0:
					____currentNameplate.Color = Color.Black;
					return false;
				case 1:
					____currentNameplate.Color = GlobalSettings<MCMSettings>.Instance.FriendlyNameplateColor.SelectedValue.Color;
					return false;
				case 2:
					____currentNameplate.Color = GlobalSettings<MCMSettings>.Instance.EnemyNameplateColor.SelectedValue.Color;
					return false;
				default:
					return false;
			}
		}
	}
}
