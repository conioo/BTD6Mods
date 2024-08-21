using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using RandomMonkeys.DefaultOptions;
using RandomMonkeys.MonkeysRandomGenerator;

namespace RandomMonkeys.Towers
{
    class Tier_0 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 0";
        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 0";

        protected override string IconName => "Tier0";

        protected override int Index => 0;
        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomTier0;

    }
}