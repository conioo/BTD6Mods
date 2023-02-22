using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace BTD6RandomMonkeysGenerator.Upgrades
{
    class MonkeysGeneratorTier2 : ModUpgrade<MonkeysGenerator>
    {
        public override int Path => TOP;

        public override int Tier => 2;

        public override int Cost => 3500;

        public override string Description => "Throws tier 2 random monkeys, increase lifespan";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var spawnerAttack = towerModel.GetAttackModel();

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.name = Main.CodeTier2;

            createModel.tower = addMonkey;
        }

        public override string DisplayName => "Generator Tier 2";

        public override string Icon => "Tier2-Icon";
        public override string Portrait => "Tier2-Icon";
    }
}
