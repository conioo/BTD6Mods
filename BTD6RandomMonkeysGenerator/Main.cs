using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using BTD6RandomMonkeysGenerator.MonkeysRandomGenerator;
using HarmonyLib;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace BTD6RandomMonkeysGenerator
{
    class Main : BloonsTD6Mod
    {
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

        private static readonly TowerExpireModel ExpireModelTier0 = new TowerExpireModel("TowerExpireModel_", 15, 1, false, false);
        private static readonly TowerExpireModel ExpireModelTier1 = new TowerExpireModel("TowerExpireModel_", 20, 1, false, false);
        private static readonly TowerExpireModel ExpireModelTier2 = new TowerExpireModel("TowerExpireModel_", 30, 1, false, false);
        private static readonly TowerExpireModel ExpireModelTier3 = new TowerExpireModel("TowerExpireModel_", 40, 1, false, false);
        private static readonly TowerExpireModel ExpireModelTier4 = new TowerExpireModel("TowerExpireModel_", 60, 1, false, false);
        private static readonly TowerExpireModel ExpireModelTier5 = new TowerExpireModel("TowerExpireModel_", 100, 1, false, false);

        [HarmonyPatch(typeof(Tower), "Initialise")]
        public class TowerInitialise_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(Tower __instance, ref Model modelToUse)
            {
                if (modelToUse.name.Contains(Code))
                {
                    var randomMonkey = modelToUse.Cast<TowerModel>();

                    // MelonLogger.Msg(randomMonkey.name);

                    TowerModel towerModel;

                    if (randomMonkey.name.ToString() == CodeTier5)
                    {
                        towerModel = GeneratorMonkeys.GetTowerModel(5).Duplicate();
                        towerModel.AddBehavior(ExpireModelTier5);
                    }
                    else if (randomMonkey.name == CodeTier4)
                    {
                        towerModel = GeneratorMonkeys.GetTowerModel(4).Duplicate();
                        towerModel.AddBehavior(ExpireModelTier4);
                    }
                    else if (randomMonkey.name == CodeTier3)
                    {
                        towerModel = GeneratorMonkeys.GetTowerModel(3).Duplicate();
                        towerModel.AddBehavior(ExpireModelTier3);
                    }
                    else if (randomMonkey.name == CodeTier2)
                    {
                        towerModel = GeneratorMonkeys.GetTowerModel(2).Duplicate();
                        towerModel.AddBehavior(ExpireModelTier2);
                    }
                    else if (randomMonkey.name == CodeTier1)
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

                return true;
            }
        }
    }
}