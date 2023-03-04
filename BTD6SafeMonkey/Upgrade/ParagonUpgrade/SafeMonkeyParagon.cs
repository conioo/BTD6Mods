using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey.Display;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace BTD6SafeMonkey.Upgrade.ParagonUpgrade
{
    class SafeMonkeyParagon : ModParagonUpgrade<SafeMonkey>
    {
        public override int Cost => 15500000;

        public override string Description => "Paragon SafeMonkey";

        public override int Priority => -1;

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var baseWeaponModel = attackModel.weapons[0];
            var baseProjectileModel = baseWeaponModel.projectile;
            var baseDamageModel = baseProjectileModel.GetDamageModel();

            baseProjectileModel.ApplyDisplay<BulletDisplay>();

            baseWeaponModel.emission = new ArcEmissionModel("EmissionModelThreeShuriken", 8, 0, 20, null, false);

            baseProjectileModel.pierce += 500000;
            baseDamageModel.damage += 500000;
            baseDamageModel.immuneBloonProperties = BloonProperties.None;


            var grenadeAttack = Game.instance.model.GetTower(TowerType.NinjaMonkey, 2, 0, 5).GetWeapon().Duplicate();
            grenadeAttack.Rate *= 0.1f;

            grenadeAttack.projectile.ApplyDisplay<GrenadeDisplay>();

            var grenadeProjectileModel = grenadeAttack.projectile;
            var grenadeDamageModel = grenadeProjectileModel.GetDamageModel();

            grenadeDamageModel.immuneBloonProperties = BloonProperties.None;
            grenadeDamageModel.maxDamage = float.MaxValue;
            grenadeProjectileModel.maxPierce = float.MaxValue;

            grenadeDamageModel.damage += 200000;
            grenadeProjectileModel.pierce += 200000;

            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalDdtDamage", "Ddt", 2, 200000, false, false));
            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalBfbDamage", "Bfb", 2, 200000, false, false));
            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalZomgDamage", "Zomg", 2, 200000, false, false));
            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalBadDamage", "Bad", 2, 200000, false, true));
            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalMoabDamage", "Moab", 2, 200000, false, false));
            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalCeramicDamage", "Ceramic", 2, 200000, false, false));
            grenadeProjectileModel.AddBehavior(new DamageModifierForTagModel("AdditionalFortifiedDamage", "Fortified", 2, 200000, false, false));

            attackModel.AddWeapon(grenadeAttack);

            towerModel.range += 90;
            towerModel.radiusSquared += 90;

            var reflection = Game.instance.model.GetTower(TowerType.SniperMonkey, 0, 3, 0).GetAttackModel().weapons[0].projectile.GetBehavior<RetargetOnContactModel>().Duplicate();
            reflection.distance = 800;
            grenadeProjectileModel.AddBehavior(reflection);
            //towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}
