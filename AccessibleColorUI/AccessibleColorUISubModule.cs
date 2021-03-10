using System.IO;
using System.Reflection;
using HarmonyLib;
using Newtonsoft.Json;
using SandBox.ViewModelCollection.Nameplate;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace AccessibleColorUI
{
    public class AccessibleColorUISubModule : MBSubModuleBase
    {
        public static Config Config { get; private set; }
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            AccessibleColorUISubModule.LoadConfig();
            new Harmony("Friendly Colors").PatchAll();

            // Update party nameplate colors - each is a fraction lighter than specified color because they tend to
            // appear significantly darker in text than they do on the settlement nameplates.

            // for version 1.5.8 - these guys become static access
            // for version 1.5.7 and earlier - these are getters only, need overwritten via Harmony - see Patches file
            //PartyNameplateVM.PositiveIndicator = Color.Lerp(Config.GetAllyColor(), Color.White, (float)0.20).ToString();
            //PartyNameplateVM.PositiveArmyIndicator = Color.Lerp(Config.GetAllyColor(), Color.White, (float)0.40).ToString();
            //PartyNameplateVM.NegativeIndicator = Color.Lerp(Config.GetEnemyColor(), Color.White, (float)0.20).ToString();
            //PartyNameplateVM.NegativeArmyIndicator = Color.Lerp(Config.GetEnemyColor(), Color.White, (float)0.40).ToString();
        }

        private static void LoadConfig()
        {
            bool configExists = File.Exists(AccessibleColorUISubModule.ConfigurationFilePath);
            if (configExists)
            {
                try
                {
                    AccessibleColorUISubModule.Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(AccessibleColorUISubModule.ConfigurationFilePath));
                }
                catch { }
            }
        }

        private static readonly string ConfigurationFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
    }
}