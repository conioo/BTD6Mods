using BTD_Mod_Helper.Api.ModOptions;
using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class RandomParagon : BaseMonkey
    {
        public override string Description => "Random Paragon";

        public override bool DontAddToShop => false;

        public override string DisplayName => "Random Paragon";

        protected override string IconName => "Paragon";

        protected override int Index => Options.paragonIndex;
        protected override int Order => 1;

        public override ModSettingHotkey Hotkey => BloonsMod.Main.RandomParagon;

    }
}
