using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6RandomMonkeysGenerator.Upgrades
{
    class MonkeysGeneratorTier1 : ModUpgrade<MonkeysGenerator>
    {
        public override int Path => TOP;

        public override int Tier => 1;

        public override int Cost => 2000;

        public override string Description => "Throws tier 1 random monkeys, increase lifespan";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var spawnerAttack = towerModel.GetAttackModel();

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.display = Main.CodeTier1;

            createModel.tower = addMonkey;
        }

        public override string DisplayName => "Generator Tier 0";

        public override string Icon => "Tier1-Icon";
        public override string Portrait => "Tier1-Icon";
    }
}
