using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using RandomMonkeys.DefaultOptions;
using System;
using System.Collections.Generic;
using System.Linq;

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

        static private readonly List<List<int>> SidePathConverter = new List<List<int>>
        {
            new List<int>{0 },//0
            new List<int>{0,1 },//1
            new List<int>{0,0,1,1,2,2 },//2
            new List<int>{0,0,1,1,1,2,2,2 },//3
            new List<int>{0,0,1,1,1,2,2,2,2 },//4
            new List<int>{0,1,1,1,2,2,2,2,2,2 },//5
        };

        static internal List<string> AllMonkeys = new List<string>
        {
        };
        static internal List<string> UnlockedMonkeys = new List<string>();

        static internal List<string> AllHeroes = new List<string>
        {
        };
        static internal List<string> UnlockedHeroes = new List<string>();

        static internal List<string> AllParagons = new List<string>
        {
        };
        static internal List<string> UnlockedParagons = new List<string>();

        static internal List<string> AllSubTowers = new List<string>
        {
        };
        static internal List<string> UnlockedSubTowers = new List<string>();

        static private readonly int numberConverters = 100;

        static private Random RandomGenerator = new Random();

        static private string GetMonkey(List<string> monkeys)
        {
            return monkeys[RandomGenerator.Next(monkeys.Count)];
        }

        static internal TowerModel GetRandomHero()
        {
            return InGameExt.GetGameModel(InGame.instance).GetHeroWithNameAndLevel(GetMonkey(UnlockedHeroes), 1);
        }
        static internal TowerModel GetRandomSubTower()
        {
            var col = Game.instance.model.towers.Where(t => t.isSubTower && t.IsPlaceableInAreaType(Il2CppAssets.Scripts.Models.Map.AreaType.land)).ToList();
            MelonLogger.Msg(col.Count);
            //return InGameExt.GetGameModel(InGame.instance).GetTower(GetMonkey(UnlockedSubTowers));
            return col[RandomGenerator.Next(col.Count)];
        }
        static internal TowerModel GetRandomParagon()
        {
            var paragon = InGameExt.GetGameModel(InGame.instance).GetParagonTower(GetMonkey(UnlockedParagons));
            return paragon;
        }

        static internal TowerModel GetTowerModel(int _tier)
        {
            string towerType = GetMonkey(UnlockedMonkeys);

            int mainPath = RandomGenerator.Next(3);
            int sidePath = RandomGenerator.Next(2);

            int tierSidePath = SidePathConverter[_tier][RandomGenerator.Next(SidePathConverter[_tier].Count)];

            if (mainPath == 0)
            {
                if (sidePath == 0)
                {
                    return GetValidTowerModel(towerType, _tier, tierSidePath, 0, _tier);
                }
                else
                {
                    return GetValidTowerModel(towerType, _tier, 0, tierSidePath, _tier);
                }
            }
            else if (mainPath == 1)
            {
                if (sidePath == 0)
                {
                    return GetValidTowerModel(towerType, tierSidePath, _tier, 0, _tier);
                }
                else
                {
                    return GetValidTowerModel(towerType, 0, _tier, tierSidePath, _tier);
                }
            }
            else
            {
                if (sidePath == 0)
                {
                    return GetValidTowerModel(towerType, tierSidePath, 0, _tier, _tier);
                }
                else
                {
                    return GetValidTowerModel(towerType, 0, tierSidePath, _tier, _tier);
                }
            }

        }

        //static internal TowerModel GetTowerModelTier0()
        //{
        //    return InGameExt.GetGameModel(InGame.instance).GetTower("GetMonkey()", 0, 0, 0);
        //}

        static internal TowerModel GetTowerModelAny()
        {
            return GetTowerModel(Converter[RandomGenerator.Next(numberConverters)]);
        }

        static internal TowerModel GetTowerModelAnyLite()
        {
            return GetTowerModel(ConverterLite[RandomGenerator.Next(numberConverters)]);
        }

        static private TowerModel GetValidTowerModel(string towerName, int path0, int path1, int path2, int tier)
        {
            var tower = InGameExt.GetGameModel(InGame.instance).GetTower(towerName, path0, path1, path2);

            if ((tower.IsUpgradeUnlocked(0, path0) == false && path0 != 0) || (tower.IsUpgradeUnlocked(1, path1) == false && path0 != 0) || (tower.IsUpgradeUnlocked(2, path2) == false && path0 != 0))
            {
                return GetTowerModel(tier);
            }

            //MelonLogger.Msg($"{tower.IsUpgradeUnlocked(0, path0)}, {tower.IsUpgradeUnlocked(1, path1)}, {tower.IsUpgradeUnlocked(2, path2)}");

            //foreach (var item in tower.behaviors)
            //{
            //    MelonLogger.Msg(item.name);
            //}

            //MelonLogger.Msg("--------------");

            if(BloonsMod.Main.HideUpgrades)
            {
                tower.dontDisplayUpgrades = true;
            }

            return tower;
        }
        static internal void SetConverter()
        {
            int index = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < Options.DefaultProbabilityRandomTier[i]; j++)
                {
                    Converter[index++] = i;
                }
            }
        }

        static internal void SetConverterLite()
        {
            int index = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Options.DefaultProbabilityRandomTierLite[i]; j++)
                {
                    ConverterLite[index++] = i;
                }
            }
        }

        //static internal bool isCorrectSumProbability()
        //{
        //    if (BloonsMod.Main.RandomTierProbability_Tier_0 + BloonsMod.Main.RandomTierProbability_Tier_1 + BloonsMod.Main.RandomTierProbability_Tier_2 + BloonsMod.Main.RandomTierProbability_Tier_3 + BloonsMod.Main.RandomTierProbability_Tier_4 + BloonsMod.Main.RandomTierProbability_Tier_5 == 100)
        //    {
        //        MelonLogger.Msg("(Random Tier) Correctly Probability");
        //        return true;
        //    }
        //    else
        //    {
        //        MelonLogger.Warning("(Random Tier) Incorrect sum of all probabilities should be 100)");
        //        return false;
        //    }
        //}

        //static internal bool isCorrectSumProbabilityLite()
        //{
        //    if (BloonsMod.Main.RandomTierLiteProbability_Tier_0 + BloonsMod.Main.RandomTierLiteProbability_Tier_1 + BloonsMod.Main.RandomTierLiteProbability_Tier_2 + BloonsMod.Main.RandomTierLiteProbability_Tier_3 + BloonsMod.Main.RandomTierLiteProbability_Tier_4 == 100)
        //    {
        //        MelonLogger.Msg("(Random Tier Lite) Correctly Probability");
        //        return true;
        //    }
        //    else
        //    {
        //        MelonLogger.Warning("(Random Tier Lite) Incorrect sum of all probabilities should be 100)");
        //        return false;
        //    }
        //}

        //static internal long CalculationRandomTierCost()
        //{
        //    return (long)(((double)BloonsMod.Main.RandomTierProbability_Tier_0 / 100.0) * (double)BloonsMod.Main.CostTier_0 +
        //                  ((double)BloonsMod.Main.RandomTierProbability_Tier_1 / 100.0) * (double)BloonsMod.Main.CostTier_1 +
        //                  ((double)BloonsMod.Main.RandomTierProbability_Tier_2 / 100.0) * (double)BloonsMod.Main.CostTier_2 +
        //                  ((double)BloonsMod.Main.RandomTierProbability_Tier_3 / 100.0) * (double)BloonsMod.Main.CostTier_3 +
        //                  ((double)BloonsMod.Main.RandomTierProbability_Tier_4 / 100.0) * (double)BloonsMod.Main.CostTier_4 +
        //                  ((double)BloonsMod.Main.RandomTierProbability_Tier_5 / 100.0) * (double)BloonsMod.Main.CostTier_5);
        //}

        //static internal long CalculationRandomTierLiteCost()
        //{
        //    return (long)(((double)BloonsMod.Main.RandomTierLiteProbability_Tier_0 / 100.0) * (double)BloonsMod.Main.CostTier_0 +
        //                  ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_1 / 100.0) * (double)BloonsMod.Main.CostTier_1 +
        //                  ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_2 / 100.0) * (double)BloonsMod.Main.CostTier_2 +
        //                  ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_3 / 100.0) * (double)BloonsMod.Main.CostTier_3 +
        //                  ((double)BloonsMod.Main.RandomTierLiteProbability_Tier_4 / 100.0) * (double)BloonsMod.Main.CostTier_4);
        //}

        static internal void SetGeneratorSeed()
        {
            RandomGenerator = new Random(RandomMonkeys.BloonsMod.Main.Seed);
        }

        static internal void SetGeneratorRandom()
        {
            RandomGenerator = new Random();
        }

        //static internal void SetRandomTierCost()
        //{
        //    var newPrice = CalculationRandomTierCost();
        //    MelonLogger.Msg($"(Random Tier) Set the new price to { newPrice}");
        //    ModContent.GetTowerModel<Towers.Tier_Any>(0, 0, 0).cost = newPrice;
        //}

        //static internal void SetRandomTierLiteCost()
        //{
        //    var newPrice = CalculationRandomTierLiteCost();
        //    MelonLogger.Msg($"(Random Tier Lite) Set the new price to { newPrice}");
        //    ModContent.GetTowerModel<Towers.Tier_AnyLite>(0, 0, 0).cost = newPrice;
        //}

        static bool firstgetRandomMonkeyCostCall = false;
        //6 -> paragon, 7 -> random, 8 -> random lite
        static internal List<float> randomMonkeyCosts = null;

        static internal int GetRandomMonkeyCost(int tier)
        {
            if (firstgetRandomMonkeyCostCall == true)
            {
                return (int)randomMonkeyCosts[tier];
            }

            firstgetRandomMonkeyCostCall = true;

            List<float> monkeyCosts = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //calculate average cost
            foreach (var tower in Game.instance.model.towers)
            {
                if (tower.IsBaseTower)
                {
                    if (tower.IsStandardTower())
                    {
                        //MelonLogger.Msg($"{tower.name}");

                        GeneratorMonkeys.AllMonkeys.Add(tower.name);

                        monkeyCosts[0] += tower.cost;

                        for (int i = 1; i <= 5; ++i)
                        {
                            monkeyCosts[i] += tower.GetUpgrade(0, i).cost;
                            monkeyCosts[i] += tower.GetUpgrade(1, i).cost;
                            monkeyCosts[i] += tower.GetUpgrade(2, i).cost;
                        }
                    }

                    if (tower.IsHero())
                    {
                        //MelonLogger.Msg($"hero: {tower.name}");
                        GeneratorMonkeys.AllHeroes.Add(tower.name);
                        monkeyCosts[Options.heroIndex] += tower.cost;
                    }

                    if (Game.instance.model.GetParagonTower(tower.baseId) != null)
                    {
                        //MelonLogger.Msg($"paragon: {tower.name}, {Game.instance.model.GetParagonUpgrade(tower.name).cost}");
                        GeneratorMonkeys.AllParagons.Add(tower.name);
                        monkeyCosts[Options.paragonIndex] += Game.instance.model.GetParagonUpgrade(tower.name).cost;
                    }
                }

                if (tower.isSubTower)
                {
                    //MelonLogger.Msg($"geraldo: {tower.name}");
                    GeneratorMonkeys.AllSubTowers.Add(tower.name);
                    monkeyCosts[Options.subTowerIndex] += tower.cost;
                }

                //add this
                //if (tower.isSubTower)
                //{
                //    MelonLogger.Msg($"subtower: {tower.name}");
                //}
            }

            float numberOfMonkeys = GeneratorMonkeys.AllMonkeys.Count;
            float numberOfTiers = GeneratorMonkeys.AllMonkeys.Count * 3;

            randomMonkeyCosts = new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            randomMonkeyCosts[0] = monkeyCosts[0] / numberOfMonkeys;
            randomMonkeyCosts[1] = randomMonkeyCosts[0] + (monkeyCosts[1] / numberOfTiers);
            randomMonkeyCosts[2] = randomMonkeyCosts[1] + (monkeyCosts[2] / numberOfTiers);
            randomMonkeyCosts[3] = randomMonkeyCosts[2] + (monkeyCosts[3] / numberOfTiers);
            randomMonkeyCosts[4] = randomMonkeyCosts[3] + (monkeyCosts[4] / numberOfTiers);
            randomMonkeyCosts[5] = randomMonkeyCosts[4] + (monkeyCosts[5] / numberOfTiers);


            randomMonkeyCosts[Options.heroIndex] = (monkeyCosts[Options.heroIndex] / AllHeroes.Count) * 3;
            randomMonkeyCosts[Options.subTowerIndex] = (monkeyCosts[Options.subTowerIndex] / AllSubTowers.Count);
            randomMonkeyCosts[Options.paragonIndex] = monkeyCosts[Options.paragonIndex] / AllParagons.Count;

            randomMonkeyCosts[Options.randomLiteIndex] = CalculateRandomPrice(Options.DefaultProbabilityRandomTierLite);
            randomMonkeyCosts[Options.randomIndex] = CalculateRandomPrice(Options.DefaultProbabilityRandomTier);

            //MelonLogger.Msg($"0: {randomMonkeyCosts[0]}");
            //MelonLogger.Msg($"1: {randomMonkeyCosts[1]}");
            //MelonLogger.Msg($"2: {randomMonkeyCosts[2]}");
            //MelonLogger.Msg($"3: {randomMonkeyCosts[3]}");
            //MelonLogger.Msg($"4: {randomMonkeyCosts[4]}");
            //MelonLogger.Msg($"5: {randomMonkeyCosts[5]}");

            return (int)randomMonkeyCosts[tier];
        }

        static private float CalculateRandomPrice(List<int> probabilities)
        {
            float priceSum = 0;

            for (int i = 0; i < probabilities.Count; i++)
            {
                priceSum += randomMonkeyCosts[i] * probabilities[i];
            }

            return priceSum / 100f;
        }

        static private bool isValidProbalities(List<int> probabilities)
        {
            float sum = 0;

            for (int i = 0; i < probabilities.Count; i++)
            {
                sum += probabilities[i];
            }

            return sum == 100;
        }
    }
}
