using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Map.Spawners;
using UnhollowerBaseLib;

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