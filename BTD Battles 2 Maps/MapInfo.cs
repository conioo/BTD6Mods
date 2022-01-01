using MelonLoader;
using HarmonyLib;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using System.IO;
using Assets.Main.Scenes;
using UnityEngine;
using System.Linq;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Models.Map;
using UnhollowerBaseLib;
using Assets.Scripts.Data;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.Bridge;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppSystem.Reflection;
using Assets.Scripts.Unity.UI_New.Main.MapSelect;
using Assets.Scripts.Unity.Player;
using NinjaKiwi.Common;

namespace BTDBattles2Maps
{
    public class MapInfo
    {
        public string name;
        public MapDifficulty difficulty;
        public PathModel[] paths;
        public PathSpawnerModel spawner;
        public Il2CppReferenceArray<AreaModel> areas;
        public string mapMusic;
        public string mapDisplayName;

        public MapInfo(string name, MapDifficulty difficulty, PathModel[] paths, PathSpawnerModel spawner, Il2CppReferenceArray<AreaModel> areas, string mapMusic, string mapDisplayName)
        {
            this.name = name;
            this.difficulty = difficulty;
            this.paths = paths;
            this.spawner = spawner;
            this.areas = areas;
            this.mapMusic = mapMusic;
            this.mapDisplayName = mapDisplayName;
        }
    }
}