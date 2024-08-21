using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Achievements.List;
using Il2CppAssets.Scripts.Unity.Display.Animation;
using Il2CppAssets.Scripts.Unity.Powers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using RandomMonkeys.DefaultOptions;
using RandomMonkeys.Events;
using RandomMonkeys.MonkeysRandomGenerator;
using RandomMonkeys.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace RandomMonkeys.BloonsMod
{
    class Main : BloonsTD6Mod
    {
        private bool FirstLoaded = true;

        internal static readonly ModSettingBool RandomSeed = true;

        internal static readonly ModSettingInt Seed = new ModSettingInt(0)
        {
        };

        internal static readonly ModSettingFloat PriceMultiplier = new ModSettingFloat(1)
        {
            min = 0.1,
            max = 5,
            slider = true,
        };

        internal static readonly ModSettingBool OnlyRandomMonkeysInShop = true;

        internal static readonly ModSettingBool AddRandomHeroToShop = true;

        internal static readonly ModSettingBool HideUpgrades = true;

        internal static readonly ModSettingBool AddBananaFarmToShop = true;

        internal static readonly ModSettingHotkey RandomTier0 = new ModSettingHotkey(KeyCode.F1);
        internal static readonly ModSettingHotkey RandomTier1 = new ModSettingHotkey(KeyCode.F2);
        internal static readonly ModSettingHotkey RandomTier2 = new ModSettingHotkey(KeyCode.F3);
        internal static readonly ModSettingHotkey RandomTier3 = new ModSettingHotkey(KeyCode.F4);
        internal static readonly ModSettingHotkey RandomTier4 = new ModSettingHotkey(KeyCode.F5);
        internal static readonly ModSettingHotkey RandomTier5 = new ModSettingHotkey(KeyCode.F6);

        internal static readonly ModSettingHotkey RandomHero = new ModSettingHotkey(KeyCode.F7);
        internal static readonly ModSettingHotkey RandomParagon = new ModSettingHotkey(KeyCode.F8);

        internal static readonly ModSettingHotkey RandomAny = new ModSettingHotkey(KeyCode.Z);
        internal static readonly ModSettingHotkey RandomAnyLite = new ModSettingHotkey(KeyCode.X);

        //public static ModSettingInt RandomTierProbability_Tier_0 = new ModSettingInt(Options.DefaultProbabilityRandomTier_0)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierProbability_Tier_1 = new ModSettingInt(Options.DefaultProbabilityRandomTier_1)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierProbability_Tier_2 = new ModSettingInt(Options.DefaultProbabilityRandomTier_2)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierProbability_Tier_3 = new ModSettingInt(Options.DefaultProbabilityRandomTier_3)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierProbability_Tier_4 = new ModSettingInt(Options.DefaultProbabilityRandomTier_4)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierProbability_Tier_5 = new ModSettingInt(Options.DefaultProbabilityRandomTier_5)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};

        //public static ModSettingInt RandomTierLiteProbability_Tier_0 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_0)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierLiteProbability_Tier_1 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_1)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierLiteProbability_Tier_2 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_2)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierLiteProbability_Tier_3 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_3)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        //public static ModSettingInt RandomTierLiteProbability_Tier_4 = new ModSettingInt(Options.DefaultProbabilityRandomTierLite_4)
        //{
        //    minValue = 0,
        //    maxValue = 100,
        //    isSlider = true
        //};
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            PriceMultiplier.onSave = ModSettingEvents.PriceMultiplierSaved;

            RandomSeed.onSave = ModSettingEvents.RandomSeedSaved;
            Seed.onSave = ModSettingEvents.SeedSaved;

            //RandomTierProbability_Tier_0.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            //RandomTierProbability_Tier_1.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            //RandomTierProbability_Tier_2.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            //RandomTierProbability_Tier_3.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            //RandomTierProbability_Tier_4.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);
            //RandomTierProbability_Tier_5.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTier);

            //RandomTierLiteProbability_Tier_0.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            //RandomTierLiteProbability_Tier_1.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            //RandomTierLiteProbability_Tier_2.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            //RandomTierLiteProbability_Tier_3.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
            //RandomTierLiteProbability_Tier_4.OnValueChanged.Add(ModSettingEvents.ProbabilityChangedTierLite);
        }

        public override void OnNewGameModel(GameModel result)
        {
            //MelonLogger.Msg($"OnNewGameModel");
        }
        public override void OnMainMenu()
        {
            base.OnMainMenu();

            //MelonLogger.Msg("OnMainMenu");

            if (FirstLoaded)
            {
                ModSettingEvents.PriceMultiplierSaved(PriceMultiplier);

                GeneratorMonkeys.SetConverter();
                GeneratorMonkeys.SetConverterLite();

                //if (GeneratorMonkeys.isCorrectSumProbability())
                //{
                //    GeneratorMonkeys.SetConverter();
                //}
                //else
                //{
                //    RandomTierProbability_Tier_0 = Options.DefaultProbabilityRandomTier_0;
                //    RandomTierProbability_Tier_1 = Options.DefaultProbabilityRandomTier_1;
                //    RandomTierProbability_Tier_2 = Options.DefaultProbabilityRandomTier_2;
                //    RandomTierProbability_Tier_3 = Options.DefaultProbabilityRandomTier_3;
                //    RandomTierProbability_Tier_4 = Options.DefaultProbabilityRandomTier_4;
                //    RandomTierProbability_Tier_5 = Options.DefaultProbabilityRandomTier_5;

                //    GeneratorMonkeys.SetConverter();
                //    MelonLogger.Msg("(Random Tier)incorrect probability data - defaults set");
                //}

                foreach (var tower in Game.instance.model.towers)
                {
                    if (GeneratorMonkeys.AllMonkeys.Contains(tower.name))
                    {
                        if (tower?.IsTowerUnlocked() == true)
                        {
                            GeneratorMonkeys.UnlockedMonkeys.Add(tower.name);
                        }
                        else
                        {
                            //MelonLogger.Msg($"not unlocked: {tower.name}");
                        }
                    }
                    //tower.GetUpgrade(0, 0).IsUpgradeUnlocked();
                    if (GeneratorMonkeys.AllHeroes.Contains(tower.name))
                    {
                        if (tower?.IsHeroUnlocked() == true)
                        {
                            GeneratorMonkeys.UnlockedHeroes.Add(tower.name);
                        }
                        else
                        {
                            //MelonLogger.Msg($"not unlocked: {tower.name}");
                        }
                    }

                    if (GeneratorMonkeys.AllParagons.Contains(tower.name))
                    {
                        if (Game.instance.model.GetParagonUpgrade(tower.name).IsUpgradeUnlocked() == true)
                        {
                            //MelonLogger.Msg($"paragon: {tower.name}, {Game.instance.model.GetParagonUpgrade(tower.name).cost}");
                            GeneratorMonkeys.UnlockedParagons.Add(tower.name);
                        }
                        else
                        {
                            //MelonLogger.Msg($"not unlocked paragon: {tower.name}");
                        }
                    }

                    if (GeneratorMonkeys.AllSubTowers.Contains(tower.name))
                    {
                        //if (tower?.IsTowerUnlocked() == true)
                        if (true)
                        {
                            //MelonLogger.Msg($"paragon: {tower.name}, {Game.instance.model.GetParagonUpgrade(tower.name).cost}");
                            GeneratorMonkeys.UnlockedSubTowers.Add(tower.name);
                        }
                        else
                        {
                            MelonLogger.Msg($"not unlocked subtower: {tower.name}");
                        }
                    }
                }
                FirstLoaded = false;
            }
        }

        //public override void OnInGameLoaded(InGame inGame)
        //{
        //    MelonLogger.Msg($"OnInGameLoaded");
        //}
    }

    [HarmonyPatch(typeof(Il2CppAssets.Scripts.Simulation.Towers.Tower), "Initialise")]
    public class TowerInitialise_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(Il2CppAssets.Scripts.Simulation.Towers.Tower __instance, ref Model modelToUse)
        {
            if (modelToUse.name.Contains("BTD6RandomMonkeys"))
            {
                //MelonLogger.Msg(modelToUse.name);
                if (modelToUse.name.Contains("Tier_0"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModel(0);
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
                else if (modelToUse.name.Contains("Tier_Any"))
                {
                    modelToUse = GeneratorMonkeys.GetTowerModelAny();
                }
                else if (modelToUse.name.Contains("RandomHero"))
                {
                    modelToUse = GeneratorMonkeys.GetRandomHero();
                }
                else if (modelToUse.name.Contains("RandomParagon"))
                {
                    modelToUse = GeneratorMonkeys.GetRandomParagon();
                }
                else if (modelToUse.name.Contains("RandomSubTower"))
                {
                    modelToUse = GeneratorMonkeys.GetRandomSubTower();
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(TowerInventory), "Init")]
    internal static class TowerInventory_Init
    {
        // Token: 0x060001C9 RID: 457 RVA: 0x00005CE4 File Offset: 0x00003EE4
        [HarmonyPostfix]
        private static void Postfix(TowerInventory __instance, IEnumerable<TowerDetailsModel> allTowersInTheGame)
        {
            var newTowerDisplayOrder = new Il2CppSystem.Collections.Generic.List<string>();

            foreach (var towerName in __instance.towerDisplayOrder)
            {
                if (towerName.Contains("BTD6RandomMonkeys"))
                {
                    if (towerName.Contains("RandomHero") && Main.AddRandomHeroToShop == false)
                    {
                        continue;
                    }

                    newTowerDisplayOrder.Add(towerName);
                }
                else
                {
                    if (Main.OnlyRandomMonkeysInShop == false)
                    {
                        newTowerDisplayOrder.Add(towerName);
                    }
                    else
                    {
                        if(towerName.Contains("BananaFarm") && Main.AddBananaFarmToShop)
                        {
                            newTowerDisplayOrder.Add(towerName);
                        }
                    }
                }
            }

            __instance.towerDisplayOrder = newTowerDisplayOrder;
        }
    }
}