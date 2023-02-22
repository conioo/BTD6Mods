using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using Factory = BTD6CustomizationItems.Items.Factory;

namespace BTD6CustomizationItems.Display
{
    class FactoryDisplay : ModTowerDisplay<Factory>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 4, 0, 0);

        public override bool UseForTower(int[] tiers) => true;

        public override float Scale => 1f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.RemoveBone("ResearchFacility_Rig:Pipe_Joint");
            node.RemoveBone("ResearchFacility_Rig:Sign_Joint");
        }
    }
}