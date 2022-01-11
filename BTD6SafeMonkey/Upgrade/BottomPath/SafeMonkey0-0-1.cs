using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;


namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_0_1 : ModUpgrade<SafeMonkey>
    {
        public override int Path => BOTTOM;

        public override int Tier => 1;

        public override int Cost => 300;

        public override string Description => "increases range attack";

        public override string DisplayName => "Falcon  Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            towerModel.range += 15;
            attackModel.range += 15;

            ModelCopy.Data = attackModel.Duplicate();
        }

        public override string Icon => "RangeIcon";
        public override string Portrait => "RangeIcon";
    }
}