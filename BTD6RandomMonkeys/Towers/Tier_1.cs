using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;
using System.Collections.Generic;
using MelonLoader;

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