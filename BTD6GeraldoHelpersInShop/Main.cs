using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;

namespace GeraldoHelpersInShop
{
    public class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("Mod Geraldo helpers in shop loaded!");
        }
        public override void OnMatchStart()
        {
            //    MelonLogger.Msg(Game.instance.model.towers.Count);

            //    foreach (var item in Game.instance.model.towers)
            //    {
            //        MelonLogger.Msg(item.name);
            //    }
        }
    }
}