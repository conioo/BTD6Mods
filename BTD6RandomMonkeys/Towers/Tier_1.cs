using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using RandomMonkeys.DefaultOptions;
using RandomMonkeys;
using RandomMonkeys.MonkeysRandomGenerator;
using System.Threading;
using BTD_Mod_Helper.Api.ModOptions;


namespace RandomMonkeys.Towers
{
    class Tier_1 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 1";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 1";

        protected override string IconName => "Tier1";

        protected override int Index => 1;

        public override ModSettingHotkey Hotkey => RandomMonkeys.BloonsMod.Main.RandomTier1;
    }
}