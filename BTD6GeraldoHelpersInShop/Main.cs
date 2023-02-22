using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;

namespace GeraldoHelpersInShop
{
    public class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/GMConio/BTD6Mods/main/BTD6GeraldoHelpersInShop/Properties/AssemblyInfo.cs";

        public override string LatestURL => "https://github.com/GMConio/BTD6Mods/blob/main/BTD6GeraldoHelpersInShop/BTD6GeraldoHelpersInShop.dll?raw=true";

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