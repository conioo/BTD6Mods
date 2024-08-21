using BTD_Mod_Helper.Api.ModOptions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class RandomHero : BaseMonkey
    {
        public override string Description => "Random Hero";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Random Hero";

        protected override string IconName => "Hero";

        protected override int Index => Options.heroIndex;

        protected override int Order => 1;
        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomHero;

    }
}
