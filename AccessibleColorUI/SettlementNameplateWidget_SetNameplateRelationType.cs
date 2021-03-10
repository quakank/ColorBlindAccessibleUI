using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Nameplate;

namespace AccessibleColorUI
{
	[HarmonyPatch(typeof(SettlementNameplateWidget), "SetNameplateRelationType")]
	internal class SettlementNameplateWidget_SetNameplateRelationType
	{
		private static bool Prefix(SettlementNameplateItemWidget ____currentNameplate, int type)
		{
			switch (type)
			{
				case 0:
					____currentNameplate.Color = Color.Black;
					return false;
				case 1:
					____currentNameplate.Color = AccessibleColorUISubModule.Config.GetAllyColor();
					return false;
				case 2:
					____currentNameplate.Color = AccessibleColorUISubModule.Config.GetEnemyColor();
					return false;
				default:
					return false;
			}
		}
	}
}
