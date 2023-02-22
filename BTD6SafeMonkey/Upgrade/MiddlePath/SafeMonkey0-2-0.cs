using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using Il2CppAssets.Scripts.Models.Towers;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_2_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 2;

        public override int Cost => 2000;

        public override string Description => "Increases damage and pierce";
        public override string DisplayName => "Agent Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            damageModel.damage += 4;
            projectileModel.pierce += 4;

            ModelCopy.Data = attackModel.Duplicate();
        }

        public override string Icon => "GunIcon";
        public override string Portrait => "GunIcon";
    }
}