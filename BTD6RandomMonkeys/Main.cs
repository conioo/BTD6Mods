using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Towers;
using MelonLoader;
using RandomMonkeys.DefaultOptions;
using RandomMonkeys.Events;
using RandomMonkeys.MonkeysRandomGenerator;

namespace RandomMonkeys.BloonsMod
{
    class Main : BloonsTD6Mod
    {
        const int MINVALUE = 470;
        bool FirstLoaded = true;

        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/conioo/BTD6Mods/main/BTD6RandomMonkeys/Properties/AssemblyInfo.cs";
        public override string LatestURL => "https://github.com/conioo/BTD6Mods/blob/main/BTD6RandomMonkeys/BTD6RandomMonkeys.dll?raw=true";

        public static readonly ModSettingBool EnableMod = true;
        public static readonly ModSettingBool EnableSeed = false;

        internal static readonly ModSettingInt Seed = 0;

        public static readonly ModSettingInt CostTier_0 = new ModSettingInt(Options.DefaultCostTier_0) { minValue = MINVALUE };
        public static readonly ModSettingInt CostTier_1 = new ModSettingInt(Options.DefaultCostTier_1) { minValue = MINVALUE };
        public static readonly ModSettingInt CostTier_2 = new ModSettingInt(Options.DefaultCostTier_2) { minValue = MINVALUE };
        public static readonly ModSettingInt CostTier_3 = new ModSettingInt(Options.DefaultCostTier_3) { minValue = MINVALUE };
        public static readonly ModSettingInt CostTier_4 = new ModSettingInt(Options.DefaultCostTier_4) { minValue = MINVALUE };
        public static readonly ModSettingInt CostTier_5 = new ModSettingInt(Options.DefaultCostTier_5) { minValue = MINVALUE };

        public static ModSettingInt RandomTierProbability_Tier_0 = new ModSettingInt(Options.DefaultProbabilityRandomTier_0)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierProbability_Tier_1 = new ModSettingInt(Options.DefaultProbabilityRandomTier_1)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierProbability_Tier_2 = new ModSettingInt(Options.DefaultProbabilityRandomTier_2)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierProbability_Tier_3 = new ModSettingInt(Options.DefaultProbabilityRandomTier_3)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierProbability_Tier_4 = new ModSettingInt(Options.DefaultProbabilityRandomTier_4)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierProbability_Tier_5 = new ModSettingInt(Options.DefaultProbabilityRandomTier_5)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };

        public static ModSettingInt RandomTierLiteProbability_Tier_0 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_0)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierLiteProbability_Tier_1 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_1)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierLiteProbability_Tier_2 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_2)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierLiteProbability_Tier_3 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_3)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public static ModSettingInt RandomTierLiteProbability_Tier_4 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_4)
        {
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            CostTier_0.OnValueChanged.Add(ModSettingEvents.ValueChangedTier_0);
            CostTier_1.OnValueChanged.Add(ModSettingEvents.ValueChangedTier_1);
            CostTier_2.OnValueChanged.Add(ModSettingEvents.ValueChangedTier_2);
            CostTier_3.OnValueChanged.Add(ModSettingEvents.ValueChangedTier_3);
            CostTier_4.OnValueChanged.Add(ModSettingEvents.ValueChangedTier_4);
            CostTier_5.OnValueChanged.Add(ModSettingEvents.ValueChangedTier_5);

            RandomTierProbability_Tier_0.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            RandomTierProbability_Tier_1.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            RandomTierProbability_Tier_2.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            RandomTierProbability_Tier_3.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            RandomTierProbability_Tier_4.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            RandomTierProbability_Tier_5.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);

            RandomTierLiteProbability_Tier_0.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            RandomTierLiteProbability_Tier_1.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            RandomTierLiteProbability_Tier_2.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            RandomTierLiteProbability_Tier_3.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            RandomTierLiteProbability_Tier_4.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);

            EnableMod.OnValueChanged.Add(ModSettingEvents.ChangedStateMod);
            EnableSeed.OnValueChanged.Add(ModSettingEvents.ChangedBooleanSeed);
            Seed.OnValueChanged.Add(ModSettingEvents.ChangedSeed);
        }
        public override void OnMainMenu()
        {
            base.OnMainMenu();

            if (FirstLoaded)
            {
                ModSettingEvents.ValueChangedTier_0(CostTier_0);
                ModSettingEvents.ValueChangedTier_1(CostTier_1);
                ModSettingEvents.ValueChangedTier_2(CostTier_2);
                ModSettingEvents.ValueChangedTier_3(CostTier_3);
                ModSettingEvents.ValueChangedTier_4(CostTier_4);
                ModSettingEvents.ValueChangedTier_5(CostTier_5);

                ModSettingEvents.ProbabilityChangedTier(0);
                ModSettingEvents.ProbabilityChangedTierLite(0);

                if (GeneratorMonkeys.isCorrectSumProbability())
                {
                    GeneratorMonkeys.SetConverter();
                }
                else
                {
                    RandomTierProbability_Tier_0 = Options.DefaultProbabilityRandomTier_0;
                    RandomTierProbability_Tier_1 = Options.DefaultProbabilityRandomTier_1;
                    RandomTierProbability_Tier_2 = Options.DefaultProbabilityRandomTier_2;
                    RandomTierProbability_Tier_3 = Options.DefaultProbabilityRandomTier_3;
                    RandomTierProbability_Tier_4 = Options.DefaultProbabilityRandomTier_4;
                    RandomTierProbability_Tier_5 = Options.DefaultProbabilityRandomTier_5;

                    GeneratorMonkeys.SetConverter();
                    MelonLogger.Msg("(Random Tier)incorrect probability data - defaults set");
                }

                if (GeneratorMonkeys.isCorrectSumProbabilityLite())
                {
                    GeneratorMonkeys.SetConverterLite();
                }
                else
                {
                    RandomTierLiteProbability_Tier_0 = Options.DefaultProbabilityRandomTierLite_0;
                    RandomTierLiteProbability_Tier_1 = Options.DefaultProbabilityRandomTierLite_1;
                    RandomTierLiteProbability_Tier_2 = Options.DefaultProbabilityRandomTierLite_2;
                    RandomTierLiteProbability_Tier_3 = Options.DefaultProbabilityRandomTierLite_3;
                    RandomTierLiteProbability_Tier_4 = Options.DefaultProbabilityRandomTierLite_4;

                    GeneratorMonkeys.SetConverterLite();
                    MelonLogger.Msg("(Random Tier Lite)incorrect probability data - defaults set");
                }
                FirstLoaded = false;
            }
        }

        //[HarmonyPatch(typeof(Assets.Scripts.Simulation.Towers.Tower), "Initialise")]
        //internal class Tower_Initialise
        //{
        //    [HarmonyPrefix]
        //    internal static bool Prefix(ref Assets.Scripts.Simulation.Towers.Tower __instance, ref Model modelToUse)
        //    {
        //        //foreach (TowerModel towerModel2 in InGameExt.GetGameModel(inGame).towers)
        //        //{
        //        //    bool flag2 = !towerModel2.IsHero();
        //        //    if (flag2)
        //        //    {
        //        //        Main.allTowers.Add(towerModel2);
        //        //    }
        //        //}

        //        var model = InGameExt.GetGameModel(InGame.instance).GetTower(TowerType.SpikeFactory, 1, 0, 0);

        //        modelToUse = model;
        //       // modelToUse = InGameExt.GetGameModel(InGame.instance).GetTower(TowerType.SpikeFactory);
        //        return true;
        //    }
        //}
    }

    [HarmonyPatch(typeof(Tower), "Initialise")]
    public class TowerInitialise_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Tower __instance, ref Model modelToUse)
        {
            if (modelToUse.name.Contains("Tier") && Main.EnableMod)
            {
                if (modelToUse.name.Contains("Tier_0"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelTier0();
                }
                else if (modelToUse.name.Contains("Tier_1"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel(1);
                }
                else if (modelToUse.name.Contains("Tier_2"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel(2);
                }
                else if (modelToUse.name.Contains("Tier_3"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel(3);
                }
                else if (modelToUse.name.Contains("Tier_4"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel(4);
                }
                else if (modelToUse.name.Contains("Tier_5"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel(5);
                }
                else if (modelToUse.name.Contains("Tier_AnyLite"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelAnyLite();
                }
                else
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelAny();
                }
            }
            return true;
        }
    }
}