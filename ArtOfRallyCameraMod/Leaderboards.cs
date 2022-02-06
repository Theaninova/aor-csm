using System.Collections;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;

namespace ArtOfRallyCSM
{
    public static class LeaderboardConnectionManager
    {
        public static void PostLeaderboardEntry(string data)
        {
            Main.Logger.Log("Sending Data");
            var request = UnityWebRequest.Post("https://art-of-rally-championship.liteproject.de/api/finish-line", data);
            request.SendWebRequest();
            /*if (request.isNetworkError || request.isHttpError)
            {
                Main.Logger.Error($"Leaderboard Upload Failed: {request.error}");
            }*/
        }
    }
    
    [HarmonyPatch(typeof(LeaderboardsConnection), "ProcessLeaderboardEntry")]
    public class ProcessLeaderboardEntry
    {
        public static void Prefix(string __0, LeaderboardsConnection __instance)
        {
            LeaderboardConnectionManager.PostLeaderboardEntry(__0);
        }
    }
    
    /*[Serializable]
    public struct LeaderboardEntryData
    {
        public string leaderboardName;
        public int score;
        public int carID;
        public int country;
        public int platformID;
        public string userID;
    }

    public static class LeaderboardConnectionManager
    {
        public static IEnumerator PostLeaderboardEntry(LeaderboardEntryData data)
        {
            Main.Logger.Log("Sending Daat");
            var request = UnityWebRequest.Post(Main.Settings.LeaderboardURI, data.ToJson());
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Main.Logger.Error($"Leaderboard Upload Failed: {request.error}");
            }
            
            yield break;
        }
    }
    
    [HarmonyPatch(typeof(LeaderboardsConnection), nameof(LeaderboardsConnection.PostLeaderboardEntry))]
    public class OnLeaderboardEntry
    {
        public static void Prefix(
            LeaderboardsConnection __instance,
            string __0, // leaderboardName,
            int __1, // score,
            int __2, // carID,
            int __3, // country,
            Platform.PlatformType __4, // platformID,
            string __5, // userID,
            PlatformAPISuccessWithResult<bool> __6, // onSuccess,
            PlatformAPIFailed __7, // onFail,
            PlatformAPISuccess __8, // onGhostUploaded,
            PlatformAPIFailed __9, // onGhostUploadFailed,
            byte[] __10) // replayBlob = null)
        {
            __instance.StartCoroutine(LeaderboardConnectionManager.PostLeaderboardEntry(new LeaderboardEntryData
            {
                leaderboardName = __0,
                score = __1,
                carID = __2,
                country = __3,
                platformID = (int)__4,
                userID = __5
            }));
        }
    }*/
}