using HarmonyLib;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.Library;

namespace AccessibleColorUI
{
    class PartyNameplateVM_IndicatorGetters
    {
		[HarmonyPatch(typeof(PartyNameplateVM), "PositiveIndicator", MethodType.Getter)]
		internal class PartyNameplateVM_PositiveIndicator
		{
			private static void Postfix(ref Color __result)
			{
				__result = Color.Lerp(AccessibleColorUISubModule.Config.GetAllyColor(), Color.White, (float)0.20);
			}
		}

		[HarmonyPatch(typeof(PartyNameplateVM), "NegativeIndicator", MethodType.Getter)]
		internal class PartyNameplateVM_NegativeIndicator
		{
			private static void Postfix(ref Color __result)
			{
				__result = Color.Lerp(AccessibleColorUISubModule.Config.GetEnemyColor(), Color.White, (float)0.20);
			}
		}

		[HarmonyPatch(typeof(PartyNameplateVM), "PositiveArmyIndicator", MethodType.Getter)]
		internal class PartyNameplateVM_PositiveArmyIndicator
		{
			private static void Postfix(ref Color __result)
			{
				__result = Color.Lerp(AccessibleColorUISubModule.Config.GetAllyColor(), Color.White, (float)0.40);
			}
		}

		[HarmonyPatch(typeof(PartyNameplateVM), "NegativeArmyIndicator", MethodType.Getter)]
		internal class PartyNameplateVM_NegativeArmyIndicator
		{
			private static void Postfix(ref Color __result)
			{
				__result = Color.Lerp(AccessibleColorUISubModule.Config.GetEnemyColor(), Color.White, (float)0.40);
			}
		}
	}
}
