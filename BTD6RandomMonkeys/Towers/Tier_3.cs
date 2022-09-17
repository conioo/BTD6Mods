using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;
using System.Collections.Generic;
using MelonLoader;

namespace RandomMonkeys.Towers
{
    class Tier_3 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 3";

        public override int Cost => Options.DefaultCostTier_3;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 3";

        protected override string IconName => "Tier3";

        protected override int Index => 2;
    }
}