
using System.Collections.Generic;

namespace RandomMonkeys.DefaultOptions
{
    static public class Options
    {
        //public static int DefaultCostTier_0 = 550;
        //public const int DefaultCostTier_1 = 950;
        //public const int DefaultCostTier_2 = 1600;
        //public const int DefaultCostTier_3 = 3300;
        //public const int DefaultCostTier_4 = 7800;
        //public const int DefaultCostTier_5 = 40000;
        //public const int DefaultCostTierAny = 6150;
        //public const int DefaultCostTierAnyLite = 2900;

        public static List<int> DefaultProbabilityRandomTier = new List<int>
        {
            8,
            10,
            24,
            32,
            18,
            8
        };

        public static List<int> DefaultProbabilityRandomTierLite = new List<int>
        {
            16,
            18,
            24,
            25,
            17
        };

        public static int paragonIndex = 6;
        public static int heroIndex = 7;
        public static int subTowerIndex = 8;
        public static int randomLiteIndex = 9;
        public static int randomIndex = 10;
    }
}
