using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_5_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 5;

        public override int Cost => 128000;

        public override string Description => "Increases the power of attacks";

        public override string DisplayName => "Terrorist SafeMonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<QuincyDisplayThree>();

            var attackModel = towerModel.GetAttackModel();
            var weaponModelGun = attackModel.weapons[0];
            var weaponModelGrenade = attackModel.weapons[1];
            var projectileModelGrenade = weaponModelGrenade.projectile;
            var projectileModelGun = weaponModelGun.projectile;
            var damageModelGrenade = projectileModelGrenade.GetDamageModel();
            var damageModelGun = projectileModelGun.GetDamageModel();

            damageModelGun.damage += 40;
            projectileModelGun.pierce += 40;
            weaponModelGun.Rate *= 0.4f;

            var copyAttack = weaponModelGun.Duplicate();
            copyAttack.ejectX += 5;
            weaponModelGun.ejectX -= 5;
            attackModel.AddWeapon(copyAttack);

            damageModelGrenade.damage += 20;
            weaponModelGrenade.Rate *= 0.35f;

            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalMoabDamage", "Moab", 1, 200, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalFortifiedDamage", "Fortified", 1, 200, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalBfbDamage", "Bfb", 1, 200, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalZomgDamage", "Zomg", 1, 200, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalDdtDamage", "Ddt", 1, 220, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalBadDamage", "Bad", 1, 220, false, false));

            towerModel.ApplyDisplay<QuincyDisplayThree>();
        }

        public override string Icon => "MachineGunTwoIcon";
        public override string Portrait => "MachineGunTwoIcon";
    }
}