using BTD_Mod_Helper;

namespace BTD6CustomizationItems
{
    class Main : BloonsTD6Mod
    {
        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/GMConio/BTD6Mods/main/BTD6CustomizationItems/Properties/AssemblyInfo.cs";
        public override string LatestURL => "https://github.com/GMConio/BTD6Mods/blob/main/BTD6CustomizationItems/BTD6CustomizationItems.dll?raw=true";

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }
    }
}
