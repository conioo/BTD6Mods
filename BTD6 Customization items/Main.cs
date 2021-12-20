using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD6_Customization_items
{
    class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/AutoEscape/Main.cs";
        public override string LatestURL => "https://github.com/doombubbles/BTD6-Mods/blob/main/AutoEscape/AutoEscape.dll?raw=true";

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }
    }
}
