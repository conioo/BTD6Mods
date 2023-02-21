using RandomMonkeys.DefaultOptions;

namespace RandomMonkeys.Towers
{
    class Tier_0 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 0";

        public override int Cost => Options.DefaultCostTier_0;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 0";

        protected override string IconName => "Tier0";

        protected override int Index => 1;
    }
}