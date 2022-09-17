using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using RandomMonkeys.DefaultOptions;
using System.Collections.Generic;
using MelonLoader;

namespace RandomMonkeys.Towers
{
    class Tier_4 : BaseMonkey
    {
        public override string Description => "Random Tower Tier 4";

        public override int Cost => Options.DefaultCostTier_0;

        public override bool DontAddToShop => false;

        public override string DisplayName => "Tier 4";

        protected override string IconName => "Tier4";

        protected override int Index => 2;
    }
}