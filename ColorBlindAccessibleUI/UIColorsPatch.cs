using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Library;

namespace ColorBlindAccessibleUI
{
    [HarmonyPatch(typeof(UIColors), "PositiveIndicator", MethodType.Getter)]
    internal class PositiveIndicatorPatch
    {
        private static bool Prefix(ref Color __result)
        {
            __result = GlobalSettings<MCMSettings>.Instance.PositiveIndicator.SelectedValue.Color;
            return false;
        }
    }

    [HarmonyPatch(typeof(UIColors), "NegativeIndicator", MethodType.Getter)]
    internal class NegativeIndicatorPatch
    {
        private static bool Prefix(ref Color __result)
        {
            __result = GlobalSettings<MCMSettings>.Instance.NegativeIndicator.SelectedValue.Color;
            return false;
        }
    }
}
