using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using Newtonsoft.Json;
using SandBox.ViewModelCollection.Nameplate;
using System.IO;
using System.Reflection;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ColorBlindAccessibleUI
{
    public class ColorBlindAccessibleUI : MBSubModuleBase
    {
        public static Brush TradePriceBrush { get; set; }
        private static readonly string ConfigurationFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "customColors.json");

        public static void UpdateColors()
        {
            PartyNameplateVM.PositiveIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.FriendlyPartyColor.SelectedValue.Color, Color.White, (float)0.2).ToString();
            PartyNameplateVM.PositiveArmyIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.FriendlyPartyColor.SelectedValue.Color, Color.White, (float)0.4).ToString();
            PartyNameplateVM.NegativeIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.EnemyPartyColor.SelectedValue.Color, Color.White, (float)0.2).ToString();
            PartyNameplateVM.NegativeArmyIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.EnemyPartyColor.SelectedValue.Color, Color.White, (float)0.4).ToString();
        }
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            LoadCustomColors();
            new Harmony("Color Blind Accessible UI").PatchAll();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            PartyNameplateVM.PositiveIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.FriendlyPartyColor.SelectedValue.Color, Color.White, (float)0.2).ToString();
            PartyNameplateVM.PositiveArmyIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.FriendlyPartyColor.SelectedValue.Color, Color.White, (float)0.4).ToString();
            PartyNameplateVM.NegativeIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.EnemyPartyColor.SelectedValue.Color, Color.White, (float)0.2).ToString();
            PartyNameplateVM.NegativeArmyIndicator = Color.Lerp(GlobalSettings<MCMSettings>.Instance.EnemyPartyColor.SelectedValue.Color, Color.White, (float)0.4).ToString();
        }

        protected void LoadCustomColors()
        {
            bool configExists = File.Exists(ColorBlindAccessibleUI.ConfigurationFilePath);
            if (configExists)
            {
                try
                {
                    var customColors = JsonConvert.DeserializeObject<CustomColor[]>(File.ReadAllText(ColorBlindAccessibleUI.ConfigurationFilePath));
                    CustomColor.AddColors(customColors);
                }
                catch { }
            }
        }
    }
}