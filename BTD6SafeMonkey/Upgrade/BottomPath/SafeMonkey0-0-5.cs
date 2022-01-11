using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;


namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_0_5 : ModUpgrade<SafeMonkey>
    {
        public override int Path => BOTTOM;

        public override int Tier => 5;

        public override int Cost => 326000;

        public override string Description => "Monkey now throws a large amount of shuriken with more damage. New ability speeds up all monkeys by 100%";

        public override string DisplayName => "Mysterious Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            var weaponModelShuriken = attackModel.weapons[0];
            var weaponModelBomb = attackModel.weapons[1];

            var projectileModelShuriken = weaponModelShuriken.projectile;
            var projectileModelBomb = weaponModelBomb.projectile;

            var damageModelShuriken = projectileModelShuriken.GetDamageModel();

            towerModel.range += 10;
            attackModel.range += 10;

            projectileModelShuriken.pierce += 50;
            projectileModelShuriken.radius += 30;
            damageModelShuriken.damage += 70;

            projectileModelBomb.pierce += 60;
            weaponModelBomb.Rate *= 0.5f;

            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalDdtDamage", "Ddt", 1, 240, false, false));
            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalBfbDamage", "Bfb", 1, 240, false, false));
            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalZomgDamage", "Zomg", 1, 240, false, false));
            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalBadDamage", "Bad", 1, 240, false, false));
            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalMoabDamage", "Moab", 1, 240, false, false));
            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalCeramicDamage", "Ceramic", 1, 100, false, false));
            projectileModelBomb.AddBehavior(new DamageModifierForTagModel("AdditionalFortifiedDamage", "Fortified", 1, 240, false, false));

            var ability = Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 5, 0).GetAbility().Duplicate();
            ability.cooldown *= 1.2f;

            weaponModelShuriken.emission = new ArcEmissionModel("EmissionModelLargeAmountShuriken", 14, 0, 40, null, false);

            towerModel.AddBehavior(ability);
            towerModel.ApplyDisplay<QuincyDisplayThree>();

            var ParagonAttack = Game.instance.model.GetTower(TowerType.EngineerMonkey, 5, 0, 2).GetWeapon().Duplicate();
            ParagonAttack.Rate *= 0.85f;
            attackModel.AddWeapon(ParagonAttack);
        }

        public override string Icon => "QuestionIcon";
        public override string Portrait => "QuestionIcon";
    }
}