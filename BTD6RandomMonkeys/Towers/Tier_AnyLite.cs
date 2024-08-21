using BTD_Mod_Helper.Api.ModOptions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_AnyLite : BaseMonkey
    {
        public override string Description => "Random Tier Lite (without Tier 5)";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Random Tier Lite";

        protected override string IconName => "TierAny";

        protected override int Index => Options.randomLiteIndex;

        protected override int Order => 2;

        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomAnyLite;
    }
}