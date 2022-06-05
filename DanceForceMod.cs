using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;

[assembly: AssemblyVersion("0.0.0.1")]
[assembly: AssemblyInformationalVersion("0.0.0.1")]

namespace DanceForce
{
    [BepInPlugin("DanceForce", "DanceForce", "0.0.0.1")]
    public class DanceForceMod : BaseUnityPlugin
    {
        static float danceTimer = 0;

        void Awake()
        {
            Debug.Log("May the Force be Dancing");
            new Harmony("DanceForce").PatchAll();
        }

        public static bool InTreehouse()
        {
            return SceneManager.GetActiveScene().name == "TreeHouseLobby";
        }
        public static bool OneHost(Character chara)
        {
            return chara.AssociatedLobbyPlayer && chara.AssociatedLobbyPlayer.networkNumber == 1 && chara.AssociatedLobbyPlayer.localNumber == 1 && chara.AssociatedLobbyPlayer.isServer;
        }

        public static LevelPortal OnLevel(Character chara)
        {
            var levelselector = LobbyManager.instance.CurrentLevelSelectController;
            LevelPortal lp = null;

            if (levelselector)
            {
                foreach (LevelPortal levelPortal in levelselector.portals)
                {
                    foreach (VoteArrow voteArrow in levelPortal.Votes.Values)
                    {
                        if(voteArrow.ChrPresent && voteArrow.lastCharacterSelected == chara)
                        {
                            lp = levelPortal;
                            break;
                        }
                    }
                }
            }
            return lp;
        }



        [HarmonyPatch(typeof(Character), nameof(Character.Update))]
        static class CharacterUpdatePatch
        {
            static void Prefix(Character __instance)
            {

                if (InTreehouse() && OneHost(__instance))
                {
                    if (__instance.dancing)
                    {
                        LevelPortal lp = OnLevel(__instance);
                        if(lp != null)
                        {
                            danceTimer += Time.deltaTime;
                            Debug.Log("danceTimer " + danceTimer);
                            if (danceTimer > 1f)
                            {
                                LobbyManager.instance.CurrentLevelSelectController.LaunchLevel(lp);
                            }
                        }
                    } 
                    else
                    {
                        DanceForceMod.danceTimer = 0f;
                    }
                }
            }
        }
    }
}