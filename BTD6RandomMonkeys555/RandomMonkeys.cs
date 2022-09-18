using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using System;
using System.Collections.Generic;

namespace BTD6_Random_Monkeys_5_5_5.MonkeysRandomGenerator
{
    static internal class GeneratorMonkeys
    {
        static private readonly int numberConverters = 20;

        static private readonly (bool, int)[] Converter = new (bool, int)[20];
        static private readonly (bool, int)[] ConverterLite = new (bool, int)[20];

        static private readonly int[] TierRange = new int[6];

        // true    __X
        // false   _XX
        static GeneratorMonkeys()
        {
            Converter[0] = (false, 5);
            Converter[1] = (true, 4);
            Converter[2] = (false, 4);
            Converter[3] = (false, 4);
            Converter[4] = (true, 3);
            Converter[5] = (true, 3);
            Converter[6] = (true, 3);
            Converter[7] = (false, 3);
            Converter[8] = (false, 3);
            Converter[9] = (false, 3);
            Converter[10] = (false, 3);
            Converter[11] = (true, 2);
            Converter[12] = (true, 2);
            Converter[13] = (true, 2);
            Converter[14] = (false, 2);
            Converter[15] = (false, 2);
            Converter[16] = (true, 1);
            Converter[17] = (true, 1);
            Converter[18] = (false, 1);
            Converter[19] = (true, 0);

            TierRange[1] = 16;
            TierRange[2] = 11;
            TierRange[3] = 4;
            TierRange[4] = 1;
            TierRange[5] = 0;

            ConverterLite[0] = (false, 4);
            ConverterLite[1] = (false, 4);
            ConverterLite[2] = (true, 3);
            ConverterLite[3] = (true, 3);
            ConverterLite[4] = (true, 3);
            ConverterLite[5] = (false, 3);
            ConverterLite[6] = (false, 3);
            ConverterLite[7] = (false, 3);
            ConverterLite[8] = (false, 3);
            ConverterLite[9] = (false, 3);
            ConverterLite[10] = (true, 2);
            ConverterLite[11] = (true, 2);
            ConverterLite[12] = (true, 2);
            ConverterLite[13] = (true, 2);
            ConverterLite[14] = (false, 2);
            ConverterLite[15] = (false, 2);
            ConverterLite[16] = (true, 1);
            ConverterLite[17] = (true, 1);
            ConverterLite[18] = (false, 1);
            ConverterLite[19] = (true, 0);
        }

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

        static private readonly int numberMonkeys = AllMonkeys.Count;

        static private Random RandomGenerator = new Random();

        static private string GetMonkey()
        {
            return AllMonkeys[RandomGenerator.Next(numberMonkeys)];
        }

        static internal TowerModel GetTowerModel_xx(int _tier)
        {
            string towerType = GetMonkey();

            int mainPath = RandomGenerator.Next(3);

            int firstRandomTier = Converter[RandomGenerator.Next(TierRange[_tier], numberConverters)].Item2;
            int secondRandomTier = Converter[RandomGenerator.Next(TierRange[_tier], numberConverters)].Item2;

            if (mainPath == 0)
            {
                return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, firstRandomTier, secondRandomTier);
            }
            else if (mainPath == 1)
            {
                return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, firstRandomTier, _tier, secondRandomTier);
            }
            else
            {
                return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, firstRandomTier, secondRandomTier, _tier);
            }
        }

        static internal TowerModel GetTowerModel__x(int _tier)
        {
            string towerType = GetMonkey();

            int firstPath = RandomGenerator.Next(3);
            int secondPath = RandomGenerator.Next(2);

            int randomTier = Converter[RandomGenerator.Next(TierRange[_tier], numberConverters)].Item2;

            if (firstPath == 0)
            {
                if (secondPath == 0)
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, _tier, randomTier);
                }
                else
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, randomTier, _tier);
                }
            }
            else if (firstPath == 1)
            {
                if (secondPath == 0)
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, _tier, randomTier);
                }
                else
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, randomTier, _tier, _tier);
                }
            }
            else
            {
                if (secondPath == 0)
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, _tier, randomTier, _tier);
                }
                else
                {
                    return InGameExt.GetGameModel(InGame.instance).GetTower(towerType, randomTier, _tier, _tier);
                }
            }
        }

        static internal TowerModel GetTowerModelTier0()
        {
            return InGameExt.GetGameModel(InGame.instance).GetTower(GetMonkey(), 0, 0, 0);
        }

        static internal TowerModel GetTowerModelRandom()
        {
            int index = RandomGenerator.Next(numberConverters);

            if (Converter[index].Item1)
            {
                return GetTowerModel__x(Converter[index].Item2);
            }
            else
            {
                return GetTowerModel_xx(Converter[index].Item2);
            }
        }

        static internal TowerModel GetTowerModelRandomLite()
        {
            int index = RandomGenerator.Next(numberConverters);

            if (ConverterLite[index].Item1)
            {
                return GetTowerModel__x(ConverterLite[index].Item2);
            }
            else
            {
                return GetTowerModel_xx(ConverterLite[index].Item2);
            }
        }

        static internal void SetGeneratorSeed()
        {
            RandomGenerator = new Random(BloonsMod.Main.Seed);
        }

        static internal void SetGeneratorRandom()
        {
            RandomGenerator = new Random();
        }
    }
}
