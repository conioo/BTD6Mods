using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;


namespace BTD6_SafeMonkey.Upgrade.TopPath
{
    class SafeMonkey4_0_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => TOP;

        public override int Tier => 4;

        public override int Cost => 55000;

        public override string Description => "Safemonkey earns more and more. Increases damage";

        public override string DisplayName => "Current Safemode";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var weaponModel = ModelCopy.Data.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            damageModel.damage += 8;
            projectileModel.pierce += 20;

            var bananaAttack = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 2, 5).GetWeapon().Duplicate();

            towerModel.RemoveBehaviors<AttackModel>();

            towerModel.AddBehavior(ModelCopy.Data.Duplicate());

            var attackModelRefresh = towerModel.GetAttackModel();

            attackModelRefresh.AddBehavior(bananaAttack);
        }

        public override string Icon => "50_000Icon";
        public override string Portrait => "50_000Icon";
    }
}