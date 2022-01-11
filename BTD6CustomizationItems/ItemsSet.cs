using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Map;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace BTD6_Customization_items
{
    public class ItemsSet : ModTowerSet
    {
        public override string DisplayName => "Items";
        public override string Container => "ItemsContainer";
        public override string Button => "ButtonItems";
        public override string ContainerLarge => "ItemsContainer";
        public override string Portrait => "ItemsContainer";
    }
}
