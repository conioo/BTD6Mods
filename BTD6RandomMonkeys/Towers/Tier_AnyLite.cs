using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;
using System.Collections.Generic;
using MelonLoader;

namespace RandomMonkeys.Towers
{
    class Tier_AnyLite : BaseMonkey
    {
        public override string Description => "Random Tier Lite (without Tier 5)";

        public override int Cost => Options.DefaultCostTierAnyLite;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Random Tier Lite";

        protected override string IconName => "TierAny";

        protected override int Index => 7;
    }
}