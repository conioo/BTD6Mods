using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_1 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 1";

        public override int Cost => Options.DefaultCostTier_1;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 1";

        protected override string IconName => "Tier1";

        protected override int Index => 2;
    }
}