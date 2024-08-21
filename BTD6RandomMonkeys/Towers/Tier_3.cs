using BTD_Mod_Helper.Api.ModOptions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_3 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 3";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 3";

        protected override string IconName => "Tier3";

        protected override int Index => 3;
        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomTier3;

    }
}