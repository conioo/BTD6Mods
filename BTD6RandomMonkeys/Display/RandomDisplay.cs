using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;

namespace RandomMonkeys.Display
{
    class RandomDisplay : ModDisplay
    {
        public override string BaseDisplay => "ad073d9875ec542458cf4eae79f3f29c";

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "RandomDisplay", 1);
        }
    }
}
