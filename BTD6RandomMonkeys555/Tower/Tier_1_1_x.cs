﻿using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6_Random_Monkeys_5_5_5.DefaultOptions;
using BTD6_Random_Monkeys_5_5_5.Display;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace BTD6_Random_Monkeys_5_5_5.Towers
{
    class Tier_1_1_x : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.SniperMonkey;
        public override string Description => "Random Tower Tier 1_1_x";

        public override int Cost => Options.DefaultCostTier_1_1_x;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            //Il2CppStructArray<AreaType> newAreaType = new Il2CppStructArray<AreaType>(2);

            //newAreaType[0] = AreaType.land;
            //newAreaType[1] = AreaType.water;

            //towerModel.ApplyDisplay<RandomDisplay>();
        }

        public override string Icon => "Tier1-Icon";
        public override string Portrait => "Tier1-Icon";
    }
}