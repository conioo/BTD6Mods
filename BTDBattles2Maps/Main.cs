﻿using Assets.Main.Scenes;
using Assets.Scripts.Data;
using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using NinjaKiwi.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using UnhollowerBaseLib;
using UnityEngine;

namespace BTDBattles2Maps
{
    public class Main : BloonsMod
    {
        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/conioo/BTD6Mods/main/BTD6Battles2Maps/Properties/AssemblyInfo.cs";
        public override string LatestURL => "https://github.com/conioo/BTD6Mods/blob/main/BTD6Battles2Maps/BTDBattles2Maps.dll?raw=true";

        private bool First = true;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }
        static string LastMap = null;
        static bool isRestart = false;

        static bool isCustom(string map)
        {
            return mapList.Where(x => x.name == map).Count() > 0;
        }

        static MapInfo[] mapList = new MapInfo[]
        {         
            new MapInfo("Docks", MapDifficulty.Beginner, Maps.Docks.pathmodel(), Maps.Docks.spawner(), Maps.Docks.areas(), "MusicDarkA", "Docks"),
            new MapInfo("BasaltColumns", MapDifficulty.Beginner, Maps.BasaltColumns.pathmodel(), Maps.BasaltColumns.spawner(), Maps.BasaltColumns.areas(), "MusicDarkA", "Basalt Columns"),
            new MapInfo("Garden", MapDifficulty.Beginner, Maps.Garden.pathmodel(), Maps.Garden.spawner(), Maps.Garden.areas(), "MusicDarkA", "Garden"),
            new MapInfo("Koru", MapDifficulty.Beginner, Maps.Koru.pathmodel(), Maps.Koru.spawner(), Maps.Koru.areas(), "MusicDarkA", "Koru"),
            new MapInfo("Mayan", MapDifficulty.Beginner, Maps.Mayan.pathmodel(), Maps.Mayan.spawner(), Maps.Mayan.areas(), "MusicDarkA", "Mayan"),
            new MapInfo("SandsOfTime", MapDifficulty.Beginner, Maps.SandsOfTime.pathmodel(), Maps.SandsOfTime.spawner(), Maps.SandsOfTime.areas(), "MusicDarkA", "Sands Of Time"),
            new MapInfo("InTheWall", MapDifficulty.Beginner, Maps.InTheWall.pathmodel(), Maps.InTheWall.spawner(), Maps.InTheWall.areas(), "MusicDarkA", "In The Wall"),
            new MapInfo("BloontoniumMines", MapDifficulty.Beginner, Maps.BloontoniumMines.pathmodel(), Maps.BloontoniumMines.spawner(), Maps.BloontoniumMines.areas(), "MusicDarkA", "Bloontonium Mines"),
            new MapInfo("CastleRuins", MapDifficulty.Beginner, Maps.CastleRuins.pathmodel(), Maps.CastleRuins.spawner(), Maps.CastleRuins.areas(), "MusicDarkA", "Castle Ruins"),
            new MapInfo("Glade", MapDifficulty.Beginner, Maps.Glade.pathmodel(), Maps.Glade.spawner(), Maps.Glade.areas(), "MusicDarkA", "Glade"),
            new MapInfo("DinoGraveyard", MapDifficulty.Beginner, Maps.DinoGraveyard.pathmodel(), Maps.DinoGraveyard.spawner(), Maps.DinoGraveyard.areas(), "MusicDarkA", "Dino Graveyard"),
            new MapInfo("Inflection", MapDifficulty.Beginner, Maps.Inflection.pathmodel(), Maps.Inflection.spawner(), Maps.Inflection.areas(), "MusicDarkA", "Inflection"),
            new MapInfo("Ports", MapDifficulty.Beginner, Maps.Ports.pathmodel(), Maps.Ports.spawner(), Maps.Ports.areas(), "MusicDarkA", "Ports"),

            new MapInfo("InTheWallDouble", MapDifficulty.Intermediate, Maps.InTheWallDouble.pathmodel(), Maps.InTheWallDouble.spawner(), Maps.InTheWallDouble.areas(), "MusicDarkA", "In The Wall Double"),
            new MapInfo("BloontoniumMinesDouble", MapDifficulty.Intermediate, Maps.BloontoniumMinesDouble.pathmodel(), Maps.BloontoniumMinesDouble.spawner(), Maps.BloontoniumMinesDouble.areas(), "MusicDarkA", "Bloontonium Mines Double"),
            new MapInfo("CastleRuinsDouble", MapDifficulty.Intermediate, Maps.CastleRuinsDouble.pathmodel(), Maps.CastleRuinsDouble.spawner(), Maps.CastleRuinsDouble.areas(), "MusicDarkA", "Castle Ruins Double"),
        };

        [HarmonyPatch(typeof(TitleScreen), "Start")]
        public class Awake_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (var mapdata in mapList)
                {
                    GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                    {
                        id = mapdata.name,
                        isBrowserOnly = false,
                        isDebug = false,
                        difficulty = mapdata.difficulty,
                        unlockDifficulty = MapDifficulty.Beginner,
                        mapMusic = mapdata.mapMusic,
                        mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                        coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                    }).ToArray();

                    if (!LocalizationManager.Instance.textTable.ContainsKey(mapdata.name))
                    {
                        LocalizationManager.Instance.textTable.Add(mapdata.name, mapdata.mapDisplayName);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(MapLoader), nameof(MapLoader.LoadScene))]
        public class LoadMap
        {
            [HarmonyPrefix]
            internal static bool Fix(ref MapLoader __instance)
            {
                LastMap = __instance.currentMapName;
                isRestart = false;

                if (isCustom(LastMap))
                {
                    __instance.currentMapName = "MuddyPuddles";
                }
                return true;
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            bool inAGame = InGame.instance != null && InGame.instance.bridge != null;

            if (First && inAGame)
            {
                foreach (var mapData in mapList)
                {
                    if (!Game.instance.GetBtd6Player().IsMapUnlocked(mapData.name))
                    {
                        Game.instance.GetBtd6Player().UnlockMap(mapData.name);
                        InGame.instance.Player.UnlockMap(mapData.name);
                    }
                }
                First = false;
            }
        }

        //public override void OnUpdate()
        //{
        //    base.OnUpdate();

        //    bool inAGame = InGame.instance != null && InGame.instance.bridge != null;

        //    bool flag = inAGame && Input.GetKeyDown(KeyCode.Mouse1);
        //    bool flag2 = inAGame && Input.GetKeyDown(KeyCode.F1);

        //    if (flag)
        //    {
        //        InputManager inputManager = InGame.instance.inputManager;
        //        if (inputManager != null)
        //        {
        //            MelonLogger.Msg(inputManager.cursorPositionWorld.ToString());
        //        }
        //    }

        //    if (flag2)
        //    {
        //        MelonLogger.Msg("BTD_Battles_2_MapBTD_Battles_2_MapBTD_Battles_2_MapBTD_Battles_2_MapBTD_Battles_2_Map");
        //    }

        //    if (First && inAGame)
        //    {
        //        foreach (var mapData in mapList)
        //        {
        //            if (!Game.instance.GetBtd6Player().IsMapUnlocked(mapData.name))
        //            {
        //                Game.instance.GetBtd6Player().UnlockMap(mapData.name);
        //                InGame.instance.Player.UnlockMap(mapData.name);
        //            }
        //        }
        //        First = false;
        //    }
        //}

        [HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.InitMap))]
        internal class InitMap_Patch
        {
            [HarmonyPrefix]
            internal static bool Prefix(UnityToSimulation __instance, ref MapModel map)
            {                           
                if (!isCustom(LastMap) || isRestart)
                {
                    return true;
                }

                isRestart = true;

                MapInfo mapdata = mapList.Where(x => x.name == LastMap).First();
                Texture2D tex = ModContent.GetTexture<Main>(mapdata.name);
                byte[] filedata = null;

                filedata = Image.Resize(ImageConversion.EncodeToPNG(tex), 1750, 1064);
                float divx = 2;
                float divy = 1.21f;
                int marginx = 450;
                int marginy = 890;
                Bitmap old = new Bitmap(System.Drawing.Image.FromStream(new MemoryStream(filedata)));
                Bitmap newImage = new Bitmap(old.Width + marginx, old.Height + marginy);

                using (var graphics = System.Drawing.Graphics.FromImage(newImage))
                {
                    int x = (int)((newImage.Width - old.Width) / divx);
                    int y = (int)((newImage.Height - old.Height) / divy);
                    graphics.DrawImage(old, x, y);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        filedata = ms.ToArray();
                    }
                }

                ImageConversion.LoadImage(tex, filedata);
                var ob2 = GameObject.Find("MuddyPuddlesTerrain");
                ob2.GetComponent<Renderer>().material.mainTexture = tex;

                foreach (var ob in Object.FindObjectsOfType<GameObject>())
                {
                    if (ob.name.Contains("Festive") || ob.name.Contains("Rocket") || ob.name.Contains("Firework") || ob.name.Contains("Box") || ob.name.Contains("Candy") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Ripples") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Shadow") || ob.name.Contains("WaterSplashes"))
                    {
                        if (ob.name != "MuddyPuddlesTerrain")
                        {
                            ob.transform.position = new Vector3(1000, 1000, 1000);
                        }
                    }
                }

                map.areas = mapdata.areas;
                map.spawner = mapdata.spawner;
                map.paths = mapdata.paths;
                map.name = mapdata.name;
                map.mapName = mapdata.name;
                
                if (GameObject.Find("Rain"))
                {
                    GameObject.Find("Rain").active = false;
                }

                return true;
            }
        }

        public static Il2CppReferenceArray<Assets.Scripts.Simulation.SMath.Polygon> Empty()
        {
            return new Il2CppReferenceArray<Assets.Scripts.Simulation.SMath.Polygon>(0);
        }
    }
}