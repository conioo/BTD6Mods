using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6SafeMonkey
{
    class SafeMonkey : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override string Description => "Safemonkey is strong monkey";
        public override int Cost => 650;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            towerModel.range = 50;
            attackModel.range = 50;

            damageModel.damage = 1;
            projectileModel.pierce = 2;

            projectileModel.ApplyDisplay<ShurikenDisplay>();
        }
        public override ParagonMode ParagonMode => ParagonMode.Base000;
        public override string Icon => "SafeIcon";
        public override string Portrait => "SafeIcon";
    }
}
