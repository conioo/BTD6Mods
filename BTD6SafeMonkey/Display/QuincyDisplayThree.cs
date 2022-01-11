using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace BTD6SafeMonkey.Display
{
    class QuincyDisplayThree : ModDisplay
    {
        public override string BaseDisplay => "3db6fc68b301c6d48aac832f6894c384";

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "3db6fc68b301c6d48aac832f6894c384");
        }
    }
}