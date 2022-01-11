using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD6SafeMonkey;
using BTD6SafeMonkey.Display;

namespace BTD6_SafeMonkey.Upgrade.MiddlePath
{
    class SafeMonkey0_3_0 : ModUpgrade<SafeMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 3;

        public override int Cost => 9500;

        public override string Description => "Throws a grenade that stuns the balloons";

        public override string DisplayName => "Grenade Safemonkey";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            ModelCopy.Data = attackModel.Duplicate();

            var grenadeAttack = Game.instance.model.GetTower(TowerType.NinjaMonkey, 2, 0, 4).GetWeapon().Duplicate();
            grenadeAttack.Rate *= 0.7f;
            grenadeAttack.projectile.GetDamageModel().damage += 8;
            grenadeAttack.projectile.ApplyDisplay<GrenadeDisplay>();
            attackModel.AddWeapon(grenadeAttack);

            towerModel.ApplyDisplay<QuincyDisplayTwo>();
        }

        public override string Icon => "GrenadeIcon";
        public override string Portrait => "GrenadeIcon";
    }
}