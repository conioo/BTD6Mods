using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_0_2 : ModUpgrade<SafeMonkey>
    {
        public override int Path => BOTTOM;

        public override int Tier => 2;

        public override int Cost => 400;

        public override string Description => "Can detects camo bloons";

        public override string DisplayName => "Detector Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
            ModelCopy.Data = towerModel.GetAttackModel().Duplicate();
        }

        public override string Icon => "CamoIcon";
        public override string Portrait => "CamoIcon";
    }
}