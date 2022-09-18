using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD6_Customization_items.Display
{
    class TreeDisplay : ModTowerDisplay<Tree>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 0, 0, 0);

        public override bool UseForTower(int[] tiers) => true;

        public override float Scale => 1f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
           // node.PrintInfo();

            node.RemoveBone("BananaFarm_Rig:Bananas");
            //node.RemoveBone("BananaFarm_Rig:Root");
        }
    }
}