﻿using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using BTD6CustomizationItems.Items;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;

namespace BTD6CustomizationItems.Display
{
    class BuildingDisplay : ModTowerDisplay<Building>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 0, 4, 0);

        public override bool UseForTower(int[] tiers) => true;

        public override float Scale => 1f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.RemoveBone("IMFLoan_Rig:Sign_Joint");
            node.RemoveBone("IMFLoan_Rig:Pipe_Joint");
        }
    }
}