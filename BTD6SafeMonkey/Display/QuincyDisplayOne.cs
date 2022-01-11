using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace BTD6SafeMonkey.Display
{
    class QuincyDisplayOne : ModDisplay
    {
        public override string BaseDisplay => "cddca470955e4e64da4063f1aa110f2b";

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "cddca470955e4e64da4063f1aa110f2b");
        }
    }
}