﻿using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.Collections.Generic;

namespace GeraldoHelpersInShop
{
    class GenieBottleTowerV2 : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("GenieBottleTowerV2").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("GenieBottleTowerV2").portrait;
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.EngineerMonkey;
        public override int Cost => 30000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "GenieBottleTowerV2";
        protected override int Order => 107;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var model = Game.instance.model.GetTowerWithName("GenieBottleTowerV2");


            towerModel.display = model.display;
            towerModel.mods = model.mods?.Duplicate();
            towerModel.footprint = model.footprint?.Duplicate();
            towerModel.targetTypes = model.targetTypes?.Duplicate();
            //towerModel.TargetTypes = model.TargetTypes?.Duplicate();
            towerModel.radius = model.radius;
            // towerModel.radiusSquared = model.radiusSquared;
            towerModel.range = model.range;
            towerModel.ignoreBlockers = model.ignoreBlockers;
            towerModel.isGlobalRange = model.isGlobalRange;
            towerModel.tier = model.tier;
            towerModel.areaTypes = model.areaTypes;
            towerModel.dontDisplayUpgrades = model.dontDisplayUpgrades;
            towerModel.animationSpeed = model.animationSpeed;
            towerModel.blockSelling = model.blockSelling;
            towerModel.cachedThrowMarkerHeight = model.cachedThrowMarkerHeight;
            towerModel.canAlwaysBeSold = model.canAlwaysBeSold;
            towerModel.checkedImplementationType = model.checkedImplementationType;
            towerModel.doesntRotate = model.doesntRotate;
            towerModel.emoteSpriteLarge = model.emoteSpriteLarge;
            towerModel.emoteSpriteSmall = model.emoteSpriteSmall;
            towerModel.towerSize = model.towerSize;
            towerModel.showPowerTowerBuffs = model.showPowerTowerBuffs;
            towerModel.powerName = model.powerName;
            towerModel.isSubTower = model.isSubTower;

            List<Model> list = new List<Model>();

            foreach (var behavior in model.behaviors)
            {
                bool flag = behavior.name != "TowerExpireModel_";
                if (flag)
                {
                    list.Add(behavior);
                }
            }
            towerModel.behaviors = list.ToArray();
        }
    }
}