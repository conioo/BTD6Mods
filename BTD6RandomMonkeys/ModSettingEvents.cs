using System;
using MelonLoader;
using RandomMonkeys.MonkeysRandomGenerator;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Events
{
    static public class ModSettingEvents
    {
        static public Action<double> PriceMultiplierSaved = (double newValue) =>
        {
            MelonLogger.Msg($"Set the new PriceMultiplier to {newValue}");

            foreach (var towerDetails in Game.instance.model.GetAllTowerDetails())
            {
                if (towerDetails.name.Contains("BTD6RandomMonkeys"))
                {
                    if (towerDetails.name.Contains("Tier_0"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(0);
                    }
                    else if (towerDetails.name.Contains("Tier_1"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(1);
                    }
                    else if (towerDetails.name.Contains("Tier_2"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(2);
                    }
                    else if (towerDetails.name.Contains("Tier_3"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(3);
                    }
                    else if (towerDetails.name.Contains("Tier_4"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(4);
                    }
                    else if (towerDetails.name.Contains("Tier_5"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(5);
                    }
                    else if (towerDetails.name.Contains("Tier_AnyLite"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(Options.randomLiteIndex);
                    }
                    else if (towerDetails.name.Contains("Tier_Any"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(Options.randomIndex);
                    }
                    else if (towerDetails.name.Contains("RandomHero"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(Options.heroIndex);
                    }
                    else if (towerDetails.name.Contains("RandomParagon"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(Options.paragonIndex);
                    }
                    else if (towerDetails.name.Contains("RandomSubTower"))
                    {
                        towerDetails.GetTower().cost = GeneratorMonkeys.GetRandomMonkeyCost(Options.subTowerIndex);
                    }

                    towerDetails.GetTower().cost *= (float)newValue;
                }
            }
        };

        static public Action<bool> RandomSeedSaved = (bool newValue) =>
        {
            if (newValue)
            {
                GeneratorMonkeys.SetGeneratorRandom();
                MelonLogger.Msg($"Set random seed");
            }
            else
            {
                GeneratorMonkeys.SetGeneratorSeed();
                MelonLogger.Msg($"Set seed to: {BloonsMod.Main.Seed.GetValue()}");
            }
        };

        static public Action<long> SeedSaved = (long newValue) =>
        {
            if (BloonsMod.Main.RandomSeed)
            {
                GeneratorMonkeys.SetGeneratorRandom();
                MelonLogger.Msg($"Set random seed");
            }
            else
            {
                GeneratorMonkeys.SetGeneratorSeed();
                MelonLogger.Msg($"Set seed to: {BloonsMod.Main.Seed.GetValue()}");
            }
            //MelonLogger.Msg($"Set the new Seed to {newValue}");
        };

        //static public Action<long> ProbabilityChangedTier = (long newProbability) =>
        //{
        //    if (GeneratorMonkeys.isCorrectSumProbability())
        //    {
        //        GeneratorMonkeys.SetConverter();
        //        GeneratorMonkeys.SetRandomTierCost();
        //    }
        //};
    }
}
