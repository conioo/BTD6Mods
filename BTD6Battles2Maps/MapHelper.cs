using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Simulation.SMath;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using System;

namespace BTDBattles2Maps.Maps
{
    public static class MapHelper
    {
        private static System.Random random = new System.Random();

        public static PointInfo AddPoint(float x, float y)
        {
            return new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = random.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Vector3(x, y) };
        }
    }
}
