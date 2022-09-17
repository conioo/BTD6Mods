using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

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
