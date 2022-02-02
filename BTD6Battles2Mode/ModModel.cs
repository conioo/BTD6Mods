using Assets.Scripts.Models.Rounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD6Battles2Mode
{
    public static class ModModel
    {
        private static List<DataGroup> DataGroups = new List<DataGroup>
        {
            new DataGroup{FirstRound = 1, EndRound = 140,  BloonType = "Red", isGroup = true},
        };

        public static List<(string, bool)> ListGroups()
        {
            var listGroup = new List<(string, bool)>();

            foreach (var dataGroup in DataGroups)
            {
                for (int i = dataGroup.FirstRound - 1; i < dataGroup.EndRound; ++i)
                {
                    listGroup.Add((dataGroup.BloonType, dataGroup.isGroup));
                }
            }

            return listGroup;
        }
    }
}
