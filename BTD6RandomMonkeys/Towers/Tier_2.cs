using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;
using System.Collections.Generic;
using MelonLoader;

namespace RandomMonkeys.Towers
{
    class Tier_2 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 2";

        public override int Cost => Options.DefaultCostTier_2;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 2";

        protected override string IconName => "Tier2";

        protected override int Index => 1;
    }
}