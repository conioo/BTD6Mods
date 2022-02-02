using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6RandomMonkeysGenerator.Set;
using MelonLoader;

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
            var spawnerAttack = towerModel.GetAttackModel(0);
            var mainAttack = towerModel.GetAttackModel(1);

            var createModel = spawnerAttack.weapons[0].projectile.GetBehavior<CreateTowerModel>();

            var addMonkey = Game.instance.model.GetTowerModel(TowerType.DartMonkey).Duplicate();

            addMonkey.cost = 0;
            addMonkey.display = Main.CodeTier0;

            createModel.tower = addMonkey;

            towerModel.range += 20;
            spawnerAttack.range += 20;
            towerModel.RemoveBehavior(mainAttack);
        }

        public override string Icon => "GeneratorIcon";
        public override string Portrait => "GeneratorIcon";
    }
}