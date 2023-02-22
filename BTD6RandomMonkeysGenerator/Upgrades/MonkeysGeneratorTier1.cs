using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

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

            addMonkey.name = Main.CodeTier1;

            addMonkey.radius = 50;
            addMonkey.range = 50;

            createModel.tower = addMonkey;
        }

        public override string DisplayName => "Generator Tier 0";

        public override string Icon => "Tier1-Icon";
        public override string Portrait => "Tier1-Icon";
    }

}
