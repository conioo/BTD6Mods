using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_5 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 5";

        public override int Cost => Options.DefaultCostTier_5;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 5";

        protected override string IconName => "Tier5";

        protected override int Index => 1;
    }
}