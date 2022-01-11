using BTD6_Random_Monkeys_5_5_5.MonkeysRandomGenerator;
using MelonLoader;
using System;

namespace BTD6_Random_Monkeys_5_5_5.Events
{
    static public class ModSettingEvents
    {
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
                MelonLogger.Msg($"Enable Mod BTD6_Random_Monkeys 5_5_5");
            }
            else
            {
                MelonLogger.Msg($"Disable Mod BTD6_Random_Monkeys 5_5_5");
            }
        };
    }
}
