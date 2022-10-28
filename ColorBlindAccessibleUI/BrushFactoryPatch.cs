using HarmonyLib;
using MCM.Abstractions.Base.Global;
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
                    __result.RemoveStyle("VeryGood");
                    __result.RemoveStyle("Good");
                    __result.RemoveStyle("VeryBad");
                    __result.RemoveStyle("Bad");
                    var tempDefaultStyle = __result.GetStyle("Default");
                    __result.RemoveStyle("Default");

                    var defaultStyle = new Style(__result.Layers);
                    defaultStyle.DefaultStyle = tempDefaultStyle;
                    defaultStyle.Name = "Default";
                    defaultStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceNeutral.SelectedValue.Color;
                    defaultStyle.TextGlowColor = Color.ConvertStringToColor("#FF0000FF");
                    defaultStyle.TextOutlineColor = Color.ConvertStringToColor("#FF0000FF");
                    defaultStyle.TextBlur = 0;
                    defaultStyle.TextOutlineAmount = 0;
                    defaultStyle.TextGlowRadius = 0;
                    defaultStyle.FontSize = 18;
                    __result.AddStyle(defaultStyle);

                    var veryGoodStyle = new Style(__result.Layers);
                    veryGoodStyle.DefaultStyle = defaultStyle;
                    veryGoodStyle.Name = "VeryGood";
                    veryGoodStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceVeryGood.SelectedValue.Color;
                    __result.AddStyle(veryGoodStyle);

                    var goodStyle = new Style(__result.Layers);
                    goodStyle.DefaultStyle = defaultStyle;
                    goodStyle.Name = "Good";
                    goodStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceGood.SelectedValue.Color;
                    __result.AddStyle(goodStyle);

                    var veryBadStyle = new Style(__result.Layers);
                    veryBadStyle.DefaultStyle = defaultStyle;
                    veryBadStyle.Name = "VeryBad";
                    veryBadStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceVeryBad.SelectedValue.Color;
                    __result.AddStyle(veryBadStyle);

                    var badStyle = new Style(__result.Layers);
                    badStyle.DefaultStyle = defaultStyle;
                    badStyle.Name = "Bad";
                    badStyle.FontColor = GlobalSettings<MCMSettings>.Instance.TradePriceBad.SelectedValue.Color;
                    __result.AddStyle(badStyle);
                    
                    var cloneBrush = new Brush();
                    cloneBrush.FillFrom(__result);
                    ColorBlindAccessibleUI.TradePriceBrush = cloneBrush;
                }
                __result = ColorBlindAccessibleUI.TradePriceBrush;
            }
        }
    }
}
