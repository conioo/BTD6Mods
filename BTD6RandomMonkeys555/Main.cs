using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using BTD6_Random_Monkeys_5_5_5.Events;
using BTD6_Random_Monkeys_5_5_5.MonkeysRandomGenerator;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using MelonLoader;

namespace BTD6_Random_Monkeys_5_5_5.BloonsMod
{
    class Main : BloonsTD6Mod
    {
        bool FirstLoaded = true;

        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/GMConio/BTD6Mods/main/BTD6RandomMonkeys555/Properties/AssemblyInfo.cs";
        public override string LatestURL => "https://github.com/GMConio/BTD6Mods/blob/main/BTD6RandomMonkeys555/BTD6RandomMonkeys555.dll?raw=true";

        public static readonly ModSettingBool EnableMod = true;
        public static readonly ModSettingBool EnableSeed = false;

        internal static readonly ModSettingInt Seed = 0;

        public override void OnInitialize()
        {
            base.OnInitialize();

            EnableMod.OnValueChanged.Add(ModSettingEvents.ChangedStateMod);
            EnableSeed.OnValueChanged.Add(ModSettingEvents.ChangedBooleanSeed);
            Seed.OnValueChanged.Add(ModSettingEvents.ChangedSeed);

            MelonLogger.Msg("Mod BTD6_Random_Monkeys 5_5_5 Loaded!");
        }
        //public override void OnLoaderInitialized()
        //{
        //    base.OnLoaderInitialized();

        //    EnableMod.OnValueChanged.Add(ModSettingEvents.ChangedStateMod);
        //    EnableSeed.OnValueChanged.Add(ModSettingEvents.ChangedBooleanSeed);
        //    Seed.OnValueChanged.Add(ModSettingEvents.ChangedSeed);

        //    MelonLogger.Msg("Mod BTD6_Random_Monkeys 5_5_5 Loaded!");
        //}
        public override void OnApplicationStart()
        {
            EnableMod.OnValueChanged.Add(ModSettingEvents.ChangedStateMod);
            EnableSeed.OnValueChanged.Add(ModSettingEvents.ChangedBooleanSeed);
            Seed.OnValueChanged.Add(ModSettingEvents.ChangedSeed);

            MelonLogger.Msg("Mod BTD6_Random_Monkeys 5_5_5 Loaded!");

            base.OnApplicationStart();
        }
        public override void OnMainMenu()
        {
            base.OnMainMenu();

            if (FirstLoaded)
            {
                FirstLoaded = false;
            }
        }


        public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
        {
            base.OnTowerCreated(tower, target, modelToUse);

            //MelonLogger.Msg("dziala tutaj ");

            if (modelToUse.name.Contains("Tier") && Main.EnableMod)
            {
                if (modelToUse.name.Contains("Tier_0"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModelTier0());
                }
                else if (modelToUse.name.Contains("Tier_1_1"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel__x(1));
                }
                else if (modelToUse.name.Contains("Tier_1_x"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel_xx(1));
                }
                else if (modelToUse.name.Contains("Tier_2_2"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel__x(2));
                }
                else if (modelToUse.name.Contains("Tier_2_x"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel_xx(2));
                }
                else if (modelToUse.name.Contains("Tier_3_3"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel__x(3));
                }
                else if (modelToUse.name.Contains("Tier_3_x"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel_xx(3));
                }
                else if (modelToUse.name.Contains("Tier_4_4"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel__x(4));
                }
                else if (modelToUse.name.Contains("Tier_4_x"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel_xx(4));
                }
                else if (modelToUse.name.Contains("Tier_5_5"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel__x(5));
                }
                else if (modelToUse.name.Contains("Tier_5_x"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModel_xx(5));
                }
                else if (modelToUse.name.Contains("Tier_Random_Lite"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModelRandomLite());
                }
                else if (modelToUse.name.Contains("Tier_Random"))
                {
                    tower.SetTowerModel(GeneratorMonkeys.GetTowerModelRandom());
                }
            }

        }
    }

    //[HarmonyPatch(typeof(Tower), "Initialise")]
    //public class TowerInitialise_Patch
    //{
    //    [HarmonyPrefix]
    //    public static bool Prefix(Tower __instance, ref Model modelToUse)
    //    {
    //        MelonLogger.Msg("dziala tutaj ");

    //        if (modelToUse.name.Contains("Tier") && Main.EnableMod)
    //        {
    //            if (modelToUse.name.Contains("Tier_0"))
    //            {
    //                __instance.SetTowerModel()
    //                modelToUse = GeneratorMonkeys.GetTowerModelTier0();
    //            }
    //            else if (modelToUse.name.Contains("Tier_1_1"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel__x(1);
    //            }
    //            else if (modelToUse.name.Contains("Tier_1_x"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel_xx(1);
    //            }
    //            else if (modelToUse.name.Contains("Tier_2_2"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel__x(2);
    //            }
    //            else if (modelToUse.name.Contains("Tier_2_x"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel_xx(2);
    //            }
    //            else if (modelToUse.name.Contains("Tier_3_3"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel__x(3);
    //            }
    //            else if (modelToUse.name.Contains("Tier_3_x"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel_xx(3);
    //            }
    //            else if (modelToUse.name.Contains("Tier_4_4"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel__x(4);
    //            }
    //            else if (modelToUse.name.Contains("Tier_4_x"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel_xx(4);
    //            }
    //            else if (modelToUse.name.Contains("Tier_5_5"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel__x(5);
    //            }
    //            else if (modelToUse.name.Contains("Tier_5_x"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModel_xx(5);
    //            }
    //            else if (modelToUse.name.Contains("Tier_Random_Lite"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModelRandomLite();
    //            }
    //            else if (modelToUse.name.Contains("Tier_Random"))
    //            {
    //                modelToUse = GeneratorMonkeys.GetTowerModelRandom();
    //            }
    //        }

    //        return true;
    //    }
    //}
}