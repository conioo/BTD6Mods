using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6RandomMonkeysGenerator.Set;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using System.Linq;

namespace BTD6RandomMonkeysGenerator
{
    class MonkeysGenerator : ModTower<RandomMonkeysSet>
    {
        public override string BaseTower => TowerType.EngineerMonkey + "-100";
        public override int Cost => 800;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Description => "Monkeys Generator";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var spawnerAttack = towerModel.GetAttackModels().First(model => model.name.Contains("AttackModel_Spawner"));
            var mainAttack = towerModel.GetAttackModels().First(model => model.name.Contains("AttackModel_Attack"));

            //foreach (var a in spawnerAttack.weapons[0].projectile.behaviors)
            //{
            //    MelonLogger.Msg(a.name);
            //}

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.name = Main.CodeTier0;

            createModel.tower = addMonkey;

            towerModel.range += 20;
            spawnerAttack.range += 20;

            towerModel.RemoveBehavior(mainAttack);
        }

        public override string Icon => "GeneratorIcon";
        public override string Portrait => "GeneratorIcon";
    }
}