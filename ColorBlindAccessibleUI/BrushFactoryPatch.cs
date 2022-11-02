using HarmonyLib;
using MCM.Abstractions.Base.Global;
using System;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;

namespace ColorBlindAccessibleUI
{
    [HarmonyPatch(typeof(BrushFactory), "GetBrush")]
    internal class BrushFactoryPatch
    {
        private static void Postfix(ref Brush __result)
        {
            if (__result != null && __result.Name == "InventoryItemCostFont")
            {
                if (ColorBlindAccessibleUI.TradePriceBrush == null)
                {
                    var veryGoodStyle = new Style(__result.Layers);
                    veryGoodStyle.Name = "VeryGood";
                    veryGoodStyle.SetAsDefaultStyle();
                    veryGoodStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceVeryGood.SelectedValue.Color;
                    __result.RemoveStyle("VeryGood");
                    __result.AddStyle(veryGoodStyle);
                    var goodStyle = new Style(__result.Layers);
                    goodStyle.Name = "Good";
                    goodStyle.SetAsDefaultStyle();
                    goodStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceGood.SelectedValue.Color;
                    __result.RemoveStyle("Good");
                    __result.AddStyle(goodStyle);
                    var veryBadStyle = new Style(__result.Layers);
                    veryBadStyle.Name = "VeryBad";
                    veryBadStyle.SetAsDefaultStyle();
                    veryBadStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceVeryBad.SelectedValue.Color;
                    __result.RemoveStyle("VeryBad");
                    __result.AddStyle(veryBadStyle);
                    var badStyle = new Style(__result.Layers);
                    badStyle.Name = "Bad";
                    badStyle.SetAsDefaultStyle();
                    badStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceBad.SelectedValue.Color;
                    __result.RemoveStyle("Bad");
                    __result.AddStyle(badStyle);

                    var defaultStyle = new Style(__result.Layers);
                    defaultStyle.Name = "Default";
                    defaultStyle.SetAsDefaultStyle();
                    defaultStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceNeutral.SelectedValue.Color;
                    defaultStyle.TextGlowColor = Color.ConvertStringToColor("#FF0000FF");
                    defaultStyle.TextOutlineColor = Color.ConvertStringToColor("#FF0000FF");
                    defaultStyle.TextBlur = 0;
                    defaultStyle.TextOutlineAmount = 0;
                    defaultStyle.TextGlowRadius = 0;
                    defaultStyle.FontSize = 18;

                    __result.RemoveStyle("Default");
                    __result.AddStyle(defaultStyle);

                    var cloneBrush = new Brush();
                    cloneBrush.FillFrom(__result);
                    ColorBlindAccessibleUI.TradePriceBrush = cloneBrush;
                }
                __result = ColorBlindAccessibleUI.TradePriceBrush;
            }
        }
    }
}
