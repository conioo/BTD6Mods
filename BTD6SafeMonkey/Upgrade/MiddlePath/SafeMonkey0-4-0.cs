using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_4_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 4;

        public override int Cost => 22800;

        public override string Description => "Attack receives more damage, pierce and increases the range. Bullets bounce off balloons";
        public override string DisplayName => "MachineGun SafeMonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.RemoveBehaviors<AttackModel>();

            towerModel.AddBehavior(ModelCopy.Data.Duplicate());

            var attackModel = towerModel.GetAttackModel();

            var grenadeAttack = Game.instance.model.GetTower(TowerType.NinjaMonkey, 2, 0, 5).GetWeapon().Duplicate();
            grenadeAttack.Rate *= 0.7f;
            grenadeAttack.projectile.ApplyDisplay<GrenadeDisplay>();
            attackModel.AddWeapon(grenadeAttack);

            var weaponModelGun = attackModel.weapons[0];
            var weaponModelGrenade = attackModel.weapons[1];
            var projectileModelGun = weaponModelGun.projectile;
            var projectileModelGrenade = weaponModelGrenade.projectile;

            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalMoabDamage", "Moab", 1, 80, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalCeramicDamage", "Ceramic", 1, 60, false, false));
            projectileModelGrenade.AddBehavior(new DamageModifierForTagModel("AdditionalFortifiedDamage", "Fortified", 1, 80, false, false));

            towerModel.range += 10;
            attackModel.range += 10;

            weaponModelGun.projectile.pierce += 30;

            var reflection = Game.instance.model.GetTower(TowerType.SniperMonkey, 0, 3, 0).GetAttackModel().weapons[0].projectile.GetBehavior<RetargetOnContactModel>().Duplicate();
            reflection.distance = 420;
            projectileModelGun.AddBehavior(reflection);
        }

        public override string Icon => "MachineGunIcon";
        public override string Portrait => "MachineGunIcon";
    }
}