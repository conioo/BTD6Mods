using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;

namespace BTD6SafeMonkey.Display
{
    class ParagonDisplay : ModTowerDisplay<SafeMonkey>
    {
        public override string BaseDisplay => "3db6fc68b301c6d48aac832f6894c384";
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "paragon");
        }
        public override bool UseForTower(int[] tiers)
        {
            return IsParagon(tiers);
        }
        public override float Scale => 1.5f;
    }
}