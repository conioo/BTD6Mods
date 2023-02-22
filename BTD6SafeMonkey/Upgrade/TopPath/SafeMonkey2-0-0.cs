using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using Il2CppAssets.Scripts.Models.Towers;

namespace BTD6_SafeMonkey.Upgrade.TopPath
{
    class SafeMonkey2_0_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => TOP;

        public override int Tier => 2;

        public override int Cost => 1100;

        public override string Description => "Further enhances attack speed";

        public override string DisplayName => "Starting Safemode";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];

            weaponModel.Rate *= 0.70f;

            ModelCopy.Data = attackModel.Duplicate();
        }

        public override string Icon => "1_000Icon";
        public override string Portrait => "1_000Icon";
    }
}