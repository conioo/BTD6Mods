using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;


namespace BTD6_SafeMonkey.Upgrade.TopPath
{
    class SafeMonkey5_0_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => TOP;

        public override int Tier => 5;

        public override int Cost => 105000;

        public override string Description => "Safemonkey is now making big money";
        public override string DisplayName => "Future safemode";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var bananaAutoAttack = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 2, 4).GetWeapon().Duplicate();
            var bananaAttack = Game.instance.model.GetTower(TowerType.BananaFarm, 5, 0, 0).GetWeapon().Duplicate();

            towerModel.RemoveBehaviors<AttackModel>();

            towerModel.AddBehavior(ModelCopy.Data.Duplicate());

            var attackModel = towerModel.GetAttackModel();

            attackModel.AddBehavior(bananaAutoAttack);
            attackModel.AddBehavior(bananaAttack);

            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            projectileModel.pierce += 40;
            damageModel.damage += 28;

            towerModel.ApplyDisplay<QuincyDisplayThree>();
        }

        public override string Icon => "100_000Icon";
        public override string Portrait => "100_000Icon";
    }
}