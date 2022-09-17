using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;
using System.Collections.Generic;
using MelonLoader;

namespace RandomMonkeys.Towers
{
    class Tier_Any : BaseMonkey
    {
        public override string Description => "Random Tier";

        public override int Cost => Options.DefaultCostTierAny;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Random Tier";

        protected override string IconName => "TierAny";

        protected override int Index => 1;
    }
}