using BTD_Mod_Helper.Api.ModOptions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_Any : BaseMonkey
    {
        public override string Description => "Random Tier";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Random Tier";

        protected override string IconName => "TierAny";

        protected override int Index => Options.randomIndex;
        protected override int Order => 3;

        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomAny;
    }
}