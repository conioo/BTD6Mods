using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;


namespace BTD6_SafeMonkey.Upgrade.TopPath
{
    class SafeMonkey3_0_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => TOP;

        public override int Tier => 3;

        public override int Cost => 16000;

        public override string Description => "Safemonkey is starting to make money. Increases damage";

        public override string DisplayName => "Past Safemode";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = attackModel.weapons[0];
            var projectileModel = weaponModel.projectile;
            var damageModel = projectileModel.GetDamageModel();

            damageModel.damage += 4;
            projectileModel.pierce += 8;

            projectileModel.ApplyDisplay<SubscribeDisplay>();
            towerModel.ApplyDisplay<QuincyDisplayTwo>();

            ModelCopy.Data = attackModel.Duplicate();

            var bananaAttack = Game.instance.model.GetTower(TowerType.BananaFarm, 0, 0, 4).GetWeapon().Duplicate();

            attackModel.AddBehavior(bananaAttack);
        }

        public override string Icon => "10_000Icon";
        public override string Portrait => "10_000Icon";
    }
}