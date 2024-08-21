using BTD_Mod_Helper.Api.ModOptions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_4 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 4";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 4";

        protected override string IconName => "Tier4";

        protected override int Index => 4;
        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomTier4;

    }
}