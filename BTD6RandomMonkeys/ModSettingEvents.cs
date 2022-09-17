using System;
using MelonLoader;
using RandomMonkeys.MonkeysRandomGenerator;
using BTD_Mod_Helper.Api;

namespace RandomMonkeys.Events
{
    static public class ModSettingEvents
    {
        static public Action<long> ValueChangedTier_0 = (long newValue) =>
        {
            ModContent.GetTowerModel<Towers.Tier_0>(0, 0, 0).cost = newValue;
            MelonLogger.Msg($"(Tier_0) Set the new price to { newValue}");
            GeneratorMonkeys.SetRandomTierCost();
            GeneratorMonkeys.SetRandomTierLiteCost();
        };

        static public Action<long> ValueChangedTier_1 = (long newValue) =>
        {
            ModContent.GetTowerModel<Towers.Tier_1>(0, 0, 0).cost = newValue;
            MelonLogger.Msg($"(Tier_1) Set the new price to { newValue}");
            GeneratorMonkeys.SetRandomTierCost();
            GeneratorMonkeys.SetRandomTierLiteCost();
        };

        static public Action<long> ValueChangedTier_2 = (long newValue) =>
        {
            ModContent.GetTowerModel<Towers.Tier_2>(0, 0, 0).cost = newValue;
            MelonLogger.Msg($"(Tier_2) Set the new price to { newValue}");
            GeneratorMonkeys.SetRandomTierCost();
            GeneratorMonkeys.SetRandomTierLiteCost();
        };

        static public Action<long> ValueChangedTier_3 = (long newValue) =>
        {
            ModContent.GetTowerModel<Towers.Tier_3>(0, 0, 0).cost = newValue;
            MelonLogger.Msg($"(Tier_3) Set the new price to { newValue}");
            GeneratorMonkeys.SetRandomTierCost();
            GeneratorMonkeys.SetRandomTierLiteCost();
        };

        static public Action<long> ValueChangedTier_4 = (long newValue) =>
        {
            ModContent.GetTowerModel<Towers.Tier_4>(0, 0, 0).cost = newValue;
            MelonLogger.Msg($"(Tier_4) Set the new price to { newValue}");
            GeneratorMonkeys.SetRandomTierCost();
            GeneratorMonkeys.SetRandomTierLiteCost();
        };

        static public Action<long> ValueChangedTier_5 = (long newValue) =>
        {
            ModContent.GetTowerModel<Towers.Tier_5>(0, 0, 0).cost = newValue;
            MelonLogger.Msg($"(Tier_5) Set the new price to { newValue}");
            GeneratorMonkeys.SetRandomTierCost();
            GeneratorMonkeys.SetRandomTierLiteCost();
        };

        static public Action<long> ProbabilityChangedTier = (long newProbability) =>
        {
            if (GeneratorMonkeys.isCorrectSumProbability())
            {
                GeneratorMonkeys.SetConverter();
                GeneratorMonkeys.SetRandomTierCost();
            }
        };

        static public Action<long> ProbabilityChangedTierLite = (long newProbability) =>
        {
            if (GeneratorMonkeys.isCorrectSumProbabilityLite())
            {
                GeneratorMonkeys.SetConverterLite();
                GeneratorMonkeys.SetRandomTierLiteCost();
            }
        };

        static public Action<bool> ChangedBooleanSeed = (bool isEnableSeed) =>
        {
            if (isEnableSeed)
            {
                GeneratorMonkeys.SetGeneratorSeed();
                MelonLogger.Msg($"Set seed to: { BloonsMod.Main.Seed.GetValue() }");
            }
            else
            {
                GeneratorMonkeys.SetGeneratorRandom();
                MelonLogger.Msg($"Set random seed");
            }
        };

        static public Action<long> ChangedSeed = (long newSeed) =>
        {
            if (BloonsMod.Main.EnableSeed)
            {
                GeneratorMonkeys.SetGeneratorSeed();
                MelonLogger.Msg($"Set seed to: { (long)BloonsMod.Main.Seed.GetValue() }");
            }
        };

        static public Action<bool> ChangedStateMod = (bool isEnableMod) =>
        {
            if (isEnableMod)
            {
                MelonLogger.Msg($"Enable Mod Random Monkeys");
            }
            else
            {
                MelonLogger.Msg($"Disable Mod Random Monkeys");
            }
        };
    }
}
