using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Map;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace RandomMonkeys.Set
{
    public class RandomMonkeysSet : ModTowerSet
    {
        public override string DisplayName => "Random";
        public override string Container => "ItemsContainer";
        public override string Button => "ItemsContainer"; //zmiana
        public override string ContainerLarge => "ItemsContainer";
        public override string Portrait => "ItemsContainer";
    }
}
