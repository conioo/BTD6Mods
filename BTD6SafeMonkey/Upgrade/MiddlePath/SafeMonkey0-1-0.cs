using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_1_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 1;

        public override int Cost => 700;

        public override string Description => "increases attack speed and damage";

        public override string DisplayName => "Soldier Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            damageModel.damage += 1;
            weaponModel.Rate *= 0.8f;

            projectileModel.ApplyDisplay<BulletDisplay>();
            ModelCopy.Data = attackModel.Duplicate();
        }

        public override string Icon => "BulletIcon";
        public override string Portrait => "BulletIcon";
    }
}