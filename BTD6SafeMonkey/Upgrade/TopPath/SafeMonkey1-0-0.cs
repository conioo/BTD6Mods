using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using Il2CppAssets.Scripts.Models.Towers;

namespace BTD6_SafeMonkey.Upgrade.TopPath
{
    class SafeMonkey1_0_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => 450;

        public override string Description => "Increases attack speed and pierce";

        public override string DisplayName => "Unknown Safemode";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;

            weaponModel.Rate *= 0.9f;
            projectileModel.pierce += 1;

            ModelCopy.Data = attackModel.Duplicate();
        }

        public override string Icon => "500Icon";
        public override string Portrait => "500Icon";
    }
}