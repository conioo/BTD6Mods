using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6_Random_Monkeys_5_5_5.DefaultOptions;
using BTD6_Random_Monkeys_5_5_5.Display;
using UnhollowerBaseLib;

namespace BTD6_Random_Monkeys_5_5_5.Towers
{
    class Tier_3_3_x : ModTower
    {
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.SniperMonkey;
        public override string Description => "Random Tower Tier 3_3_x";

        public override int Cost => Options.DefaultCostTier_3_3_x;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            Il2CppStructArray<AreaType> newAreaType = new Il2CppStructArray<AreaType>(2);

            newAreaType[0] = AreaType.land;
            newAreaType[1] = AreaType.water;

            towerModel.areaTypes = newAreaType;

            towerModel.ApplyDisplay<RandomDisplay>();
        }

        public override string Icon => "Tier3-Icon";
        public override string Portrait => "Tier3-Icon";
    }
}