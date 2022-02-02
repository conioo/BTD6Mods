using Assets.Main.Scenes;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;
using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using Assets.Scripts.Utils;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Models.TowerSets;
using BTD6RandomMonkeysGenerator.MonkeysRandomGenerator;

namespace BTD6RandomMonkeysGenerator
{
    class Main : BloonsTD6Mod
    {
        // public override string MelonInfoCsURL => "https://raw.githubusercontent.com/GMConio/BTD6Mods/main/BTD6RandomMonkeysGenerator/Properties/AssemblyInfo.cs";

        // public override string LatestURL => "https://github.com/GMConio/BTD6Mods/blob/main/BTD6RandomMonkeysGenerator/BTD6RandomMonkeysGenerator.dll?raw=true";

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }

        public static readonly string Code = "001122Tier";
        public static readonly string CodeTier0 = "001122Tier0!";
        public static readonly string CodeTier1 = "001122Tier1!";
        public static readonly string CodeTier2 = "001122Tier2!";
        public static readonly string CodeTier3 = "001122Tier3!";
        public static readonly string CodeTier4 = "001122Tier4!";
        public static readonly string CodeTier5 = "001122Tier5!";

        private static readonly TowerExpireModel ExpireModelTier0 = new TowerExpireModel("TowerExpireModel_", 15, false, false);
        private static readonly TowerExpireModel ExpireModelTier1 = new TowerExpireModel("TowerExpireModel_", 20, false, false);
        private static readonly TowerExpireModel ExpireModelTier2 = new TowerExpireModel("TowerExpireModel_", 25, false, false);
        private static readonly TowerExpireModel ExpireModelTier3 = new TowerExpireModel("TowerExpireModel_", 30, false, false);
        private static readonly TowerExpireModel ExpireModelTier4 = new TowerExpireModel("TowerExpireModel_", 40, false, false);
        private static readonly TowerExpireModel ExpireModelTier5 = new TowerExpireModel("TowerExpireModel_", 50, false, false);

        [HarmonyPatch(typeof(Tower), "Initialise")]
        public class TowerInitialise_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(Tower __instance, ref Model modelToUse)
            {
                if (modelToUse.name == "DartMonkey")
                {
                    var randomMonkey = modelToUse.Cast<TowerModel>();

                    if (randomMonkey.display.Contains(Code))
                    {
                        TowerModel towerModel;

                        if (randomMonkey.display == CodeTier5)
                        {
                            towerModel = GeneratorMonkeys.GetTowerModel(5).Duplicate();
                            towerModel.AddBehavior(ExpireModelTier5);
                        }
                        else if (randomMonkey.display == CodeTier4)
                        {
                            towerModel = GeneratorMonkeys.GetTowerModel(4).Duplicate();
                            towerModel.AddBehavior(ExpireModelTier4);
                        }
                        else if (randomMonkey.display == CodeTier3)
                        {
                            towerModel = GeneratorMonkeys.GetTowerModel(3).Duplicate();
                            towerModel.AddBehavior(ExpireModelTier3);
                        }
                        else if (randomMonkey.display == CodeTier2)
                        {
                            towerModel = GeneratorMonkeys.GetTowerModel(2).Duplicate();
                            towerModel.AddBehavior(ExpireModelTier2);
                        }
                        else if (randomMonkey.display == CodeTier1)
                        {
                            towerModel = GeneratorMonkeys.GetTowerModel(1).Duplicate();
                            towerModel.AddBehavior(ExpireModelTier1);
                        }
                        else
                        {
                            towerModel = GeneratorMonkeys.GetTowerModelTier0().Duplicate();
                            towerModel.AddBehavior(ExpireModelTier0);
                        }

                        towerModel.dontDisplayUpgrades = true;
                        towerModel.cost = 0;

                        modelToUse = towerModel;
                    }
                }
                return true;
            }
        }
    }
}