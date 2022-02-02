using BTD_Mod_Helper;
using MelonLoader;
using Assets.Main.Scenes;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity;
using HarmonyLib;
using System.Linq;
using System.Collections.Generic;

namespace BTD6Battles2Mode
{
    class Main : BloonsTD6Mod
    {
        // public override string MelonInfoCsURL => "https://raw.githubusercontent.com/GMConio/BTD6Mods/main/BTD6Battles2Mode/Properties/AssemblyInfo.cs";

        // public override string LatestURL => "https://github.com/GMConio/BTD6Mods/blob/main/BTD6Battles2Mode/BTD6Battles2Mode.dll?raw=true";


        const float Group = 0.16f;
        const float Single = 0.4f;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
        }

        [HarmonyPatch(typeof(TitleScreen), "Start")]
        public class OneRedBloon
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                RoundSetModel roundSetModel = Game.instance.model.roundSets.ElementAt(1);
                float maxEnd;
                int counter = 0;
                BloonGroupModel bloonGroupModel;

                var groups = ModModel.ListGroups();

                MelonLogger.Msg(groups.Count());
                MelonLogger.Msg(roundSetModel.rounds.Count());


                foreach (RoundModel roundModel in roundSetModel.rounds)
                {
                    maxEnd = 0;
                    foreach(var i in roundModel.groups)
                    {
                        if(i.end > maxEnd)
                        {
                            maxEnd = i.end;
                        }
                    }

                    if(groups[counter].Item2)
                    {
                        bloonGroupModel = new BloonGroupModel("BloonGroupModel", groups[counter].Item1, 0f, maxEnd, (int)(maxEnd * Group));
                    }
                    else
                    {
                        bloonGroupModel = new BloonGroupModel("BloonGroupModel", groups[counter].Item1, 0f, maxEnd, (int)(maxEnd * Single));
                    }
      
                    var oldGroups = roundModel.groups;

                    roundModel.groups = new BloonGroupModel[]
                    {
                            bloonGroupModel
                    }.AddRangeToArray(oldGroups);

                    ++counter;
                }
            }
        }
    }
}
