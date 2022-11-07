using HarmonyLib;
using MCM.Abstractions.Base.Global;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.LogEntries;
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

    /// <summary>
    /// General info messages like daily gold tick, xp gain, level gain, etc
    /// </summary>
    [HarmonyPatch(typeof(InformationMessage), MethodType.Constructor, new Type[] { typeof(string) })]
    internal class InformationMessagePatch
    {
        private static void Postfix(InformationMessage __instance)
        {
            __instance.Color = GlobalSettings<MCMSettings>.Instance.InfoMessages.SelectedValue.Color;
        }
    }

    [HarmonyPatch(typeof(InformationMessage), MethodType.Constructor, new Type[] { typeof(string), typeof(string) })]
    internal class InformationMessagePatch2
    {
        private static void Postfix(InformationMessage __instance)
        {
            __instance.Color = GlobalSettings<MCMSettings>.Instance.InfoMessages.SelectedValue.Color;
        }
    }

    /// <summary>
    /// Event notifications such as prisoner events, army events, marriage, etc
    /// </summary>
    [HarmonyPatch(typeof(DefaultDiplomacyModel), "GetNotificationColor")]
    internal class DefaultDiplomacyModelPatch
    {
        private static bool Prefix(ref ChatNotificationType notificationType, ref uint __result)
        {
            if (GlobalSettings<MCMSettings>.Instance == null)
                return true;

            switch (notificationType)
            {
                case ChatNotificationType.Default:
                    __result = GlobalSettings<MCMSettings>.Instance.DefaultNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerFactionPositive:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerFactionPositiveNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerClanPositive:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerClanPositiveNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerFactionNegative:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerFactionNegativeNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerClanNegative:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerClanNegativeNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.Civilian:
                    __result = GlobalSettings<MCMSettings>.Instance.CivilianNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerClanCivilian:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerClanCivilianNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerFactionCivilian:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerFactionCivilianNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.Neutral:
                    __result = GlobalSettings<MCMSettings>.Instance.NeutralNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerFactionIndirectPositive:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerFactionIndirectPositiveNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerFactionIndirectNegative:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerFactionIndirectNegativeNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerClanPolitical:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerClanPoliticalNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.PlayerFactionPolitical:
                    __result = GlobalSettings<MCMSettings>.Instance.PlayerFactionPoliticalNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                case ChatNotificationType.Political:
                    __result = GlobalSettings<MCMSettings>.Instance.PoliticalNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
                default:
                    __result = GlobalSettings<MCMSettings>.Instance.NoneNotification.SelectedValue.Color.ToUnsignedInteger();
                    break;
            }
            return false;
        }
    }
}
