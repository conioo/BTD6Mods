using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using System;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using HarmonyLib;
using Il2CppSystem;
using UnityEngine;
using Il2CppNewtonsoft.Json;
using Il2CppNewtonsoft.Json.Converters;

namespace BTD6GeraldoHelpersInShop
{
    class ShootyTurretTower : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("ShootyTurretTower").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("ShootyTurretTower").portrait;
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.EngineerMonkey;
        public override int Cost => 400;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "ShootyTurretTower";
        public override int Order => 100;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var model = Game.instance.model.GetTowerWithName("ShootyTurretTower");

            towerModel.display = model.display;
            towerModel.mods = model.mods.Duplicate();
            towerModel.behaviors = model.behaviors.Duplicate();
            towerModel.footprint = model.footprint.Duplicate();
            towerModel.targetTypes = model.targetTypes.Duplicate();
            towerModel.TargetTypes = model.TargetTypes.Duplicate();
            towerModel.radius = model.radius;
            towerModel.radiusSquared = model.radiusSquared;
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
            towerModel.emoteSpriteLarge = model.emoteSpriteSmall;
            towerModel.towerSize = model.towerSize;
            towerModel.showPowerTowerBuffs = model.showPowerTowerBuffs;
            towerModel.powerName = model.powerName;
            towerModel.isSubTower = model.isSubTower;

            //MelonLogger.Msg("\n\n" + model.name + "\n");
            //foreach (var i in towerModel.behaviors)
            //{
            //    MelonLogger.Msg(i.name);
            //}
        }
    }
}
