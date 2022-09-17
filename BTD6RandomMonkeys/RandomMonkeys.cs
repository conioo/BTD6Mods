using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using System.Collections.Generic;
using System;
using MelonLoader;
using BTD_Mod_Helper.Api;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;

namespace RandomMonkeys.MonkeysRandomGenerator
{
    static internal class GeneratorMonkeys
    {
        private enum Path
        {
            Top,
            Middle,
            Bottom
        }

        static private readonly int[] Converter = new int[100];
        static private readonly int[] ConverterLite = new int[100];

        static internal readonly List<string> AllMonkeys = new List<string>
        {
            TowerType.DartMonkey,
            TowerType.BombShooter,
            TowerType.BoomerangMonkey,
            TowerType.IceMonkey,
            TowerType.TackShooter,
            TowerType.GlueGunner,
            TowerType.DartlingGunner,
            TowerType.MonkeyAce,
            TowerType.SniperMonkey,
            TowerType.MonkeySub,
            TowerType.MortarMonkey,
            TowerType.MonkeyBuccaneer,
            TowerType.HeliPilot,
            TowerType.NinjaMonkey,
            TowerType.Alchemist,
            TowerType.SuperMonkey,
            TowerType.WizardMonkey,
            TowerType.Druid,
            TowerType.MonkeyVillage,
            TowerType.EngineerMonkey,
            TowerType.BananaFarm,
            TowerType.SpikeFactory
        };

        static private readonly int numberConverters = 100;

        static private readonly int numberMonkeys = AllMonkeys.Count;

        static private Random RandomGenerator = new Random();

        static private string GetMonkey()
        {
            return AllMonkeys[RandomGenerator.Next(numberMonkeys)];
        }

        static internal TowerModel GetTowerModel(int _tier)
        {
            string towerType = GetMonkey();

            int mainPath = RandomGenerator.Next(3);
            int sidePath = RandomGenerator.Next(2);

            int tierSidePath;

            if (_tier == 1)
            {
                tierSidePath = RandomGenerator.Next(2);
            }
            else
            {
                tierSidePath = RandomGenerator.Next(3);
            }


            if (mainPath == 0)
            {
                if (sidePath == 0)
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, tierSidePath, 0);
                }
                else
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, 0, tierSidePath);
                }
            }
            else if (mainPath == 1)
            {
                if (sidePath == 0)
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, tierSidePath, _tier, 0);
                }
                else
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, 0, _tier, tierSidePath);
                }
            }
            else
            {
                if (sidePath == 0)
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, tierSidePath, 0, _tier);
                }
                else
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, 0, tierSidePath, _tier);
                }
            }

        }

        static internal TowerModel GetTowerModelTier0()
        {
            return InGameExt.GetGameModel(InGame.instance).GetTower(GetMonkey(), 0, 0, 0);
        }

        static internal TowerModel GetTowerModelAny()
        {
            return GetTowerModel(Converter[RandomGenerator.Next(numberConverters)]);
        }

        static internal TowerModel GetTowerModelAnyLite()
        {
            return GetTowerModel(ConverterLite[RandomGenerator.Next(numberConverters)]);
        }

        static internal void SetConverter()
        {
            int counter = 0;
            int i;

            for (i = 0; i < BloonsMod.Main.RandomTierProbability_Tier_0; ++counter, ++i)
            {
                Converter[counter] = 0;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierProbability_Tier_1; ++counter, ++i)
            {
                Converter[counter] = 1;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierProbability_Tier_2; ++counter, ++i)
            {
                Converter[counter] = 2;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierProbability_Tier_3; ++counter, ++i)
            {
                Converter[counter] = 3;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierProbability_Tier_4; ++counter, ++i)
            {
                Converter[counter] = 4;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierProbability_Tier_5; ++counter, ++i)
            {
                Converter[counter] = 5;
            }
        }

        static internal void SetConverterLite()
        {
            int counter = 0;
            int i;

            for (i = 0; i < BloonsMod.Main.RandomTierLiteProbability_Tier_0; ++counter, ++i)
            {
                ConverterLite[counter] = 0;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierLiteProbability_Tier_1; ++counter, ++i)
            {
                ConverterLite[counter] = 1;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierLiteProbability_Tier_2; ++counter, ++i)
            {
                ConverterLite[counter] = 2;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierLiteProbability_Tier_3; ++counter, ++i)
            {
                ConverterLite[counter] = 3;
            }

            for (i = 0; i < BloonsMod.Main.RandomTierLiteProbability_Tier_4; ++counter, ++i)
            {
                ConverterLite[counter] = 4;
            }
        }

        static internal bool isCorrectSumProbability()
        {
            if (BloonsMod.Main.RandomTierProbability_Tier_0 + BloonsMod.Main.RandomTierProbability_Tier_1 + BloonsMod.Main.RandomTierProbability_Tier_2 + BloonsMod.Main.RandomTierProbability_Tier_3 + BloonsMod.Main.RandomTierProbability_Tier_4 + BloonsMod.Main.RandomTierProbability_Tier_5 == 100)
            {
                MelonLogger.Msg("(Random Tier) Correctly Probability");
                return true;
            }
            else
            {
                MelonLogger.Warning("(Random Tier) Incorrect sum of all probabilities should be 100)");
                return false;
            }
        }

        static internal bool isCorrectSumProbabilityLite()
        {
            if (BloonsMod.Main.RandomTierLiteProbability_Tier_0 + BloonsMod.Main.RandomTierLiteProbability_Tier_1 + BloonsMod.Main.RandomTierLiteProbability_Tier_2 + BloonsMod.Main.RandomTierLiteProbability_Tier_3 + BloonsMod.Main.RandomTierLiteProbability_Tier_4 == 100)
            {
                MelonLogger.Msg("(Random Tier Lite) Correctly Probability");
                return true;
            }
            else
            {
                MelonLogger.Warning("(Random Tier Lite) Incorrect sum of all probabilities should be 100)");
                return false;
            }
        }

        static internal long CalculationRandomTierCost()
        {
            return (long)(((double)BloonsMod.Main.RandomTierProbability_Tier_0 / 100.0) * (double)BloonsMod.Main.CostTier_0 +
                          ((double)BloonsMod.Main.RandomTierProbability_Tier_1 / 100.0) * (double)BloonsMod.Main.CostTier_1 +
                          ((double)BloonsMod.Main.RandomTierProbability_Tier_2 / 100.0) * (double)BloonsMod.Main.CostTier_2 +
                          ((double)BloonsMod.Main.RandomTierProbability_Tier_3 / 100.0) * (double)BloonsMod.Main.CostTier_3 +
                          ((double)BloonsMod.Main.RandomTierProbability_Tier_4 / 100.0) * (double)BloonsMod.Main.CostTier_4 +
                          ((double)BloonsMod.Main.RandomTierProbability_Tier_5 / 100.0) * (double)BloonsMod.Main.CostTier_5);
        }

        static internal long CalculationRandomTierLiteCost()
        {
            return (long)(((double)BloonsMod.Main.RandomTierLiteProbability_Tier_0 / 100.0) * (double)BloonsMod.Main.CostTier_0 +
                          ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_1 / 100.0) * (double)BloonsMod.Main.CostTier_1 +
                          ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_2 / 100.0) * (double)BloonsMod.Main.CostTier_2 +
                          ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_3 / 100.0) * (double)BloonsMod.Main.CostTier_3 +
                          ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_4 / 100.0) * (double)BloonsMod.Main.CostTier_4);
        }

        static internal void SetGeneratorSeed()
        {
            RandomGenerator = new Random(RandomMonkeys.BloonsMod.Main.Seed);
        }

        static internal void SetGeneratorRandom()
        {
            RandomGenerator = new Random();
        }

        static internal void SetRandomTierCost()
        {
            var newPrice = CalculationRandomTierCost();
            MelonLogger.Msg($"(Random Tier) Set the new price to { newPrice}");
            ModContent.GetTowerModel<Towers.Tier_Any>(0, 0, 0).cost = newPrice;
        }

        static internal void SetRandomTierLiteCost()
        {
            var newPrice = CalculationRandomTierLiteCost();
            MelonLogger.Msg($"(Random Tier Lite) Set the new price to { newPrice}");
            ModContent.GetTowerModel<Towers.Tier_AnyLite>(0, 0, 0).cost = newPrice;
        }
    }
}
