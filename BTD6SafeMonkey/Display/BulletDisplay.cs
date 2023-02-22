using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace BTD6SafeMonkey.Display
{
    class BulletDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Bullet");
        }
    }
}