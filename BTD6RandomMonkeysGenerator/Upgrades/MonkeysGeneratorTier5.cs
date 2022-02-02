using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6RandomMonkeysGenerator.Upgrades
{
    class MonkeysGeneratorTier5 : ModUpgrade<MonkeysGenerator>
    {
        public override int Path => TOP;

        public override int Tier => 5;

        public override int Cost => 120000;

        public override string Description => "Throws tier 5 random monkeys, increase lifespan";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var spawnerAttack = towerModel.GetAttackModel();

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.display = Main.CodeTier5;

            createModel.tower = addMonkey;
        }

        public override string DisplayName => "Generator Tier 5";

        public override string Icon => "Tier5-Icon";
        public override string Portrait => "Tier5-Icon";
    }
}
