using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6_Customization_items.Display
{
    class CottageDisplay : ModTowerDisplay<Cottage>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BananaFarm, 0, 3, 0);

        public override bool UseForTower(int[] tiers) => true;

        public override float Scale => 1f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.RemoveBone("Bank_Rig:Sign_Joint");
        }
    }
}