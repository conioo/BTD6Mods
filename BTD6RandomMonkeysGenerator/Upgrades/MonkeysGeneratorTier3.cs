using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6RandomMonkeysGenerator.Upgrades
{
    class MonkeysGeneratorTier3 : ModUpgrade<MonkeysGenerator>
    {
        public override int Path => TOP;

        public override int Tier => 3;

        public override int Cost => 8000;

        public override string Description => "Throws tier 3 random monkeys, increase lifespan";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var spawnerAttack = towerModel.GetAttackModel();

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.display = Main.CodeTier3;

            createModel.tower = addMonkey;
        }

        public override string DisplayName => "Generator Tier 3";

        public override string Icon => "Tier3-Icon";
        public override string Portrait => "Tier3-Icon";
    }
}
