using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_0_3 : ModUpgrade<SafeMonkey>
    {
        public override int Path => BOTTOM;

        public override int Tier => 3;

        public override int Cost => 5600;

        public override string Description => "Throws three shurikens at once and increases the attack speed by 40%";

        public override string DisplayName => "Fast Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            weaponModel.Rate *= 0.60f;
            projectileModel.pierce += 8;
            damageModel.damage += 2;

            weaponModel.emission = new ArcEmissionModel("EmissionModelThreeShuriken", 3, 0, 30, null, false);

            towerModel.ApplyDisplay<QuincyDisplayTwo>();
        }

        public override string Icon => "ShurikenIcon";
        public override string Portrait => "ShurikenIcon";
    }
}