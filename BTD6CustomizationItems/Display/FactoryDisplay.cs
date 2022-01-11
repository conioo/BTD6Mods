using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6_Customization_items.Display
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