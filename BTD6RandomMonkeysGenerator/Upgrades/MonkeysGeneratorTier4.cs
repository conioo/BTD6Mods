using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6RandomMonkeysGenerator.Upgrades
{
    class MonkeysGeneratorTier4 : ModUpgrade<MonkeysGenerator>
    {
        public override int Path => TOP;

        public override int Tier => 4;

        public override int Cost => 22000;

        public override string Description => "Throws tier 4 random monkeys, increase lifespan";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var spawnerAttack = towerModel.GetAttackModel();

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.display = Main.CodeTier4;

            createModel.tower = addMonkey;
        }

        public override string DisplayName => "Generator Tier 4";

        public override string Icon => "Tier4-Icon";
        public override string Portrait => "Tier4-Icon";
    }
}
