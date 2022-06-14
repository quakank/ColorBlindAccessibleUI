using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace ColorBlindAccessibleUI
{
    [HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "friendlyColor", MethodType.Getter)]
    internal class FriendlyCasualtyLogPatch
    {
        private static bool Prefix(ref Color __result)
        {
            __result = GlobalSettings<MCMSettings>.Instance.CasualtyLogAlly.SelectedValue.Color;
            return false;
        }
    }

    [HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "enemyColor", MethodType.Getter)]
    internal class EnemyCasualtyLogPatch
    {
        private static bool Prefix(ref Color __result)
        {
            __result = GlobalSettings<MCMSettings>.Instance.CasualtyLogEnemy.SelectedValue.Color;
            return false;
        }
    }
}
