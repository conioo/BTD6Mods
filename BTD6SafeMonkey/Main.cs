using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Utils;
using MelonLoader;

namespace BTD6SafeMonkey
{
    class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/conioo/BTD6Mods/main/BTD6SafeMonkey/Properties/AssemblyInfo.cs";

        public override string LatestURL => "https://github.com/conioo/BTD6Mods/blob/main/BTD6SafeMonkey/BTD6SafeMonkey.dll?raw=true";

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("Mod SafeMonkey Loaded!");
        }
    }
}